using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dicom.Imaging;
using System.Drawing;

namespace StudyMover
{
    public class FlyDicmImage
    {
        private string BasePath = System.IO.Path.GetFullPath("./Temp");
        private string _DicomFilePath;
        private DicomImage _dicomimage;

        public FlyDicmImage(string FullFileName)
        {
            _DicomFilePath = FullFileName;
        }

        public string FilePath { get { return _DicomFilePath; } }

        public Image GetImage(int Frame = 0)
        {
            return _dcmImage.RenderImage(Frame);
        }

        public int NumberOfFrame
        {
            get
            {
                return _dcmImage.NumberOfFrames;
            }
        }

        private DicomImage _dcmImage
        {
            get
            {
                if (_dicomimage == null)
                    return new DicomImage(Dicom.DicomFile.Open(_DicomFilePath).Dataset);
                else
                    return _dicomimage;
            }
        }

    }

}
