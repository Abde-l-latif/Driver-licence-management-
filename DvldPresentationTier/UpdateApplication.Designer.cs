namespace DvldProject
{
    partial class UpdateApplication
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
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNsave = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.labelID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DvldProject.Properties.Resources.field_date;
            this.pictureBox3.Location = new System.Drawing.Point(101, 98);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 37;
            this.label5.Text = "Date : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 28);
            this.label1.TabIndex = 35;
            this.label1.Text = "Update Application Date";
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
            this.BTNsave.Location = new System.Drawing.Point(327, 150);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(81, 38);
            this.BTNsave.TabIndex = 39;
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
            this.BTNclose.Location = new System.Drawing.Point(184, 150);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 40;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Maroon;
            this.labelID.Location = new System.Drawing.Point(120, 70);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 17);
            this.labelID.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 41;
            this.label2.Text = "ID : ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(139, 105);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 43;
            // 
            // UpdateApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 197);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "UpdateApplication";
            this.Text = "UpdateApplication";
            this.Load += new System.EventHandler(this.UpdateApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}