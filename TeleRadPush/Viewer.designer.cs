namespace TeleRadPush
{
    partial class Viewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.framecounter = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.instancecounter = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSeries = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Instance = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.framecounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instancecounter)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Instance)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.framecounter);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.instancecounter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboSeries);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 497);
            this.panel1.TabIndex = 0;
            // 
            // framecounter
            // 
            this.framecounter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.framecounter.Location = new System.Drawing.Point(116, 74);
            this.framecounter.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.framecounter.Name = "framecounter";
            this.framecounter.Size = new System.Drawing.Size(90, 23);
            this.framecounter.TabIndex = 5;
            this.framecounter.ValueChanged += new System.EventHandler(this.framecounter_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Frame";
            // 
            // instancecounter
            // 
            this.instancecounter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instancecounter.Location = new System.Drawing.Point(7, 74);
            this.instancecounter.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.instancecounter.Name = "instancecounter";
            this.instancecounter.Size = new System.Drawing.Size(90, 23);
            this.instancecounter.TabIndex = 3;
            this.instancecounter.ValueChanged += new System.EventHandler(this.instancecounter_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Instance";
            // 
            // comboSeries
            // 
            this.comboSeries.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSeries.FormattingEnabled = true;
            this.comboSeries.Location = new System.Drawing.Point(7, 25);
            this.comboSeries.Name = "comboSeries";
            this.comboSeries.Size = new System.Drawing.Size(200, 23);
            this.comboSeries.TabIndex = 1;
            this.comboSeries.SelectedIndexChanged += new System.EventHandler(this.comboSeries_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.Instance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(222, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(618, 497);
            this.panel2.TabIndex = 1;
            // 
            // Instance
            // 
            this.Instance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Instance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Instance.Location = new System.Drawing.Point(0, 0);
            this.Instance.Name = "Instance";
            this.Instance.Size = new System.Drawing.Size(618, 497);
            this.Instance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Instance.TabIndex = 0;
            this.Instance.TabStop = false;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Viewer";
            this.Text = "Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.framecounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instancecounter)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Instance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown framecounter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown instancecounter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Instance;
    }
}