namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    partial class frmShowLDLApplicationInfo
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
            this.ctrlLDLApplicationInfo1 = new DVLD.Applications.LocalDrivingLicenseApplications.Controls.ctrlLDLApplicationInfo();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(904, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "LDL Application Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlLDLApplicationInfo1
            // 
            this.ctrlLDLApplicationInfo1.Location = new System.Drawing.Point(13, 88);
            this.ctrlLDLApplicationInfo1.Name = "ctrlLDLApplicationInfo1";
            this.ctrlLDLApplicationInfo1.Size = new System.Drawing.Size(903, 437);
            this.ctrlLDLApplicationInfo1.TabIndex = 3;
            // 
            // frmShowLDLApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(928, 531);
            this.Controls.Add(this.ctrlLDLApplicationInfo1);
            this.Controls.Add(this.label1);
            this.Name = "frmShowLDLApplicationInfo";
            this.Text = "Show Local Driving License Application Form";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Controls.ctrlLDLApplicationInfo ctrlLDLApplicationInfo1;
    }
}