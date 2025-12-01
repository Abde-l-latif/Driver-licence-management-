namespace DvldProject
{
    partial class NewLdlApp
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTNNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BTNAddPerson = new System.Windows.Forms.Button();
            this.BTNfilterSearch = new System.Windows.Forms.Button();
            this.filterPeople1 = new DvldProject.filterPeople();
            this.personDetails1 = new DvldProject.PersonDetails();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LBdlID = new System.Windows.Forms.Label();
            this.LBCoins = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LBCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.LbDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNsave = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(151, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Local Driving License Application";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 71);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 393);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BTNNext);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.personDetails1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(680, 367);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personel Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BTNNext
            // 
            this.BTNNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BTNNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNNext.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNNext.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNNext.Image = global::DvldProject.Properties.Resources.right;
            this.BTNNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTNNext.Location = new System.Drawing.Point(563, 323);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(81, 38);
            this.BTNNext.TabIndex = 18;
            this.BTNNext.Text = "Next";
            this.BTNNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNNext.UseVisualStyleBackColor = true;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNAddPerson);
            this.groupBox1.Controls.Add(this.BTNfilterSearch);
            this.groupBox1.Controls.Add(this.filterPeople1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.groupBox1.Location = new System.Drawing.Point(34, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // BTNAddPerson
            // 
            this.BTNAddPerson.BackColor = System.Drawing.Color.LightGray;
            this.BTNAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAddPerson.Image = global::DvldProject.Properties.Resources.user__1_1;
            this.BTNAddPerson.Location = new System.Drawing.Point(563, 14);
            this.BTNAddPerson.Name = "BTNAddPerson";
            this.BTNAddPerson.Size = new System.Drawing.Size(36, 32);
            this.BTNAddPerson.TabIndex = 4;
            this.BTNAddPerson.UseVisualStyleBackColor = false;
            this.BTNAddPerson.Click += new System.EventHandler(this.BTNAddPerson_Click);
            // 
            // BTNfilterSearch
            // 
            this.BTNfilterSearch.BackColor = System.Drawing.Color.LightGray;
            this.BTNfilterSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNfilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNfilterSearch.Image = global::DvldProject.Properties.Resources.user__2_;
            this.BTNfilterSearch.Location = new System.Drawing.Point(514, 14);
            this.BTNfilterSearch.Name = "BTNfilterSearch";
            this.BTNfilterSearch.Size = new System.Drawing.Size(36, 32);
            this.BTNfilterSearch.TabIndex = 3;
            this.BTNfilterSearch.UseVisualStyleBackColor = false;
            //this.BTNfilterSearch.Click += new System.EventHandler(this.BTNfilterSearch_Click);
            // 
            // filterPeople1
            // 
            this.filterPeople1.Location = new System.Drawing.Point(7, 14);
            this.filterPeople1.Margin = new System.Windows.Forms.Padding(4);
            this.filterPeople1.Name = "filterPeople1";
            this.filterPeople1.Size = new System.Drawing.Size(596, 32);
            this.filterPeople1.TabIndex = 1;
            // 
            // personDetails1
            // 
            this.personDetails1.Location = new System.Drawing.Point(22, 74);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(634, 250);
            this.personDetails1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Controls.Add(this.pictureBox4);
            this.tabPage2.Controls.Add(this.LBdlID);
            this.tabPage2.Controls.Add(this.LBCoins);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.LBCreatedBy);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.LbDate);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(680, 367);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(213, 138);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(219, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DvldProject.Properties.Resources.id;
            this.pictureBox4.Location = new System.Drawing.Point(178, 136);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 24);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // LBdlID
            // 
            this.LBdlID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBdlID.Image = global::DvldProject.Properties.Resources.block_list2;
            this.LBdlID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LBdlID.Location = new System.Drawing.Point(175, 52);
            this.LBdlID.Name = "LBdlID";
            this.LBdlID.Size = new System.Drawing.Size(77, 26);
            this.LBdlID.TabIndex = 11;
            this.LBdlID.Text = "N/A";
            this.LBdlID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBCoins
            // 
            this.LBCoins.AutoSize = true;
            this.LBCoins.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCoins.Location = new System.Drawing.Point(212, 181);
            this.LBCoins.Name = "LBCoins";
            this.LBCoins.Size = new System.Drawing.Size(0, 17);
            this.LBCoins.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox3.Location = new System.Drawing.Point(178, 177);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // LBCreatedBy
            // 
            this.LBCreatedBy.AutoSize = true;
            this.LBCreatedBy.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBCreatedBy.Location = new System.Drawing.Point(212, 222);
            this.LBCreatedBy.Name = "LBCreatedBy";
            this.LBCreatedBy.Size = new System.Drawing.Size(0, 17);
            this.LBCreatedBy.TabIndex = 8;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DvldProject.Properties.Resources.user__1_;
            this.pictureBox2.Location = new System.Drawing.Point(178, 218);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // LbDate
            // 
            this.LbDate.AutoSize = true;
            this.LbDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDate.Location = new System.Drawing.Point(213, 99);
            this.LbDate.Name = "LbDate";
            this.LbDate.Size = new System.Drawing.Size(0, 17);
            this.LbDate.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.field_date;
            this.pictureBox1.Location = new System.Drawing.Point(178, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(78, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 4;
            this.label6.Text = "Created By  :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Application Fees  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(66, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "License Class  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Application Date  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "D.L.ApplicationID :";
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
            this.BTNsave.Location = new System.Drawing.Point(614, 470);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(81, 38);
            this.BTNsave.TabIndex = 17;
            this.BTNsave.Text = "Save";
            this.BTNsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNsave.UseVisualStyleBackColor = true;
            this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
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
            this.BTNclose.Location = new System.Drawing.Point(497, 470);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 18;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // Form15
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 516);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form15";
            this.Text = "New local Driving License Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private filterPeople filterPeople1;
        private PersonDetails personDetails1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Button BTNAddPerson;
        private System.Windows.Forms.Button BTNfilterSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label LBdlID;
        private System.Windows.Forms.Label LBCoins;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LBCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}