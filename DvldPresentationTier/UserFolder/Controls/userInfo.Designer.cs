namespace DvldProject
{
    partial class userInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtID = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.Label();
            this.TxtActive = new System.Windows.Forms.Label();
            this.personDetails1 = new DvldProject.PersonDetails();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(160, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Is Active : ";
            // 
            // TxtID
            // 
            this.TxtID.AutoSize = true;
            this.TxtID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtID.Location = new System.Drawing.Point(85, 29);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(0, 19);
            this.TxtID.TabIndex = 3;
            // 
            // TxtUserName
            // 
            this.TxtUserName.AutoSize = true;
            this.TxtUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtUserName.Location = new System.Drawing.Point(247, 29);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(0, 19);
            this.TxtUserName.TabIndex = 4;
            // 
            // TxtActive
            // 
            this.TxtActive.AutoSize = true;
            this.TxtActive.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtActive.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TxtActive.Location = new System.Drawing.Point(420, 29);
            this.TxtActive.Name = "TxtActive";
            this.TxtActive.Size = new System.Drawing.Size(0, 19);
            this.TxtActive.TabIndex = 5;
            // 
            // personDetails1
            // 
            this.personDetails1.Location = new System.Drawing.Point(0, 1);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(633, 246);
            this.personDetails1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtActive);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtUserName);
            this.groupBox1.Controls.Add(this.TxtID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(11, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 67);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Information";
            // 
            // userInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.personDetails1);
            this.Name = "userInfo";
            this.Size = new System.Drawing.Size(634, 322);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label TxtID;
        private System.Windows.Forms.Label TxtUserName;
        private System.Windows.Forms.Label TxtActive;
        private PersonDetails personDetails1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
