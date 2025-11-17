namespace DvldProject
{
    partial class UpdateAppTypeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.textCoins = new System.Windows.Forms.TextBox();
            this.BTNsave = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Update Application Types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "ID : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Title : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fees : ";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelID.ForeColor = System.Drawing.Color.Maroon;
            this.labelID.Location = new System.Drawing.Point(103, 59);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(0, 17);
            this.labelID.TabIndex = 17;
            // 
            // textTitle
            // 
            this.textTitle.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitle.Location = new System.Drawing.Point(103, 86);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(270, 21);
            this.textTitle.TabIndex = 18;
            // 
            // textCoins
            // 
            this.textCoins.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCoins.Location = new System.Drawing.Point(103, 115);
            this.textCoins.Name = "textCoins";
            this.textCoins.Size = new System.Drawing.Size(114, 21);
            this.textCoins.TabIndex = 19;
            this.textCoins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCoins_KeyPress);
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
            this.BTNsave.Location = new System.Drawing.Point(292, 150);
            this.BTNsave.Name = "BTNsave";
            this.BTNsave.Size = new System.Drawing.Size(81, 38);
            this.BTNsave.TabIndex = 15;
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
            this.BTNclose.Location = new System.Drawing.Point(149, 150);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 16;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.coins;
            this.pictureBox1.Location = new System.Drawing.Point(73, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DvldProject.Properties.Resources.title;
            this.pictureBox2.Location = new System.Drawing.Point(73, 81);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // UpdateAppTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 191);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textCoins);
            this.Controls.Add(this.textTitle);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "UpdateAppTypeForm";
            this.Text = "Update app type";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.TextBox textCoins;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}