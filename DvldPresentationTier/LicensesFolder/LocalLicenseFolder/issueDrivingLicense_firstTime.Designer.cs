namespace DvldProject
{
    partial class issueDrivingLicense_firstTime
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
            this.textNote = new System.Windows.Forms.TextBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BTNclose = new System.Windows.Forms.Button();
            this.BTNsave = new System.Windows.Forms.Button();
            this.ldLapplicationInfo1 = new DvldProject.LDLapplicationInfo();
            this.appDetails1 = new DvldProject.AppDetails();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textNote
            // 
            this.textNote.Location = new System.Drawing.Point(124, 377);
            this.textNote.Multiline = true;
            this.textNote.Name = "textNote";
            this.textNote.Size = new System.Drawing.Size(587, 106);
            this.textNote.TabIndex = 35;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::DvldProject.Properties.Resources.register;
            this.pictureBox9.Location = new System.Drawing.Point(90, 377);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(28, 23);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 34;
            this.pictureBox9.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(35, 378);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 33;
            this.label11.Text = "Note  : ";
            // 
            // BTNclose
            // 
            this.BTNclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BTNclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNclose.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNclose.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNclose.Image = global::DvldProject.Properties.Resources.close2;
            this.BTNclose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNclose.Location = new System.Drawing.Point(529, 493);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 31);
            this.BTNclose.TabIndex = 36;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // BTNsave
            // 
            this.BTNsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BTNsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNsave.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNsave.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNsave.Image = global::DvldProject.Properties.Resources.diskette;
            this.BTNsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNsave.Location = new System.Drawing.Point(630, 493);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(81, 31);
            this.BTNsave.TabIndex = 37;
            this.BTNsave.Text = "Save";
            this.BTNsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNsave.UseVisualStyleBackColor = true;
            this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
            // 
            // ldLapplicationInfo1
            // 
            this.ldLapplicationInfo1.Location = new System.Drawing.Point(3, 13);
            this.ldLapplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ldLapplicationInfo1.Name = "ldLapplicationInfo1";
            this.ldLapplicationInfo1.Size = new System.Drawing.Size(743, 129);
            this.ldLapplicationInfo1.TabIndex = 38;
            // 
            // appDetails1
            // 
            this.appDetails1.Location = new System.Drawing.Point(20, 20);
            this.appDetails1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appDetails1.Name = "appDetails1";
            this.appDetails1.Size = new System.Drawing.Size(688, 175);
            this.appDetails1.TabIndex = 39;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.appDetails1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(8, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 204);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application information";
            // 
            // issueDrivingLicense_firstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ldLapplicationInfo1);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.textNote);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "issueDrivingLicense_firstTime";
            this.Text = "issue Driving License firstTime";
            this.Load += new System.EventHandler(this.issueDrivingLicense_firstTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textNote;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Button BTNsave;
        private LDLapplicationInfo ldLapplicationInfo1;
        private AppDetails appDetails1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}