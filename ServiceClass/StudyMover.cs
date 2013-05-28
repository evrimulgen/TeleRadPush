

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dicom;
using Dicom.Network;
using System.Threading;
using System.IO;
using NLog;
using System.Xml.Serialization;

namespace StudyMover
{
    public class StudyMover
    {
        #region Variable member

        static AutoResetEvent autoEvent;
        private Func<DicomDataset, Study> FillStudy;
        private StudyMoverSettings _MoverSettings;
        private List<Study> _studyList;
        private DicomServer<CStoreSCU> _scuStore;

        #endregion

        #region Private Methods

        private List<Study> GetStudies(RetriveEntity RetriveFrom, DicomCFindRequest request)
        {
            DicomClient _client = new DicomClient();
            _studyList = new List<Study>();
            request.OnResponseReceived = (DicomCFindRequest rec_request, DicomCFindResponse response) =>
            {
                if (response.HasDataset)
                {
                    _studyList.Add(FillStudy(response.Dataset));
                }
                autoEvent.Set();
            };
            _client.AddRequest(request);
            if (RetriveFrom == RetriveEntity.Modality)
            {
                _client.Send(_MoverSettings.Host, _MoverSettings.Port, false, _MoverSettings.Store_AE_Name, _MoverSettings.CalledAE);
            }
            else
            {
                _client.Send(_MoverSettings.StoreHost, _MoverSettings.StorePort, false, _MoverSettings.Store_AE_Name, _MoverSettings.CalledAE);
            }

            autoEvent.WaitOne();
            return _studyList;
        }

        private void MoveStudies(RetriveEntity RetriveFrom, DicomCMoveRequest cmoveRequest)
        {
            //Try to open Local SCP for CStore Support for comming files
            if (_scuStore == null)
                _scuStore = new DicomServer<CStoreSCU>(_MoverSettings.LocalPort);
            DicomClient clt = new DicomClient();

            // Add request to Dicom Client Object.
            clt.AddRequest(cmoveRequest);

            string Host, CalledAE;
            int Port;
            GetEntityInfo(RetriveFrom, out Host, out Port, out CalledAE);
            clt.Send(Host, Port, false, _MoverSettings.Store_AE_Name, CalledAE);
            autoEvent.WaitOne();
        }

        private void GetEntityInfo(RetriveEntity EntityType, out string HostName, out int Port, out string CalledAE)
        {
            if (EntityType == RetriveEntity.Modality)
            {
                HostName = _MoverSettings.Host;
                Port = _MoverSettings.Port;
                CalledAE = _MoverSettings.CalledAE;
            }
            else
            {
                HostName = _MoverSettings.StoreHost;
                Port = _MoverSettings.StorePort;
                CalledAE = _MoverSettings.StoreCalledAE;
            }
        }

        #endregion

        #region Public Methods

        public static StudyMoverSettings LoadSettingfromXmlFile()
        {
            string FileName = Properties.Resources.StudyMoverSettingsFilePath;
            XmlSerializer ser = new XmlSerializer(typeof(StudyMoverSetting));
            TextReader reader = new StreamReader(Path.GetFullPath(FileName));
            StudyMoverSetting studyxset = (StudyMoverSetting)ser.Deserialize(reader);
            return studyxset.Items.Single();
        }

        public StudyMover()
        {
            _MoverSettings = LoadSettingfromXmlFile();
            FillStudy = (StudyDataSet) =>
            {
                return new Study
                {
                    SeriesUID = StudyDataSet.Get(DicomTag.SeriesInstanceUID, ""),
                    StudyInstanceUID = StudyDataSet.Get(DicomTag.StudyInstanceUID, ""),
                    PatientID = StudyDataSet.Get(DicomTag.PatientID, ""),
                    PatientName = StudyDataSet.Get(DicomTag.PatientName, ""),
                    SopInstanceUID = StudyDataSet.Get(DicomTag.SOPInstanceUID, "")
                };
            };
            autoEvent = new AutoResetEvent(false);
        }

        public List<Study> GetStudiesPatientLevel(RetriveEntity RetriveFrom, string PatientID = null, string PatientName = null)
        {
            var request = DicomCFindRequest.CreatePatientQuery(PatientID, PatientName);
            return GetStudies(RetriveFrom, request);
        }

