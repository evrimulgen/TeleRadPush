using System;
namespace StudyMover
{
    public interface IStudyInstanceProvider
    {
        string[] GetAllSeries();
        FlyDicmImage GetImage(string SeriesInstanceId, string SopInstanceId);
        string[] GetSopsInSeries(string Series);
        string StudyFolderPath { get; set; }
    }
}
