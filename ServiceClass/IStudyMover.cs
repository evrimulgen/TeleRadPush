using System;
namespace StudyMover
{
    public interface IStudyMover
    {
        void EndGetStudies(IAsyncResult result);
        void EndMoveStudies(IAsyncResult result);
        void EndSendStudies(IAsyncResult result);
        string GetInstanceFilePath(string StudyInstanceUID, string SeriesInstanceUID, string SopInstanceUID);
        string GetSeriesFolderPath(string StudyInstanceUID, string SeriesInstanceUID);
        IAsyncResult GetStudiesPatientLevel(RetriveEntity RetriveFrom, AsyncCallback OnOperationComplete, string PatientID = null, string PatientName = null);
        IAsyncResult GetStudiesSeriesLevel(RetriveEntity RetriveFrom, AsyncCallback OnOperationComplete, string studyInstanceUid, string modality);
        IAsyncResult GetStudiesStudyLevel(RetriveEntity RetriveFrom, AsyncCallback OnOperationComplete, string PatientId, string PatientName, DateTime? FromDate, DateTime? ToDate, string accession, string studyId, string modalitiesInStudy, string studyInstanceUid);
        string GetStudyFolderPath(string StudyInstanceUID);
        void MoveStudies(RetriveEntity RetriveFrom, AsyncCallback OnOperationComplete, string StudyInstanceUID);
        void MoveStudies(RetriveEntity RetriveFrom, AsyncCallback OnOperationComplete, string StudyInstanceUID, string seriesInstanceUid);
        void SendStudies(RetriveEntity RetriveFrom, AsyncCallback OnOperationCompleted, string StudyInstanceUID);
        void SendStudies(RetriveEntity RetriveFrom, AsyncCallback OnOperationCompleted, string StudyInstanceUID, string SeriesInstanceUid, string Modality);
    }
}
