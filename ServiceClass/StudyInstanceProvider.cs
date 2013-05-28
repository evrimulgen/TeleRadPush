using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace StudyMover
{
    public class StudyInstanceProvider : IStudyInstanceProvider
    {
        private string[] _series;
        private string _studyPath;

        public StudyInstanceProvider()
        {
        }

        public string StudyFolderPath
        {
            get
            {
                return _studyPath;
            }
            set
            {
                _studyPath = value;
                _series = Directory.GetDirectories(_studyPath);
            }
        }

        public string[] GetAllSeries()
        {
            return _series
                .Select(spath => spath.Split(Path.DirectorySeparatorChar).Last())
                .ToArray();
        }

        public string[] GetSopsInSeries(string Series)
        {
            return Directory.GetFiles(Path.Combine(_studyPath, Series))
                .Select(sop => sop.Split(Path.DirectorySeparatorChar).Last())
                .ToArray();
        }

        public FlyDicmImage GetImage(string SeriesInstanceId, string SopInstanceId)
        {
            return new FlyDicmImage(Path.Combine(_studyPath, SeriesInstanceId, SopInstanceId));
        }

    }
}

/*
 
 Note : Folder Oraganization for Storage
 * + Dicom
 *  ++ StudyInstanceUId
 *      ++ SeriesInstanceUId
 *          ++ SopInstanceUId
 
 
 */