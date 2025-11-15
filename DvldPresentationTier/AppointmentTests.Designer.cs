namespace DvldProject
{
    partial class AppointmentTests
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
            this.Title = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ldLapplicationInfo1 = new DvldProject.LDLapplicationInfo();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.appDetails1 = new DvldProject.AppDetails();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelRecord = new System.Windows.Forms.Label();
            this.pictureAddPerson = new System.Windows.Forms.PictureBox();
            this.BTNclose = new System.Windows.Forms.Button();
            this.pictureTitle = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Title.Location = new System.Drawing.Point(207, 75);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(273, 27);
            this.Title.TabIndex = 6;
            this.Title.Text = "Vision Test Appointments";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ldLapplicationInfo1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(10, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 138);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driving License Application Information";
            // 
            // ldLapplicationInfo1
            // 
            this.ldLapplicationInfo1.Location = new System.Drawing.Point(16, 20);
            this.ldLapplicationInfo1.Margin = new System.Windows.Forms.Padding(4);
            this.ldLapplicationInfo1.Name = "ldLapplicationInfo1";
            this.ldLapplicationInfo1.Size = new System.Drawing.Size(642, 109);
            this.ldLapplicationInfo1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.appDetails1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(8, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(677, 205);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application basic information";
            // 
            // appDetails1
            // 
            this.appDetails1.Location = new System.Drawing.Point(9, 21);
            this.appDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.appDetails1.Name = "appDetails1";
            this.appDetails1.Size = new System.Drawing.Size(661, 173);
            this.appDetails1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 469);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Appointments";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(10, 503);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(675, 126);
            this.dataGridView1.TabIndex = 24;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 64);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DvldProject.Properties.Resources.script_editor;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DvldProject.Properties.Resources.auto_correct_config__1_;
            this.takeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(128, 30);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.ForeColor = System.Drawing.Color.Maroon;
            this.labelRecord.Location = new System.Drawing.Point(14, 637);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(56, 17);
            this.labelRecord.TabIndex = 25;
            this.labelRecord.Text = "Records";
            // 
            // pictureAddPerson
            // 
            this.pictureAddPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureAddPerson.Image = global::DvldProject.Properties.Resources.date_add;
            this.pictureAddPerson.Location = new System.Drawing.Point(643, 460);
            this.pictureAddPerson.Name = "pictureAddPerson";
            this.pictureAddPerson.Size = new System.Drawing.Size(42, 37);
            this.pictureAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAddPerson.TabIndex = 23;
            this.pictureAddPerson.TabStop = false;
            this.pictureAddPerson.Click += new System.EventHandler(this.pictureAddPerson_Click);
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
            this.BTNclose.Location = new System.Drawing.Point(604, 635);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 18;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // pictureTitle
            // 
            this.pictureTitle.Image = global::DvldProject.Properties.Resources.eye2;
            this.pictureTitle.Location = new System.Drawing.Point(293, 12);
            this.pictureTitle.Name = "pictureTitle";
            this.pictureTitle.Size = new System.Drawing.Size(99, 60);
            this.pictureTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureTitle.TabIndex = 5;
            this.pictureTitle.TabStop = false;
            // 
            // AppointmentTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 677);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureAddPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureTitle);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppointmentTests";
            this.Text = "Vision test appointment";
            this.Load += new System.EventHandler(this.Form16_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureTitle;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.GroupBox groupBox1;
        private LDLapplicationInfo ldLapplicationInfo1;
        private System.Windows.Forms.GroupBox groupBox2;
        private AppDetails appDetails1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureAddPerson;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}