namespace DvldProject
{
    partial class AddUpdateUserForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.personDetailsFilter1 = new DvldProject.PeopleFolder.Controls.PersonDetailsFilter();
            this.BTNNext = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.UserIDValue = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textConfirm = new System.Windows.Forms.TextBox();
            this.lb = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.textPassword22 = new System.Windows.Forms.TextBox();
            this.TextPassword = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNsave = new System.Windows.Forms.Button();
            this.BTNclose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(759, 443);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.personDetailsFilter1);
            this.tabPage1.Controls.Add(this.BTNNext);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(751, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personel Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // personDetailsFilter1
            // 
            this.personDetailsFilter1.FilterPerson = true;
            this.personDetailsFilter1.Location = new System.Drawing.Point(6, 3);
            this.personDetailsFilter1.Margin = new System.Windows.Forms.Padding(4);
            this.personDetailsFilter1.Name = "personDetailsFilter1";
            this.personDetailsFilter1.ShowAddPerson = true;
            this.personDetailsFilter1.Size = new System.Drawing.Size(732, 373);
            this.personDetailsFilter1.TabIndex = 18;
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
            this.BTNNext.Location = new System.Drawing.Point(652, 376);
            this.BTNNext.Name = "BTNNext";
            this.BTNNext.Size = new System.Drawing.Size(81, 36);
            this.BTNNext.TabIndex = 17;
            this.BTNNext.Text = "Next";
            this.BTNNext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNNext.UseVisualStyleBackColor = true;
            this.BTNNext.Click += new System.EventHandler(this.BTNNext_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.UserIDValue);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.textConfirm);
            this.tabPage2.Controls.Add(this.lb);
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.textPassword22);
            this.tabPage2.Controls.Add(this.TextPassword);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.textUserName);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(751, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Login Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UserIDValue
            // 
            this.UserIDValue.AutoSize = true;
            this.UserIDValue.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserIDValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UserIDValue.Location = new System.Drawing.Point(111, 52);
            this.UserIDValue.Name = "UserIDValue";
            this.UserIDValue.Size = new System.Drawing.Size(0, 19);
            this.UserIDValue.TabIndex = 68;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(36, 219);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(79, 21);
            this.checkBox1.TabIndex = 67;
            this.checkBox1.Text = "Is Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textConfirm
            // 
            this.textConfirm.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConfirm.Location = new System.Drawing.Point(196, 177);
            this.textConfirm.Name = "textConfirm";
            this.textConfirm.Size = new System.Drawing.Size(210, 23);
            this.textConfirm.TabIndex = 66;
            this.textConfirm.UseSystemPasswordChar = true;
            this.textConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.textConfirm_Validating);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lb.Location = new System.Drawing.Point(30, 180);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(131, 19);
            this.lb.TabIndex = 65;
            this.lb.Text = "Confirm Password";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DvldProject.Properties.Resources.password22;
            this.pictureBox3.Location = new System.Drawing.Point(165, 177);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 64;
            this.pictureBox3.TabStop = false;
            // 
            // textPassword22
            // 
            this.textPassword22.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword22.Location = new System.Drawing.Point(141, 134);
            this.textPassword22.Name = "textPassword22";
            this.textPassword22.Size = new System.Drawing.Size(210, 23);
            this.textPassword22.TabIndex = 63;
            this.textPassword22.UseSystemPasswordChar = true;
            this.textPassword22.Validating += new System.ComponentModel.CancelEventHandler(this.textPassword22_Validating);
            // 
            // TextPassword
            // 
            this.TextPassword.AutoSize = true;
            this.TextPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TextPassword.Location = new System.Drawing.Point(30, 137);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(73, 19);
            this.TextPassword.TabIndex = 62;
            this.TextPassword.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DvldProject.Properties.Resources.password22;
            this.pictureBox1.Location = new System.Drawing.Point(115, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 61;
            this.pictureBox1.TabStop = false;
            // 
            // textUserName
            // 
            this.textUserName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserName.Location = new System.Drawing.Point(141, 92);
            this.textUserName.Name = "textUserName";
            this.textUserName.Size = new System.Drawing.Size(210, 23);
            this.textUserName.TabIndex = 60;
            this.textUserName.Validating += new System.ComponentModel.CancelEventHandler(this.textUserName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(30, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 59;
            this.label3.Text = "UserName";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DvldProject.Properties.Resources.user__1_;
            this.pictureBox2.Location = new System.Drawing.Point(115, 92);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 58;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(31, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(267, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add New User ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.BTNsave.Location = new System.Drawing.Point(674, 550);
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
            this.BTNclose.Location = new System.Drawing.Point(561, 550);
            this.BTNclose.Name = "BTNclose";
            this.BTNclose.Size = new System.Drawing.Size(81, 38);
            this.BTNclose.TabIndex = 16;
            this.BTNclose.Text = "Close";
            this.BTNclose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTNclose.UseVisualStyleBackColor = true;
            this.BTNclose.Click += new System.EventHandler(this.BTNclose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddNewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 591);
            this.Controls.Add(this.BTNsave);
            this.Controls.Add(this.BTNclose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddNewUserForm";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNNext;
        private System.Windows.Forms.Button BTNsave;
        private System.Windows.Forms.Button BTNclose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textPassword22;
        private System.Windows.Forms.Label TextPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textUserName;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textConfirm;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label UserIDValue;
        private PeopleFolder.Controls.PersonDetailsFilter personDetailsFilter1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}