namespace DvldProject
{
    partial class ShowLicenseInfo
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
            this.BTNclose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.licenseDetailsControle1 = new DvldProject.LicenseDetailsControle();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(250, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Driver License Information";
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
            this.BTNclose.Location = new System.Drawing.Point(703, 545);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 28;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.id_check;
            this.pictureBox1.Location = new System.Drawing.Point(340, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // licenseDetailsControle1
            // 
            this.licenseDetailsControle1.Location = new System.Drawing.Point(1, 138);
            this.licenseDetailsControle1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.licenseDetailsControle1.Name = "licenseDetailsControle1";
            this.licenseDetailsControle1.Size = new System.Drawing.Size(792, 405);
            this.licenseDetailsControle1.TabIndex = 29;
            // 
            // ShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 587);
            this.Controls.Add(this.licenseDetailsControle1);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShowLicenseInfo";
            this.Text = "ShowLicenseInfo";
            this.Load += new System.EventHandler(this.ShowLicenseInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BTNclose;
        private LicenseDetailsControle licenseDetailsControle1;
    }
}