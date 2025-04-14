namespace DVLD.Drivers
{
    partial class frmShowLicensesHistory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctrlDriverCard2 = new DVLD.Drivers.Controls.ctrlDriverCard();
            this.ctrlLicensesHistory1 = new DVLD.Drivers.Controls.ctrlLicensesHistory();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ctrlLicensesHistory1);
            this.panel1.Controls.Add(this.ctrlDriverCard2);
            this.panel1.Location = new System.Drawing.Point(12, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 593);
            this.panel1.TabIndex = 0;
            // 
            // ctrlDriverCard2
            // 
            this.ctrlDriverCard2.Location = new System.Drawing.Point(3, 3);
            this.ctrlDriverCard2.Name = "ctrlDriverCard2";
            this.ctrlDriverCard2.Size = new System.Drawing.Size(841, 440);
            this.ctrlDriverCard2.TabIndex = 0;
            // 
            // ctrlLicensesHistory1
            // 
            this.ctrlLicensesHistory1.Location = new System.Drawing.Point(3, 449);
            this.ctrlLicensesHistory1.Name = "ctrlLicensesHistory1";
            this.ctrlLicensesHistory1.Size = new System.Drawing.Size(841, 379);
            this.ctrlLicensesHistory1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(872, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "Licenses History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmShowLicensesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(896, 714);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmShowLicensesHistory";
            this.Text = "Licenses History Form";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Controls.ctrlLicensesHistory ctrlLicensesHistory1;
        private Controls.ctrlDriverCard ctrlDriverCard2;
        private System.Windows.Forms.Label label1;
    }
}