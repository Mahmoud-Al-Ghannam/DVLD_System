using DVLD.Applications.ReplaceLicenseApplication.Controls;

namespace DVLD.Applications.RenewLicenseApplication
{
    partial class frmRenewLicenseApplication
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
            this.btnRenew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlReplaceLicenseApplicationInfo1 = new DVLD.Applications.ReplaceLicenseApplication.Controls.ctrlReplaceLicenseApplicationInfo();
            this.ctrlLicenseInfoWithFilter1 = new DVLD.Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(947, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Renew License Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRenew
            // 
            this.btnRenew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenew.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.btnRenew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenew.Location = new System.Drawing.Point(825, 669);
            this.btnRenew.Margin = new System.Windows.Forms.Padding(5);
            this.btnRenew.Name = "btnRenew";
            this.btnRenew.Size = new System.Drawing.Size(129, 45);
            this.btnRenew.TabIndex = 7;
            this.btnRenew.Text = "Renew";
            this.btnRenew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenew.UseVisualStyleBackColor = true;
            this.btnRenew.Click += new System.EventHandler(this.btnRenew_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(686, 669);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 45);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ctrlReplaceLicenseApplicationInfo1);
            this.panel1.Controls.Add(this.ctrlLicenseInfoWithFilter1);
            this.panel1.Location = new System.Drawing.Point(12, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 554);
            this.panel1.TabIndex = 8;
            // 
            // ctrlReplaceLicenseApplicationInfo1
            // 
            this.ctrlReplaceLicenseApplicationInfo1.Location = new System.Drawing.Point(5, 616);
            this.ctrlReplaceLicenseApplicationInfo1.Name = "ctrlReplaceLicenseApplicationInfo1";
            this.ctrlReplaceLicenseApplicationInfo1.Size = new System.Drawing.Size(949, 546);
            this.ctrlReplaceLicenseApplicationInfo1.TabIndex = 9;
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(8, 3);
            this.ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            this.ctrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(906, 607);
            this.ctrlLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlLicenseInfoWithFilter1.On_LicenseSelected += new System.EventHandler<DVLD.Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter.LicenseEventArgs>(this.ctrlLicenseInfoWithFilter1_On_LicenseSelected);
            // 
            // frmRenewLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(968, 728);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRenew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "frmRenewLicenseApplication";
            this.Text = "Renew License Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRenew;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private ctrlReplaceLicenseApplicationInfo ctrlReplaceLicenseApplicationInfo1;
        private Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
    }
}