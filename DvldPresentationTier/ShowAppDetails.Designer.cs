namespace DvldProject
{
    partial class ShowAppDetails
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.appDetails1 = new DvldProject.AppDetails();
            this.BTNclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.appDetails1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(11, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 205);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application basic information";
            // 
            // appDetails1
            // 
            this.appDetails1.Location = new System.Drawing.Point(9, 21);
            this.appDetails1.Margin = new System.Windows.Forms.Padding(4);
            this.appDetails1.Name = "appDetails1";
            this.appDetails1.Size = new System.Drawing.Size(595, 173);
            this.appDetails1.TabIndex = 0;
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
            this.BTNclose.Location = new System.Drawing.Point(555, 253);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 29;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(206, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 28);
            this.label1.TabIndex = 30;
            this.label1.Text = "Application Details ";
            // 
            // ShowAppDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 297);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ShowAppDetails";
            this.Text = "ShowAppDetails";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private AppDetails appDetails1;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Label label1;
    }
}