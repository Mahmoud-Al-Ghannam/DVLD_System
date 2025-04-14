namespace DVLD.Applications.DetainedLicense
{
    partial class frmShowDetainLicenseInfo
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
            this.ctrlDetainedLicenseInfo1 = new DVLD.Applications.DetainedLicense.Controls.ctrlReleaseLicenseInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrlDetainedLicenseInfo1
            // 
            this.ctrlDetainedLicenseInfo1.Location = new System.Drawing.Point(12, 96);
            this.ctrlDetainedLicenseInfo1.Name = "ctrlDetainedLicenseInfo1";
            this.ctrlDetainedLicenseInfo1.Size = new System.Drawing.Size(900, 235);
            this.ctrlDetainedLicenseInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(902, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detain License Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShowDetainLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(926, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDetainedLicenseInfo1);
            this.Name = "frmShowDetainLicenseInfo";
            this.Text = "Show Detain License Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlReleaseLicenseInfo ctrlDetainedLicenseInfo1;
        private System.Windows.Forms.Label label1;
    }
}