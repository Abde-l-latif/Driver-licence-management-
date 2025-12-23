namespace DvldProject
{
    partial class ReleaseDetainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.LicenseInfo = new System.Windows.Forms.LinkLabel();
            this.LicenseHistory = new System.Windows.Forms.LinkLabel();
            this.ReleaseBTN = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.LbTotalFees = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LbAppFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LbAppID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbFineFees = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LBLicenseID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.detainDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.detainID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.licenseDetailsFilter1 = new DvldProject.LicensesFolder.Controles.LicenseDetailsFilter();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(260, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Release Detained License";
            // 
            // LicenseInfo
            // 
            this.LicenseInfo.AutoSize = true;
            this.LicenseInfo.Location = new System.Drawing.Point(178, 650);
            this.LicenseInfo.Name = "LicenseInfo";
            this.LicenseInfo.Size = new System.Drawing.Size(139, 17);
            this.LicenseInfo.TabIndex = 43;
            this.LicenseInfo.TabStop = true;
            this.LicenseInfo.Text = "Show new License Info";
            this.LicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseInfo_LinkClicked);
            // 
            // LicenseHistory
            // 
            this.LicenseHistory.AutoSize = true;
            this.LicenseHistory.Location = new System.Drawing.Point(15, 650);
            this.LicenseHistory.Name = "LicenseHistory";
            this.LicenseHistory.Size = new System.Drawing.Size(130, 17);
            this.LicenseHistory.TabIndex = 42;
            this.LicenseHistory.TabStop = true;
            this.LicenseHistory.Text = "Show License History";
            this.LicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseHistory_LinkClicked);
            // 
            // ReleaseBTN
            // 
            this.ReleaseBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReleaseBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ReleaseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReleaseBTN.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReleaseBTN.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ReleaseBTN.Image = global::DvldProject.Properties.Resources.hand;
            this.ReleaseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReleaseBTN.Location = new System.Drawing.Point(696, 653);
            this.ReleaseBTN.Name = "ReleaseBTN";
            this.ReleaseBTN.Size = new System.Drawing.Size(93, 30);
            this.ReleaseBTN.TabIndex = 41;
            this.ReleaseBTN.Text = "Release";
            this.ReleaseBTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ReleaseBTN.UseVisualStyleBackColor = true;
            this.ReleaseBTN.Click += new System.EventHandler(this.ReleaseBTN_Click);
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
            this.BTNclose.Location = new System.Drawing.Point(589, 653);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 30);
            this.BTNclose.TabIndex = 40;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LbTotalFees);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.LbAppFees);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.LbAppID);
            this.groupBox3.Controls.Add(this.pictureBox4);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lbFineFees);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.LbCreatedBy);
            this.groupBox3.Controls.Add(this.pictureBox10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.LBLicenseID);
            this.groupBox3.Controls.Add(this.pictureBox8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.detainDate);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.detainID);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(9, 501);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 133);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Release Information";
            // 
            // LbTotalFees
            // 
            this.LbTotalFees.AutoSize = true;
            this.LbTotalFees.ForeColor = System.Drawing.Color.Black;
            this.LbTotalFees.Location = new System.Drawing.Point(163, 107);
            this.LbTotalFees.Name = "LbTotalFees";
            this.LbTotalFees.Size = new System.Drawing.Size(0, 17);
            this.LbTotalFees.TabIndex = 86;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox5.Location = new System.Drawing.Point(136, 105);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(21, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 85;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(52, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 84;
            this.label9.Text = "Total Fees :";
            // 
            // LbAppFees
            // 
            this.LbAppFees.AutoSize = true;
            this.LbAppFees.ForeColor = System.Drawing.Color.Black;
            this.LbAppFees.Location = new System.Drawing.Point(163, 80);
            this.LbAppFees.Name = "LbAppFees";
            this.LbAppFees.Size = new System.Drawing.Size(0, 17);
            this.LbAppFees.TabIndex = 83;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox2.Location = new System.Drawing.Point(136, 78);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 82;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 81;
            this.label6.Text = "Application Fees :";
            // 
            // LbAppID
            // 
            this.LbAppID.AutoSize = true;
            this.LbAppID.ForeColor = System.Drawing.Color.Black;
            this.LbAppID.Location = new System.Drawing.Point(506, 107);
            this.LbAppID.Name = "LbAppID";
            this.LbAppID.Size = new System.Drawing.Size(0, 17);
            this.LbAppID.TabIndex = 80;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DvldProject.Properties.Resources.serial_number;
            this.pictureBox4.Location = new System.Drawing.Point(477, 105);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 21);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 79;
            this.pictureBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(371, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 78;
            this.label8.Text = "Application ID :";
            // 
            // lbFineFees
            // 
            this.lbFineFees.AutoSize = true;
            this.lbFineFees.ForeColor = System.Drawing.Color.Black;
            this.lbFineFees.Location = new System.Drawing.Point(503, 78);
            this.lbFineFees.Name = "lbFineFees";
            this.lbFineFees.Size = new System.Drawing.Size(0, 17);
            this.lbFineFees.TabIndex = 77;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox1.Location = new System.Drawing.Point(476, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(403, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 75;
            this.label3.Text = "Fine Fees :";
            // 
            // LbCreatedBy
            // 
            this.LbCreatedBy.AutoSize = true;
            this.LbCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.LbCreatedBy.Location = new System.Drawing.Point(505, 49);
            this.LbCreatedBy.Name = "LbCreatedBy";
            this.LbCreatedBy.Size = new System.Drawing.Size(0, 17);
            this.LbCreatedBy.TabIndex = 70;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DvldProject.Properties.Resources.user__111_;
            this.pictureBox10.Location = new System.Drawing.Point(476, 47);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(21, 21);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 69;
            this.pictureBox10.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(394, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 17);
            this.label15.TabIndex = 68;
            this.label15.Text = "Created By :";
            // 
            // LBLicenseID
            // 
            this.LBLicenseID.AutoSize = true;
            this.LBLicenseID.ForeColor = System.Drawing.Color.Black;
            this.LBLicenseID.Location = new System.Drawing.Point(503, 21);
            this.LBLicenseID.Name = "LBLicenseID";
            this.LBLicenseID.Size = new System.Drawing.Size(0, 17);
            this.LBLicenseID.TabIndex = 67;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DvldProject.Properties.Resources.serial_number;
            this.pictureBox8.Location = new System.Drawing.Point(476, 18);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(21, 21);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 66;
            this.pictureBox8.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(397, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 17);
            this.label11.TabIndex = 65;
            this.label11.Text = "License ID :";
            // 
            // detainDate
            // 
            this.detainDate.AutoSize = true;
            this.detainDate.ForeColor = System.Drawing.Color.Black;
            this.detainDate.Location = new System.Drawing.Point(167, 51);
            this.detainDate.Name = "detainDate";
            this.detainDate.Size = new System.Drawing.Size(0, 17);
            this.detainDate.TabIndex = 49;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DvldProject.Properties.Resources.field_date;
            this.pictureBox6.Location = new System.Drawing.Point(138, 49);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(21, 21);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 48;
            this.pictureBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(41, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Detain Date :";
            // 
            // detainID
            // 
            this.detainID.AutoSize = true;
            this.detainID.ForeColor = System.Drawing.Color.Black;
            this.detainID.Location = new System.Drawing.Point(167, 24);
            this.detainID.Name = "detainID";
            this.detainID.Size = new System.Drawing.Size(0, 17);
            this.detainID.TabIndex = 46;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DvldProject.Properties.Resources.serial_number;
            this.pictureBox3.Location = new System.Drawing.Point(138, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(21, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 45;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Detain ID :";
            // 
            // licenseDetailsFilter1
            // 
            this.licenseDetailsFilter1.FilterLicense = true;
            this.licenseDetailsFilter1.Location = new System.Drawing.Point(1, 34);
            this.licenseDetailsFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.licenseDetailsFilter1.Name = "licenseDetailsFilter1";
            this.licenseDetailsFilter1.Size = new System.Drawing.Size(794, 468);
            this.licenseDetailsFilter1.TabIndex = 44;
            this.licenseDetailsFilter1.onSelectedLicenseID += new System.Action<int>(this.licenseDetailsFilter1_onSelectedLicenseID);
            // 
            // ReleaseDetainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 687);
            this.Controls.Add(this.licenseDetailsFilter1);
            this.Controls.Add(this.LicenseInfo);
            this.Controls.Add(this.LicenseHistory);
            this.Controls.Add(this.ReleaseBTN);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReleaseDetainForm";
            this.Text = "ReleaseDetainForm";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LicenseInfo;
        private System.Windows.Forms.LinkLabel LicenseHistory;
        private System.Windows.Forms.Button ReleaseBTN;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LBLicenseID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label detainDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label detainID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbTotalFees;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbAppFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LbAppID;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbFineFees;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private LicensesFolder.Controles.LicenseDetailsFilter licenseDetailsFilter1;
    }
}