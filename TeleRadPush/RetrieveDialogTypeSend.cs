using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using Microsoft.VisualBasic;
using System.IO;

namespace TeleRadPush
{
    public partial class RetrieveDialogTypeSend : Form
    {

        private StudyMover.StudyMover SM;
        private DateTime FromDate, ToDate;
        public string Notes = "";
        Myconnectionclass CN = new Myconnectionclass();
        OdbcCommand Cmd;
        OdbcDataReader Rs1;
        public string StID = "";

        public RetrieveDialogTypeSend()
        {
            InitializeComponent();
        }

        private void RetrieveDialogTypeSend_Load(object sender, EventArgs e)
        {
            FromDate = ToDate = DateTime.Now;
            SM = new StudyMover.StudyMover();
            TeleRadPush.modMain.Retreived = false;
            this.Cursor = Cursors.WaitCursor;
            this.PatientStudyViewTableAdapter.Fill(this.PatientStudyView.PatientStudyView);
            FillList();
            this.Cursor = Cursors.Arrow;
        }

        private void Query_Click(object sender, EventArgs e)
        {
            FillList();
        }

        private void FillList()
        {
            try
            {
                Tree.Nodes.Clear();
                List<StudyMover.Study> f = default(List<StudyMover.Study>);
                f = SM.GetStudiesStudyLevel(StudyMover.RetriveEntity.Modality, "", "", FromDate.Date, ToDate.Date, null, null, null, null);
                foreach (StudyMover.Study item in f)
                {
                    TreeNode nd = new TreeNode();
                    nd.Text = item.PatientName + " ( " + item.PatientID + " )";
                    nd.Name = item.PatientID + "*" + item.PatientName;
                    nd.Tag = "study";
                    Tree.Nodes.Add(nd);
                    nd.Nodes.Add("Please wait, while the study list is being retrieved");
                    nd.Collapse();
                }
                return;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "TeleRad - Client", MessageBoxButtons.OK);
            }
        }

