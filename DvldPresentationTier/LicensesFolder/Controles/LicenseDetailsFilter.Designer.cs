namespace DvldProject.LicensesFolder.Controles
{
    partial class LicenseDetailsFilter
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.licenseDetailsControle1 = new DvldProject.LicenseDetailsControle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureAddInterLicense = new System.Windows.Forms.PictureBox();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddInterLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // licenseDetailsControle1
            // 
            this.licenseDetailsControle1.Location = new System.Drawing.Point(3, 48);
            this.licenseDetailsControle1.Name = "licenseDetailsControle1";
            this.licenseDetailsControle1.Size = new System.Drawing.Size(677, 308);
            this.licenseDetailsControle1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureAddInterLicense);
            this.groupBox1.Controls.Add(this.txtLicenseID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 45);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // pictureAddInterLicense
            // 
            this.pictureAddInterLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureAddInterLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureAddInterLicense.Image = global::DvldProject.Properties.Resources.id_check__1_;
            this.pictureAddInterLicense.Location = new System.Drawing.Point(439, 11);
            this.pictureAddInterLicense.Name = "pictureAddInterLicense";
            this.pictureAddInterLicense.Size = new System.Drawing.Size(33, 29);
            this.pictureAddInterLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureAddInterLicense.TabIndex = 28;
            this.pictureAddInterLicense.TabStop = false;
            this.pictureAddInterLicense.Click += new System.EventHandler(this.pictureAddInterLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(102, 14);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(207, 20);
            this.txtLicenseID.TabIndex = 1;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseID_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "License Id :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LicenseDetailsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.licenseDetailsControle1);
            this.Name = "LicenseDetailsFilter";
            this.Size = new System.Drawing.Size(682, 361);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAddInterLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LicenseDetailsControle licenseDetailsControle1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureAddInterLicense;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
