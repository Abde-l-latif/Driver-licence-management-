namespace DvldProject
{
    partial class DetainLicenseForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureAddInterLicense = new System.Windows.Forms.PictureBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LicenseInfo = new System.Windows.Forms.LinkLabel();
            this.LicenseHistory = new System.Windows.Forms.LinkLabel();
            this.DetainBTN = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textFineFees = new System.Windows.Forms.TextBox();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LBLicenseID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DetainDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.detainID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.licenseDetailsControle1 = new DvldProject.LicenseDetailsControle();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddInterLicense)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureAddInterLicense);
            this.groupBox1.Controls.Add(this.txtLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 45);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // pictureAddInterLicense
            // 
            this.pictureAddInterLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureAddInterLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureAddInterLicense.Image = global::DvldProject.Properties.Resources.id_check__1_;
            this.pictureAddInterLicense.Location = new System.Drawing.Point(439, 11);
            this.pictureAddInterLicense.Name = "pictureAddInterLicense";
            this.pictureAddInterLicense.Size = new System.Drawing.Size(33, 29);
            this.pictureAddInterLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAddInterLicense.TabIndex = 28;
            this.pictureAddInterLicense.TabStop = false;
            this.pictureAddInterLicense.Click += new System.EventHandler(this.pictureAddInterLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(102, 14);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(207, 23);
            this.txtLicenseID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "License Id :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(315, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Detain License";
            // 
            // LicenseInfo
            // 
            this.LicenseInfo.AutoSize = true;
            this.LicenseInfo.Location = new System.Drawing.Point(171, 599);
            this.LicenseInfo.Name = "LicenseInfo";
            this.LicenseInfo.Size = new System.Drawing.Size(139, 17);
            this.LicenseInfo.TabIndex = 38;
            this.LicenseInfo.TabStop = true;
            this.LicenseInfo.Text = "Show new License Info";
            this.LicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseInfo_LinkClicked);
            // 
            // LicenseHistory
            // 
            this.LicenseHistory.AutoSize = true;
            this.LicenseHistory.Location = new System.Drawing.Point(8, 599);
            this.LicenseHistory.Name = "LicenseHistory";
            this.LicenseHistory.Size = new System.Drawing.Size(130, 17);
            this.LicenseHistory.TabIndex = 37;
            this.LicenseHistory.TabStop = true;
            this.LicenseHistory.Text = "Show License History";
            this.LicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseHistory_LinkClicked);
            // 
            // DetainBTN
            // 
            this.DetainBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DetainBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DetainBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetainBTN.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetainBTN.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.DetainBTN.Image = global::DvldProject.Properties.Resources.world;
            this.DetainBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetainBTN.Location = new System.Drawing.Point(700, 602);
            this.DetainBTN.Name = "DetainBTN";
            this.DetainBTN.Size = new System.Drawing.Size(82, 30);
            this.DetainBTN.TabIndex = 36;
            this.DetainBTN.Text = "Detain";
            this.DetainBTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetainBTN.UseVisualStyleBackColor = true;
            this.DetainBTN.Click += new System.EventHandler(this.DetainBTN_Click);
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
            this.BTNclose.Location = new System.Drawing.Point(582, 602);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 30);
            this.BTNclose.TabIndex = 35;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textFineFees);
            this.groupBox3.Controls.Add(this.LbCreatedBy);
            this.groupBox3.Controls.Add(this.pictureBox10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.LBLicenseID);
            this.groupBox3.Controls.Add(this.pictureBox8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.DetainDate);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.detainID);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(7, 485);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 111);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detain Information";
            // 
            // textFineFees
            // 
            this.textFineFees.Location = new System.Drawing.Point(166, 76);
            this.textFineFees.Name = "textFineFees";
            this.textFineFees.Size = new System.Drawing.Size(77, 23);
            this.textFineFees.TabIndex = 74;
            this.textFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFineFees_KeyPress);
            this.textFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.textFineFees_Validating);
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
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox2.Location = new System.Drawing.Point(138, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(21, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 54;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(37, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Fine Fees :";
            // 
            // DetainDate
            // 
            this.DetainDate.AutoSize = true;
            this.DetainDate.ForeColor = System.Drawing.Color.Black;
            this.DetainDate.Location = new System.Drawing.Point(167, 51);
            this.DetainDate.Name = "DetainDate";
            this.DetainDate.Size = new System.Drawing.Size(0, 17);
            this.DetainDate.TabIndex = 49;
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
            this.label7.Location = new System.Drawing.Point(20, 52);
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
            this.label4.Location = new System.Drawing.Point(35, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Detain ID :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // licenseDetailsControle1
            // 
            this.licenseDetailsControle1.Location = new System.Drawing.Point(2, 80);
            this.licenseDetailsControle1.Margin = new System.Windows.Forms.Padding(4);
            this.licenseDetailsControle1.Name = "licenseDetailsControle1";
            this.licenseDetailsControle1.Size = new System.Drawing.Size(791, 408);
            this.licenseDetailsControle1.TabIndex = 0;
            // 
            // DetainLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 635);
            this.Controls.Add(this.LicenseInfo);
            this.Controls.Add(this.LicenseHistory);
            this.Controls.Add(this.DetainBTN);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.licenseDetailsControle1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DetainLicenseForm";
            this.Text = "DetainLicenseForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddInterLicense)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LicenseDetailsControle licenseDetailsControle1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureAddInterLicense;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LicenseInfo;
        private System.Windows.Forms.LinkLabel LicenseHistory;
        private System.Windows.Forms.Button DetainBTN;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textFineFees;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LBLicenseID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label DetainDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label detainID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}