        private void Tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            switch ((e.Node.Tag.ToString()))
            {

                case "study":
                    string[] patient = e.Node.Name.Split('*');
                    var q = SM.GetStudiesStudyLevel(StudyMover.RetriveEntity.Modality, patient[0], patient[1], FromDate, ToDate, null, null, null, null);
                    e.Node.Nodes.Clear();
                    foreach (StudyMover.Study item in q)
                    {
                        System.Windows.Forms.TreeNode nd = new TreeNode();

                        nd.Text = item.StudyInstanceUID;
                        nd.Name = item.StudyInstanceUID;
                        nd.Tag = "series";
                        nd.Nodes.Add("Please wait, while the study list is being retrieved");
                        e.Node.Nodes.Add(nd);
                        nd.Collapse();
                    }


                    break;

                case "series":
                    q = SM.GetStudiesSeriesLevel(StudyMover.RetriveEntity.Modality, e.Node.Name, "");
                    e.Node.Nodes.Clear();
                    foreach (StudyMover.Study item in q)
                    {
                        System.Windows.Forms.TreeNode nd = new TreeNode();
                        nd.Text = item.SeriesUID;
                        nd.Name = item.SeriesUID + "*" + item.StudyInstanceUID;
                        nd.Tag = "sopinstance";
                        e.Node.Nodes.Add(nd);
                    }


                    break;
                default:
                    MessageBox.Show("Invalid Level");
                    break;
            }

        }

        private void RetrieveDialogTypeSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Tree.Nodes.Count <= 0)
            {
                MessageBox.Show("No Study to sent", "TeleRad - Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string NodeType = Tree.SelectedNode.Tag.ToString();

            switch ((NodeType))
            {

                case "study":
                    //"PATIENT
                    string[] patient = Tree.SelectedNode.Name.Split('*');
                    List<StudyMover.Study> Studies = SM.GetStudiesStudyLevel(StudyMover.RetriveEntity.Modality, patient[0], patient[1], FromDate, ToDate, "", "", "", "");
                    foreach (StudyMover.Study study in Studies)
                    {
                        SM.SendStudies(StudyMover.RetriveEntity.Modality, study.StudyInstanceUID, "");
                        StID = study.StudyInstanceUID;
                    }

                    break;
                case "series":
                    // "STUDY"

                    SM.SendStudies(StudyMover.RetriveEntity.Modality, Tree.SelectedNode.Name, "");
                    StID = Tree.SelectedNode.Name;
                    break;

                case "sopinstance":
                    // "SERIES"
                    string[] Ids = Tree.SelectedNode.Name.Split('*');
                    SM.SendStudies(StudyMover.RetriveEntity.Modality, Ids[1], Ids[0], "");
                    StID = Ids[1];
                    break;
            }

            InsertNotes();
        }

        private void InsertNotes()
        {
            Notes = Interaction.InputBox("Enter Note:", "TeleRad - Client", " ");

            string strSQL = "";
            string centre = " ";
            Myconnectionclass CN2 = new Myconnectionclass();
            OdbcCommand Cmd2;
            OdbcDataReader Rs2;
            CN2.OpenConnection();
            Cmd2 = new System.Data.Odbc.OdbcCommand("SELECT * from UserMaster WHERE UserName='" + modMain.UID + "'", CN2.DBConnection);
            Rs2 = Cmd2.ExecuteReader();
            if (Rs2.HasRows)
                centre = Rs2["Centre"].ToString();
            Rs2.Close();
            Cmd2.Dispose();
            CN2.closeconnection();

            CN.OpenConnection();
            Cmd = new System.Data.Odbc.OdbcCommand("SELECT * from Reports WHERE StudyUID='" + StID + "'", CN.DBConnection);
            Rs1 = Cmd.ExecuteReader();
            if (Rs1.HasRows)
            {
                if (Notes.Length <= 0)
                    strSQL = "UPDATE Reports SET IsNotes=0, Centre='" + centre + "' WHERE StudyUID='" + StID + "'";
                else
                    strSQL = "UPDATE Reports SET Notes='" + Notes + "', IsNotes=1, Centre='" + centre + "' WHERE StudyUID='" + StID + "'";
            }
            else
            {
                if (Notes.Length <= 0)
                    strSQL = "INSERT INTO Reports (StudyUID, IsNotes,Centre) VALUES ('" + StID + "',1,'" + centre + "')";
                else
                    strSQL = "INSERT INTO Reports (StudyUID, Notes, IsNotes,Centre) VALUES ('" + StID + "', '" + Notes + "', 1,'" + centre + "')";
            }
            Rs1.Close();
            Cmd.Dispose();
            CN.closeconnection();

            CN.OpenConnection();
            Cmd = new System.Data.Odbc.OdbcCommand(strSQL, CN.DBConnection);
            Rs1 = Cmd.ExecuteReader();
            Rs1.Close();
            Cmd.Dispose();
            CN.closeconnection();
            MessageBox.Show("Successfully Sent Study", "TeleRad - Client", MessageBoxButtons.OK);
        }

        private void Retrieve_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode == null || !Tree.SelectedNode.Tag.ToString().Equals("series"))
            {
                MessageBox.Show("Please Select A Study Node from Tree.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Directory.Exists(Environment.CurrentDirectory + "\\DICOM") == true)
                Directory.Delete(Environment.CurrentDirectory + "\\DICOM", true);

            SM.MoveStudies(StudyMover.RetriveEntity.Modality, Tree.SelectedNode.Name);
            Viewer viwer = new Viewer(new StudyMover.StudyInstanceProvider());
            viwer.StudyFolderPath = SM.GetStudyFolderPath(Tree.SelectedNode.Name);
            viwer.Text = "Study - " + Tree.SelectedNode.Name;
            viwer.ShowDialog();
        }

        private void rdToday_CheckedChanged(object sender, EventArgs e)
        {
            if (rdToday.Checked)
            {
                FromDate = DateTime.Now;
                ToDate = DateTime.Now;
            }
        }

        private void rdYestday_CheckedChanged(object sender, EventArgs e)
        {
            if (rdYestday.Checked)
            {
                FromDate = DateTime.Now.AddDays(-1);
                ToDate = DateTime.Now.AddDays(-1);
            }

        }

        private void rdDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDate.Checked)
            {
                FromDate = dtpDateFrom.Value;
                ToDate = dtp_DateTo.Value;
            }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (rdDate.Checked)
            {
                FromDate = dtpDateFrom.Value;
                ToDate = dtp_DateTo.Value;
            }
        }

        private void dtp_DateTo_ValueChanged(object sender, EventArgs e)
        {
            if (rdDate.Checked)
            {
                FromDate = dtpDateFrom.Value;
                ToDate = dtp_DateTo.Value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillList();
        }
    }
}
