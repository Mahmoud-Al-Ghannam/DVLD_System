namespace DVLD.Licenses.LocalLicenses.Controls
{
    partial class ctrlLicenseInfoWithFilter
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
            this.LicenseCard = new DVLD.LocalLicenses.Controls.ctrlLicenseInfo();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbSearchForLicense = new System.Windows.Forms.PictureBox();
            this.tbLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // LicenseCard
            // 
            this.LicenseCard.Location = new System.Drawing.Point(3, 77);
            this.LicenseCard.Name = "LicenseCard";
            this.LicenseCard.Size = new System.Drawing.Size(900, 529);
            this.LicenseCard.TabIndex = 0;
            this.LicenseCard.On_LoadedLicenseInfo += new System.EventHandler<DVLD.LocalLicenses.Controls.ctrlLicenseInfo.LicenseEventArgs>(this.LicenseCard_On_LoadedLicenseInfo);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbSearchForLicense);
            this.gbFilter.Controls.Add(this.tbLicenseID);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(3, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(608, 72);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbSearchForLicense
            // 
            this.pbSearchForLicense.BackgroundImage = global::DVLD.Properties.Resources.License_View_32;
            this.pbSearchForLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSearchForLicense.Location = new System.Drawing.Point(453, 26);
            this.pbSearchForLicense.Margin = new System.Windows.Forms.Padding(5);
            this.pbSearchForLicense.Name = "pbSearchForLicense";
            this.pbSearchForLicense.Size = new System.Drawing.Size(32, 32);
            this.pbSearchForLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSearchForLicense.TabIndex = 5;
            this.pbSearchForLicense.TabStop = false;
            this.pbSearchForLicense.Click += new System.EventHandler(this.pbSearchForLicense_Click);
            // 
            // tbLicenseID
            // 
            this.tbLicenseID.Location = new System.Drawing.Point(188, 29);
            this.tbLicenseID.Name = "tbLicenseID";
            this.tbLicenseID.Size = new System.Drawing.Size(257, 26);
            this.tbLicenseID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID:";
            // 
            // ctrlLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.LicenseCard);
            this.Name = "ctrlLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(906, 609);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForLicense)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD.LocalLicenses.Controls.ctrlLicenseInfo LicenseCard;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.TextBox tbLicenseID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSearchForLicense;
    }
}
