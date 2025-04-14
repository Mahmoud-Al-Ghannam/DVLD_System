namespace DVLD.Licenses.LocalLicenses
{
    partial class frmShowLicenseInfo
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
            this.ctrlLicenseInfo1 = new DVLD.LocalLicenses.Controls.ctrlLicenseInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(893, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "License Details ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.AutoSize = true;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(12, 91);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(903, 527);
            this.ctrlLicenseInfo1.TabIndex = 0;
            // 
            // frmShowLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(917, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "frmShowLicenseInfo";
            this.Text = "Show License Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DVLD.LocalLicenses.Controls.ctrlLicenseInfo ctrlLicenseInfo1;
        private System.Windows.Forms.Label label1;
    }
}