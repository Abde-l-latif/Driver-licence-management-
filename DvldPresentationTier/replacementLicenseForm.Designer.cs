namespace DvldProject
{
    partial class replacementLicenseForm
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioLost = new System.Windows.Forms.RadioButton();
            this.radioDamaged = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureGetLicenseInfo = new System.Windows.Forms.PictureBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.licenseDetailsControle1 = new DvldProject.LicenseDetailsControle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AppFees = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AppDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.LRAppID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.LBoldLicenseID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.LBreplacedLicenseID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.LicenseInfo = new System.Windows.Forms.LinkLabel();
            this.LicenseHistory = new System.Windows.Forms.LinkLabel();
            this.IssueBTN = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGetLicenseInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LbTitle.Location = new System.Drawing.Point(190, 9);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(403, 28);
            this.LbTitle.TabIndex = 5;
            this.LbTitle.Text = "Replacement for Damaged License";
            this.LbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioLost);
            this.groupBox1.Controls.Add(this.radioDamaged);
            this.groupBox1.Location = new System.Drawing.Point(559, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 75);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement for";
            // 
            // radioLost
            // 
            this.radioLost.AutoSize = true;
            this.radioLost.Location = new System.Drawing.Point(16, 46);
            this.radioLost.Name = "radioLost";
            this.radioLost.Size = new System.Drawing.Size(96, 21);
            this.radioLost.TabIndex = 1;
            this.radioLost.Text = "Lost License";
            this.radioLost.UseVisualStyleBackColor = true;
            this.radioLost.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioDamaged
            // 
            this.radioDamaged.AutoSize = true;
            this.radioDamaged.Checked = true;
            this.radioDamaged.Location = new System.Drawing.Point(16, 19);
            this.radioDamaged.Name = "radioDamaged";
            this.radioDamaged.Size = new System.Drawing.Size(129, 21);
            this.radioDamaged.TabIndex = 0;
            this.radioDamaged.TabStop = true;
            this.radioDamaged.Text = "Damaged License";
            this.radioDamaged.UseVisualStyleBackColor = true;
            this.radioDamaged.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureGetLicenseInfo);
            this.groupBox2.Controls.Add(this.txtLicenseID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 76);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // pictureGetLicenseInfo
            // 
            this.pictureGetLicenseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureGetLicenseInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureGetLicenseInfo.Image = global::DvldProject.Properties.Resources.id_check__1_;
            this.pictureGetLicenseInfo.Location = new System.Drawing.Point(480, 22);
            this.pictureGetLicenseInfo.Name = "pictureGetLicenseInfo";
            this.pictureGetLicenseInfo.Size = new System.Drawing.Size(48, 40);
            this.pictureGetLicenseInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureGetLicenseInfo.TabIndex = 31;
            this.pictureGetLicenseInfo.TabStop = false;
            this.pictureGetLicenseInfo.Click += new System.EventHandler(this.pictureGetLicenseInfo_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(109, 30);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(207, 23);
            this.txtLicenseID.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "License Id :";
            // 
            // licenseDetailsControle1
            // 
            this.licenseDetailsControle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseDetailsControle1.Location = new System.Drawing.Point(8, 117);
            this.licenseDetailsControle1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.licenseDetailsControle1.Name = "licenseDetailsControle1";
            this.licenseDetailsControle1.Size = new System.Drawing.Size(794, 381);
            this.licenseDetailsControle1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.LBreplacedLicenseID);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.LbCreatedBy);
            this.groupBox3.Controls.Add(this.pictureBox10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.LBoldLicenseID);
            this.groupBox3.Controls.Add(this.pictureBox8);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.AppFees);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.AppDate);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.LRAppID);
            this.groupBox3.Controls.Add(this.pictureBox3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(13, 495);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(777, 111);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Application information for license replacement";
            // 
            // AppFees
            // 
            this.AppFees.AutoSize = true;
            this.AppFees.ForeColor = System.Drawing.Color.Black;
            this.AppFees.Location = new System.Drawing.Point(167, 78);
            this.AppFees.Name = "AppFees";
            this.AppFees.Size = new System.Drawing.Size(0, 17);
            this.AppFees.TabIndex = 55;
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
            this.label6.Location = new System.Drawing.Point(15, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 53;
            this.label6.Text = "Application Fees :";
            // 
            // AppDate
            // 
            this.AppDate.AutoSize = true;
            this.AppDate.ForeColor = System.Drawing.Color.Black;
            this.AppDate.Location = new System.Drawing.Point(167, 51);
            this.AppDate.Name = "AppDate";
            this.AppDate.Size = new System.Drawing.Size(0, 17);
            this.AppDate.TabIndex = 49;
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
            this.label7.Location = new System.Drawing.Point(13, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Application Date :";
            // 
            // LRAppID
            // 
            this.LRAppID.AutoSize = true;
            this.LRAppID.ForeColor = System.Drawing.Color.Black;
            this.LRAppID.Location = new System.Drawing.Point(167, 24);
            this.LRAppID.Name = "LRAppID";
            this.LRAppID.Size = new System.Drawing.Size(0, 17);
            this.LRAppID.TabIndex = 46;
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
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "L.R Application ID :";
            // 
            // LbCreatedBy
            // 
            this.LbCreatedBy.AutoSize = true;
            this.LbCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.LbCreatedBy.Location = new System.Drawing.Point(505, 78);
            this.LbCreatedBy.Name = "LbCreatedBy";
            this.LbCreatedBy.Size = new System.Drawing.Size(0, 17);
            this.LbCreatedBy.TabIndex = 70;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DvldProject.Properties.Resources.user__111_;
            this.pictureBox10.Location = new System.Drawing.Point(476, 76);
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
            this.label15.Location = new System.Drawing.Point(394, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 17);
            this.label15.TabIndex = 68;
            this.label15.Text = "Created By :";
            // 
            // LBoldLicenseID
            // 
            this.LBoldLicenseID.AutoSize = true;
            this.LBoldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.LBoldLicenseID.Location = new System.Drawing.Point(503, 50);
            this.LBoldLicenseID.Name = "LBoldLicenseID";
            this.LBoldLicenseID.Size = new System.Drawing.Size(0, 17);
            this.LBoldLicenseID.TabIndex = 67;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DvldProject.Properties.Resources.serial_number;
            this.pictureBox8.Location = new System.Drawing.Point(476, 47);
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
            this.label11.Location = new System.Drawing.Point(369, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 65;
            this.label11.Text = "Old License ID :";
            // 
            // LBreplacedLicenseID
            // 
            this.LBreplacedLicenseID.AutoSize = true;
            this.LBreplacedLicenseID.ForeColor = System.Drawing.Color.Black;
            this.LBreplacedLicenseID.Location = new System.Drawing.Point(504, 24);
            this.LBreplacedLicenseID.Name = "LBreplacedLicenseID";
            this.LBreplacedLicenseID.Size = new System.Drawing.Size(0, 17);
            this.LBreplacedLicenseID.TabIndex = 73;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DvldProject.Properties.Resources.id333;
            this.pictureBox5.Location = new System.Drawing.Point(477, 21);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(21, 21);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 72;
            this.pictureBox5.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(336, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 17);
            this.label10.TabIndex = 71;
            this.label10.Text = "Replaced License ID :";
            // 
            // LicenseInfo
            // 
            this.LicenseInfo.AutoSize = true;
            this.LicenseInfo.Location = new System.Drawing.Point(177, 609);
            this.LicenseInfo.Name = "LicenseInfo";
            this.LicenseInfo.Size = new System.Drawing.Size(139, 17);
            this.LicenseInfo.TabIndex = 33;
            this.LicenseInfo.TabStop = true;
            this.LicenseInfo.Text = "Show new License Info";
            this.LicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseInfo_LinkClicked);
            // 
            // LicenseHistory
            // 
            this.LicenseHistory.AutoSize = true;
            this.LicenseHistory.Location = new System.Drawing.Point(14, 609);
            this.LicenseHistory.Name = "LicenseHistory";
            this.LicenseHistory.Size = new System.Drawing.Size(130, 17);
            this.LicenseHistory.TabIndex = 32;
            this.LicenseHistory.TabStop = true;
            this.LicenseHistory.Text = "Show License History";
            this.LicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LicenseHistory_LinkClicked);
            // 
            // IssueBTN
            // 
            this.IssueBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IssueBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.IssueBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IssueBTN.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IssueBTN.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.IssueBTN.Image = global::DvldProject.Properties.Resources.id333;
            this.IssueBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IssueBTN.Location = new System.Drawing.Point(631, 612);
            this.IssueBTN.Name = "IssueBTN";
            this.IssueBTN.Size = new System.Drawing.Size(157, 30);
            this.IssueBTN.TabIndex = 31;
            this.IssueBTN.Text = "issue Replacement";
            this.IssueBTN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IssueBTN.UseVisualStyleBackColor = true;
            this.IssueBTN.Click += new System.EventHandler(this.IssueBTN_Click);
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
            this.BTNclose.Location = new System.Drawing.Point(521, 612);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 30);
            this.BTNclose.TabIndex = 30;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // replacementLicenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 647);
            this.Controls.Add(this.LicenseInfo);
            this.Controls.Add(this.LicenseHistory);
            this.Controls.Add(this.IssueBTN);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.licenseDetailsControle1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LbTitle);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "replacementLicenseForm";
            this.Text = "replacementLicenseForm";
            this.Load += new System.EventHandler(this.replacementLicenseForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureGetLicenseInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioLost;
        private System.Windows.Forms.RadioButton radioDamaged;
        private System.Windows.Forms.PictureBox pictureGetLicenseInfo;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label2;
        private LicenseDetailsControle licenseDetailsControle1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label AppFees;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AppDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LRAppID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LBoldLicenseID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LBreplacedLicenseID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel LicenseInfo;
        private System.Windows.Forms.LinkLabel LicenseHistory;
        private System.Windows.Forms.Button IssueBTN;
        private System.Windows.Forms.Button BTNclose;
    }
}