        public List<Study> GetStudiesStudyLevel(RetriveEntity RetriveFrom, string PatientId, string PatientName, DateTime? Fromdate, DateTime? Todate, string accession,
    string studyId, string modalitiesInStudy, string studyInstanceUid)
        {
            DicomDateRange dcmdateRange = null;
            if (Fromdate.HasValue && Todate.HasValue)
                dcmdateRange = new DicomDateRange(Fromdate.Value, Todate.Value);
            var request = DicomCFindRequest.CreateStudyQuery(PatientId, PatientName, dcmdateRange, accession, studyId, modalitiesInStudy, studyInstanceUid);
            return GetStudies(RetriveFrom, request);
        }

        //public List<Study> GetStudies(RetriveEntity RetriveFrom, string PatientId, string PatientName, DicomDateRange DateRange, string accession,
        //    string studyId, string modalitiesInStudy, string studyInstanceUid)
        //{
        //    var request = DicomCFindRequest.CreateStudyQuery(PatientId, PatientName, DateRange, accession, studyId, modalitiesInStudy, studyInstanceUid);
        //    return GetStudies(RetriveFrom, request);
        //}

        public List<Study> GetStudiesSeriesLevel(RetriveEntity RetriveFrom, string studyInstanceUid, string modality)
        {
            var request = DicomCFindRequest.CreateSeriesQuery(studyInstanceUid, modality);
            return GetStudies(RetriveFrom, request);
        }

        public void MoveStudies(RetriveEntity RetriveFrom, string StudyInstanceUID)
        {
            DicomCMoveRequest cmove = new DicomCMoveRequest(_MoverSettings.Store_AE_Name, StudyInstanceUID);
            MoveStudies(RetriveFrom, cmove);
        }

        public void MoveStudies(RetriveEntity RetriveFrom, string StudyInstanceUID, string seriesInstanceUid)
        {
            DicomCMoveRequest cmove = new DicomCMoveRequest(_MoverSettings.Store_AE_Name, StudyInstanceUID, seriesInstanceUid);
            MoveStudies(RetriveFrom, cmove);
        }

        //public void MoveStudies(RetriveEntity RetriveFrom, string StudyInstanceUID, string seriesInstanceUid, string sopInstanceUid)
        //{
        //    DicomCMoveRequest cmove = new DicomCMoveRequest(_MoverSettings.Store_AE_Name, StudyInstanceUID, seriesInstanceUid, sopInstanceUid);
        //    MoveStudies(RetriveFrom, cmove);

        //}

        private void SendStudies(IEnumerable<string> FilesPathToSend)
        {
            DicomClient clt = new DicomClient();
            foreach (var FilePath in FilesPathToSend)
            {
                DicomCStoreRequest cstrore = new DicomCStoreRequest(FilePath);
                cstrore.OnResponseReceived = (request, response) =>
                {

                    autoEvent.Set();
                };
                clt.AddRequest(cstrore);
            }
            clt.Send(_MoverSettings.StoreHost, _MoverSettings.StorePort, false, _MoverSettings.Store_AE_Name, _MoverSettings.StoreCalledAE);
            autoEvent.WaitOne();
        }

        public void SendStudies(RetriveEntity RetriveFrom, string StudyInstanceUID, string Modality)
        {
            var path = GetStudyFolderPath(StudyInstanceUID);
            List<Study> StudiesToTransfer = GetStudiesSeriesLevel(RetriveFrom, StudyInstanceUID, Modality);

            if (!Directory.Exists(path))
                MoveStudies(RetriveFrom, StudyInstanceUID);
            else
            {
                foreach (var item in StudiesToTransfer)
                {
                    if (!Directory.Exists(Path.Combine(path, item.SeriesUID)))
                    {
                        MoveStudies(RetriveFrom, StudyInstanceUID, item.SeriesUID);
                    }
                }
            }

            SendStudies(Directory.GetFiles(GetStudyFolderPath(StudyInstanceUID), "*.*", SearchOption.AllDirectories));
        }

        public void SendStudies(RetriveEntity RetriveFrom, string StudyInstanceUID, string SeriesInstanceUid, string Modality)
        {
            var path = GetStudyFolderPath(StudyInstanceUID);
            if (!Directory.Exists(GetSeriesFolderPath(StudyInstanceUID, SeriesInstanceUid)))
                MoveStudies(RetriveFrom, StudyInstanceUID, SeriesInstanceUid);

            SendStudies(Directory.GetFiles(GetSeriesFolderPath(StudyInstanceUID, SeriesInstanceUid), "*.*", SearchOption.AllDirectories));
        }

        #region utility methods

        public string GetStudyFolderPath(string StudyInstanceUID)
        {
            return Path.Combine(Path.GetFullPath(_MoverSettings.StoragePath), StudyInstanceUID);
        }

