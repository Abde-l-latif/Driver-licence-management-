namespace DvldProject
{
    partial class LicenseHistory
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
            this.BTNAddPerson = new System.Windows.Forms.Button();
            this.BTNfilterSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbRecord = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridLocal = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.BTNclose = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridInternational = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.personDetails1 = new DvldProject.PersonDetails();
            this.filterPeople1 = new DvldProject.filterPeople();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocal)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInternational)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(356, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // BTNAddPerson
            // 
            this.BTNAddPerson.BackColor = System.Drawing.Color.LightGray;
            this.BTNAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNAddPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAddPerson.Image = global::DvldProject.Properties.Resources.user__1_1;
            this.BTNAddPerson.Location = new System.Drawing.Point(661, 15);
            this.BTNAddPerson.Name = "BTNAddPerson";
            this.BTNAddPerson.Size = new System.Drawing.Size(36, 32);
            this.BTNAddPerson.TabIndex = 2;
            this.BTNAddPerson.UseVisualStyleBackColor = false;
            this.BTNAddPerson.Click += new System.EventHandler(this.BTNAddPerson_Click);
            // 
            // BTNfilterSearch
            // 
            this.BTNfilterSearch.BackColor = System.Drawing.Color.LightGray;
            this.BTNfilterSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNfilterSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNfilterSearch.Image = global::DvldProject.Properties.Resources.user__2_;
            this.BTNfilterSearch.Location = new System.Drawing.Point(619, 15);
            this.BTNfilterSearch.Name = "BTNfilterSearch";
            this.BTNfilterSearch.Size = new System.Drawing.Size(36, 32);
            this.BTNfilterSearch.TabIndex = 1;
            this.BTNfilterSearch.UseVisualStyleBackColor = false;
            //this.BTNfilterSearch.Click += new System.EventHandler(this.BTNfilterSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BTNAddPerson);
            this.groupBox1.Controls.Add(this.BTNfilterSearch);
            this.groupBox1.Controls.Add(this.filterPeople1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(210, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.history;
            this.pictureBox1.Location = new System.Drawing.Point(23, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 164);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbRecord);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Location = new System.Drawing.Point(20, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(899, 220);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver Licenses";
            // 
            // LbRecord
            // 
            this.LbRecord.AutoSize = true;
            this.LbRecord.ForeColor = System.Drawing.Color.Maroon;
            this.LbRecord.Location = new System.Drawing.Point(17, 197);
            this.LbRecord.Name = "LbRecord";
            this.LbRecord.Size = new System.Drawing.Size(56, 17);
            this.LbRecord.TabIndex = 1;
            this.LbRecord.Text = "Records";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(870, 172);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridLocal);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(862, 142);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridLocal
            // 
            this.dataGridLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLocal.Location = new System.Drawing.Point(22, 29);
            this.dataGridLocal.Name = "dataGridLocal";
            this.dataGridLocal.Size = new System.Drawing.Size(834, 107);
            this.dataGridLocal.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local Licenses History :";
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
            this.BTNclose.Location = new System.Drawing.Point(839, 638);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 29);
            this.BTNclose.TabIndex = 15;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridInternational);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(862, 142);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "International";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridInternational
            // 
            this.dataGridInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInternational.Location = new System.Drawing.Point(16, 27);
            this.dataGridInternational.Name = "dataGridInternational";
            this.dataGridInternational.Size = new System.Drawing.Size(834, 107);
            this.dataGridInternational.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "International Licenses History :";
            // 
            // personDetails1
            // 
            this.personDetails1.Location = new System.Drawing.Point(197, 104);
            this.personDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(738, 314);
            this.personDetails1.TabIndex = 3;
            // 
            // filterPeople1
            // 
            this.filterPeople1.Location = new System.Drawing.Point(8, 15);
            this.filterPeople1.Margin = new System.Windows.Forms.Padding(5);
            this.filterPeople1.Name = "filterPeople1";
            this.filterPeople1.Size = new System.Drawing.Size(557, 35);
            this.filterPeople1.TabIndex = 0;
            // 
            // LicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 673);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.personDetails1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LicenseHistory";
            this.Text = "LicenseHistory";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLocal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInternational)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNAddPerson;
        private System.Windows.Forms.Button BTNfilterSearch;
        private filterPeople filterPeople1;
        private System.Windows.Forms.GroupBox groupBox1;
        private PersonDetails personDetails1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LbRecord;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridInternational;
        private System.Windows.Forms.Label label2;
    }
}