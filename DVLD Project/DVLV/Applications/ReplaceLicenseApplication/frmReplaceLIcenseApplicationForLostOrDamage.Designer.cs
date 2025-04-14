namespace DVLD.Applications.ReplaceLicenseApplication
{
    partial class frmReplaceLIcenseApplicationForLostOrDamage
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
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbReplaceForLost = new System.Windows.Forms.RadioButton();
            this.rbReplaceForDamage = new System.Windows.Forms.RadioButton();
            this.ctrlReplaceLicenseApplicationInfo1 = new DVLD.Applications.ReplaceLicenseApplication.Controls.ctrlReplaceLicenseApplicationInfo();
            this.ctrlLicenseInfoWithFilter1 = new DVLD.Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(943, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "Replace License Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReplace
            // 
            this.btnReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.btnReplace.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReplace.Location = new System.Drawing.Point(807, 682);
            this.btnReplace.Margin = new System.Windows.Forms.Padding(5);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(146, 45);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "Replace";
            this.btnReplace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(668, 682);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 45);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.ctrlReplaceLicenseApplicationInfo1);
            this.panel1.Controls.Add(this.ctrlLicenseInfoWithFilter1);
            this.panel1.Location = new System.Drawing.Point(12, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(943, 561);
            this.panel1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbReplaceForLost);
            this.groupBox1.Controls.Add(this.rbReplaceForDamage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(619, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 75);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replace For";
            // 
            // rbReplaceForLost
            // 
            this.rbReplaceForLost.AutoSize = true;
            this.rbReplaceForLost.Location = new System.Drawing.Point(138, 36);
            this.rbReplaceForLost.Name = "rbReplaceForLost";
            this.rbReplaceForLost.Size = new System.Drawing.Size(63, 24);
            this.rbReplaceForLost.TabIndex = 1;
            this.rbReplaceForLost.Text = "Lost";
            this.rbReplaceForLost.UseVisualStyleBackColor = true;
            // 
            // rbReplaceForDamage
            // 
            this.rbReplaceForDamage.AutoSize = true;
            this.rbReplaceForDamage.Checked = true;
            this.rbReplaceForDamage.Location = new System.Drawing.Point(28, 36);
            this.rbReplaceForDamage.Name = "rbReplaceForDamage";
            this.rbReplaceForDamage.Size = new System.Drawing.Size(93, 24);
            this.rbReplaceForDamage.TabIndex = 0;
            this.rbReplaceForDamage.TabStop = true;
            this.rbReplaceForDamage.Text = "Damage";
            this.rbReplaceForDamage.UseVisualStyleBackColor = true;
            this.rbReplaceForDamage.CheckedChanged += new System.EventHandler(this.rbReplaceForDamage_CheckedChanged);
            // 
            // ctrlReplaceLicenseApplicationInfo1
            // 
            this.ctrlReplaceLicenseApplicationInfo1.Location = new System.Drawing.Point(8, 614);
            this.ctrlReplaceLicenseApplicationInfo1.Name = "ctrlReplaceLicenseApplicationInfo1";
            this.ctrlReplaceLicenseApplicationInfo1.Size = new System.Drawing.Size(912, 546);
            this.ctrlReplaceLicenseApplicationInfo1.TabIndex = 6;
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(3, 3);
            this.ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            this.ctrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(906, 605);
            this.ctrlLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrlLicenseInfoWithFilter1.On_LicenseSelected += new System.EventHandler<DVLD.Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter.LicenseEventArgs>(this.ctrlLicenseInfoWithFilter1_On_LicenseSelected);
            // 
            // frmReplaceLIcenseApplicationForLostOrDamage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(967, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Name = "frmReplaceLIcenseApplicationForLostOrDamage";
            this.Text = "Replace License Form";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private Controls.ctrlReplaceLicenseApplicationInfo ctrlReplaceLicenseApplicationInfo1;
        private Licenses.LocalLicenses.Controls.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbReplaceForLost;
        private System.Windows.Forms.RadioButton rbReplaceForDamage;
    }
}