        public string GetSeriesFolderPath(string StudyInstanceUID, string SeriesInstanceUID)
        {
            return Path.Combine(GetStudyFolderPath(StudyInstanceUID), SeriesInstanceUID);
        }

        public string GetInstanceFilePath(string StudyInstanceUID, string SeriesInstanceUID, string SopInstanceUID)
        {
            return Path.Combine(GetSeriesFolderPath(StudyInstanceUID, SeriesInstanceUID), SopInstanceUID);
        }

        #endregion

        #endregion

        #region Nested Classes
        class CStoreSCU : DicomService, IDicomServiceProvider, IDicomCStoreProvider, IDicomCEchoProvider
        {
            private StudyMoverSettings settings;

            private static DicomTransferSyntax[] AcceptedTransferSyntaxes = new DicomTransferSyntax[] {
				DicomTransferSyntax.ExplicitVRLittleEndian,
				DicomTransferSyntax.ExplicitVRBigEndian,
				DicomTransferSyntax.ImplicitVRLittleEndian,
			};

            private static DicomTransferSyntax[] AcceptedImageTransferSyntaxes = new DicomTransferSyntax[] {
				// Lossless
				DicomTransferSyntax.JPEGLSLossless,
				DicomTransferSyntax.JPEG2000Lossless,
				DicomTransferSyntax.JPEGProcess14SV1,
				DicomTransferSyntax.JPEGProcess14,
				DicomTransferSyntax.RLELossless,
			
				// Lossy
				DicomTransferSyntax.JPEGLSNearLossless,
				DicomTransferSyntax.JPEG2000Lossy,
				DicomTransferSyntax.JPEGProcess1,
				DicomTransferSyntax.JPEGProcess2_4,

				// Uncompressed
				DicomTransferSyntax.ExplicitVRLittleEndian,
				DicomTransferSyntax.ExplicitVRBigEndian,
				DicomTransferSyntax.ImplicitVRLittleEndian
			};

            public CStoreSCU(Stream stream, Logger log)
                : base(stream, log)
            {
                settings = StudyMover.LoadSettingfromXmlFile();
            }

            public void OnReceiveAssociationRequest(DicomAssociation association)
            {
                if (association.CalledAE == settings.Store_AE_Name)
                {
                    foreach (var pc in association.PresentationContexts)
                    {
                        if (pc.AbstractSyntax == DicomUID.Verification)
                            pc.AcceptTransferSyntaxes(AcceptedTransferSyntaxes);
                        else if (pc.AbstractSyntax.StorageCategory != DicomStorageCategory.None)
                            pc.AcceptTransferSyntaxes(AcceptedImageTransferSyntaxes);
                    }
                    SendAssociationAccept(association);
                }
                else
                {
                    SendAssociationReject(DicomRejectResult.Permanent, DicomRejectSource.ServiceUser, DicomRejectReason.CalledAENotRecognized);
                    autoEvent.Set();
                }
            }

            public void OnReceiveAssociationReleaseRequest()
            {
                SendAssociationReleaseResponse();
                autoEvent.Set();
            }

            public void OnReceiveAbort(DicomAbortSource source, DicomAbortReason reason)
            {
                autoEvent.Set();
            }

            public void OnConnectionClosed(int errorCode)
            {
                autoEvent.Set();
            }

            public DicomCStoreResponse OnCStoreRequest(DicomCStoreRequest request)
            {
                var studyUid = request.Dataset.Get<string>(DicomTag.StudyInstanceUID);
                var seriesId = request.Dataset.Get<string>(DicomTag.SeriesInstanceUID);
                var sopinsId = request.Dataset.Get<string>(DicomTag.SOPInstanceUID);
                var path = Path.GetFullPath(settings.StoragePath);
                path = Path.Combine(path, studyUid);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, seriesId);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = Path.Combine(path, sopinsId);
                request.File.Save(path);
                autoEvent.Set();
                return new DicomCStoreResponse(request, DicomStatus.Success);
            }

            public void OnCStoreRequestException(string tempFileName, Exception e)
            {
                // let library handle logging and error response
                autoEvent.Set();
            }

            public DicomCEchoResponse OnCEchoRequest(DicomCEchoRequest request)
            {
                return new DicomCEchoResponse(request, DicomStatus.Success);
            }
        }
        #endregion
    }

    public class Study
    {
        public string PatientName { get; set; }
        public string PatientID { get; set; }
        public string StudyInstanceUID { get; set; }
        public string SeriesUID { get; set; }
        public string SopInstanceUID { get; set; }
    }

    public enum RetriveEntity
    {
        Server,
        Modality
    }
}
