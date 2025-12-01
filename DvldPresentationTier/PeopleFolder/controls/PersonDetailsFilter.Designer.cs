namespace DvldProject.PeopleFolder.Controls
{
    partial class PersonDetailsFilter
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
            this.textFilter = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnFilter = new System.Windows.Forms.Button();
            this.personDetails1 = new DvldProject.PersonDetails();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textFilter
            // 
            this.textFilter.Location = new System.Drawing.Point(260, 20);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(164, 23);
            this.textFilter.TabIndex = 5;
            this.textFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textFilter_KeyPress);
            this.textFilter.Validating += new System.ComponentModel.CancelEventHandler(this.textFilter_Validating);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "person ID",
            "national No"});
            this.comboBox1.Location = new System.Drawing.Point(96, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(146, 25);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter by :";
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.BtnAdd);
            this.groupFilter.Controls.Add(this.BtnFilter);
            this.groupFilter.Controls.Add(this.textFilter);
            this.groupFilter.Controls.Add(this.comboBox1);
            this.groupFilter.Controls.Add(this.label1);
            this.groupFilter.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupFilter.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupFilter.Location = new System.Drawing.Point(12, 3);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(607, 58);
            this.groupFilter.TabIndex = 6;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Filter";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Image = global::DvldProject.Properties.Resources.user__1_1;
            this.BtnAdd.Location = new System.Drawing.Point(561, 17);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(31, 31);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnFilter
            // 
            this.BtnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFilter.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.BtnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BtnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilter.Image = global::DvldProject.Properties.Resources.user__2_;
            this.BtnFilter.Location = new System.Drawing.Point(511, 17);
            this.BtnFilter.Name = "BtnFilter";
            this.BtnFilter.Size = new System.Drawing.Size(31, 31);
            this.BtnFilter.TabIndex = 6;
            this.BtnFilter.UseVisualStyleBackColor = true;
            this.BtnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // personDetails1
            // 
            this.personDetails1.Location = new System.Drawing.Point(0, 61);
            this.personDetails1.Name = "personDetails1";
            this.personDetails1.Size = new System.Drawing.Size(628, 244);
            this.personDetails1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PersonDetailsFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.personDetails1);
            this.Name = "PersonDetailsFilter";
            this.Size = new System.Drawing.Size(633, 308);
            this.Load += new System.EventHandler(this.PersonDetailsFilter_Load);
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PersonDetails personDetails1;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.Button BtnFilter;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
