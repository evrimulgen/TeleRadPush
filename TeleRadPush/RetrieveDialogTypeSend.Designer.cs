using System;
namespace TeleRadPush
{
    partial class RetrieveDialogTypeSend
    {
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetrieveDialogTypeSend));
            this.btnSend = new System.Windows.Forms.Button();
            this.Retrieve = new System.Windows.Forms.Button();
            this.Tree = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_DateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.rdToday = new System.Windows.Forms.RadioButton();
            this.rdDate = new System.Windows.Forms.RadioButton();
            this.rdYestday = new System.Windows.Forms.RadioButton();
            this.ColorDialog1 = new System.Windows.Forms.ColorDialog();
            this.PatientStudyView = new TeleRadPush.DicomServerDBDataSet1();
            this.PatientStudyViewTableAdapter = new TeleRadPush.DicomServerDBDataSet1TableAdapters.PatientStudyViewTableAdapter();
            this.PatientStudyViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatientStudyView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientStudyViewBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSend.Location = new System.Drawing.Point(107, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 42);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Retrieve
            // 
            this.Retrieve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Retrieve.Location = new System.Drawing.Point(3, 3);
            this.Retrieve.Name = "Retrieve";
            this.Retrieve.Size = new System.Drawing.Size(98, 42);
            this.Retrieve.TabIndex = 2;
            this.Retrieve.Text = "View";
            this.Retrieve.UseVisualStyleBackColor = true;
            this.Retrieve.Click += new System.EventHandler(this.Retrieve_Click);
            // 
            // Tree
            // 
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.FullRowSelect = true;
            this.Tree.Location = new System.Drawing.Point(223, 3);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(573, 620);
            this.Tree.TabIndex = 2;
            this.Tree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.Tree_AfterExpand);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Controls.Add(this.Retrieve, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnSend, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(208, 48);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(817, 657);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(805, 645);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modality Study List";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_DateTo);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.rdToday);
            this.groupBox1.Controls.Add(this.rdDate);
            this.groupBox1.Controls.Add(this.rdYestday);
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 202);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(100, 158);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 28);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Retrive";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "From Date";
            // 
            // dtp_DateTo
            // 
            this.dtp_DateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_DateTo.Location = new System.Drawing.Point(84, 132);
            this.dtp_DateTo.Name = "dtp_DateTo";
            this.dtp_DateTo.Size = new System.Drawing.Size(107, 20);
            this.dtp_DateTo.TabIndex = 25;
            this.dtp_DateTo.Value = new System.DateTime(2013, 3, 15, 0, 0, 0, 0);
            this.dtp_DateTo.ValueChanged += new System.EventHandler(this.dtp_DateTo_ValueChanged);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(84, 106);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(107, 20);
            this.dtpDateFrom.TabIndex = 24;
            this.dtpDateFrom.Value = new System.DateTime(2013, 3, 15, 0, 0, 0, 0);
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // rdToday
            // 
            this.rdToday.AutoSize = true;
            this.rdToday.Location = new System.Drawing.Point(16, 30);
            this.rdToday.Name = "rdToday";
            this.rdToday.Size = new System.Drawing.Size(62, 17);
            this.rdToday.TabIndex = 3;
            this.rdToday.TabStop = true;
            this.rdToday.Text = "ToDay";
            this.rdToday.UseVisualStyleBackColor = true;
            this.rdToday.CheckedChanged += new System.EventHandler(this.rdToday_CheckedChanged);
            // 
            // rdDate
            // 
            this.rdDate.AutoSize = true;
            this.rdDate.Location = new System.Drawing.Point(16, 77);
            this.rdDate.Name = "rdDate";
            this.rdDate.Size = new System.Drawing.Size(70, 17);
            this.rdDate.TabIndex = 5;
            this.rdDate.TabStop = true;
            this.rdDate.Text = "By Date";
            this.rdDate.UseVisualStyleBackColor = true;
            this.rdDate.CheckedChanged += new System.EventHandler(this.rdDate_CheckedChanged);
            // 
            // rdYestday
            // 
            this.rdYestday.AutoSize = true;
            this.rdYestday.Location = new System.Drawing.Point(16, 53);
            this.rdYestday.Name = "rdYestday";
            this.rdYestday.Size = new System.Drawing.Size(83, 17);
            this.rdYestday.TabIndex = 4;
            this.rdYestday.TabStop = true;
            this.rdYestday.Text = "YesterDay";
            this.rdYestday.UseVisualStyleBackColor = true;
            this.rdYestday.CheckedChanged += new System.EventHandler(this.rdYestday_CheckedChanged);
            // 
            // PatientStudyView
            // 
            this.PatientStudyView.DataSetName = "DicomServerDBDataSet1";
            this.PatientStudyView.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PatientStudyViewTableAdapter
            // 
            this.PatientStudyViewTableAdapter.ClearBeforeFill = true;
            // 
            // PatientStudyViewBindingSource
            // 
            this.PatientStudyViewBindingSource.DataMember = "PatientStudyView";
            this.PatientStudyViewBindingSource.DataSource = this.PatientStudyView;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Tree, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(799, 626);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(214, 620);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // RetrieveDialogTypeSend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 657);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RetrieveDialogTypeSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient Study";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RetrieveDialogTypeSend_FormClosing);
            this.Load += new System.EventHandler(this.RetrieveDialogTypeSend_Load);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatientStudyView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatientStudyViewBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal TeleRadPush.DicomServerDBDataSetTableAdapters.UserMasterTableAdapter PatientStudyViewTableAdapter_Today;
        private System.Windows.Forms.Button btnSend;
        public System.Windows.Forms.Button Retrieve;
        internal System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ColorDialog ColorDialog1;
        internal DicomServerDBDataSet1 PatientStudyView;
        internal DicomServerDBDataSet1TableAdapters.PatientStudyViewTableAdapter PatientStudyViewTableAdapter;
        internal System.Windows.Forms.BindingSource PatientStudyViewBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdToday;
        private System.Windows.Forms.RadioButton rdDate;
        private System.Windows.Forms.RadioButton rdYestday;
        private System.Windows.Forms.DateTimePicker dtp_DateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}