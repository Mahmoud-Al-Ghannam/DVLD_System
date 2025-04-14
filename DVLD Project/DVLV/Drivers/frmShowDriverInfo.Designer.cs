namespace DVLD.Drivers
{
    partial class frmShowDriverInfo
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
            this.ctrlDriverCard1 = new DVLD.Drivers.Controls.ctrlDriverCard();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(837, 49);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver Details";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverCard1
            // 
            this.ctrlDriverCard1.Location = new System.Drawing.Point(12, 87);
            this.ctrlDriverCard1.Name = "ctrlDriverCard1";
            this.ctrlDriverCard1.Size = new System.Drawing.Size(841, 440);
            this.ctrlDriverCard1.TabIndex = 0;
            // 
            // frmShowDriverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(861, 539);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlDriverCard1);
            this.Name = "frmShowDriverInfo";
            this.Text = "Show Driver Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlDriverCard ctrlDriverCard1;
        private System.Windows.Forms.Label label1;
    }
}