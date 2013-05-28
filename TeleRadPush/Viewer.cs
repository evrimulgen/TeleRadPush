using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudyMover;

namespace TeleRadPush
{
    public partial class Viewer : Form
    {
        private readonly IStudyInstanceProvider _studyinstProvider;
        private string[] SopIds, seriesIds;
        private FlyDicmImage current_img;

        public Viewer(IStudyInstanceProvider StudyInstanceProvider)
        {
            InitializeComponent();
            _studyinstProvider = StudyInstanceProvider;
        }

        private void Viewer_Load(object sender, EventArgs e)
        {
            _studyinstProvider.StudyFolderPath = StudyFolderPath;
            seriesIds = _studyinstProvider.GetAllSeries();
            comboSeries.DisplayMember = "Text";
            comboSeries.ValueMember = "Value";
            comboSeries.DataSource = seriesIds.Select(series => new { Text = series, Value = series }).ToList();

        }

        // design needs change (not following Design by Contract principle)
        public string StudyFolderPath { get; set; }

        private void comboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            SopIds = _studyinstProvider.GetSopsInSeries(comboSeries.SelectedValue.ToString());
            instancecounter.Maximum = SopIds.Count() - 1;
            current_img = _studyinstProvider.GetImage(comboSeries.SelectedValue.ToString(), SopIds[0]);
            framecounter.Maximum = current_img.NumberOfFrame - 1;
            Instance.Image = current_img.GetImage(0);
        }

        private void instancecounter_ValueChanged(object sender, EventArgs e)
        {
            current_img = _studyinstProvider.GetImage(comboSeries.SelectedValue.ToString(), SopIds[(int)instancecounter.Value]);
            framecounter.Maximum = current_img.NumberOfFrame - 1;
            Instance.Image = current_img.GetImage(0);
        }

        private void framecounter_ValueChanged(object sender, EventArgs e)
        {
            framecounter.Maximum = current_img.NumberOfFrame - 1;
            Instance.Image = current_img.GetImage((int)framecounter.Value);
        }

    }
}
