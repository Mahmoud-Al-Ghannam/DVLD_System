namespace DVLD.Tests.Controls
{
    partial class ctrlTakeTestInfo
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
            this.gbTestInfo = new System.Windows.Forms.GroupBox();
            this.llblTestAppointmentInfo = new System.Windows.Forms.LinkLabel();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.pTestResult = new System.Windows.Forms.Panel();
            this.rbFailTest = new System.Windows.Forms.RadioButton();
            this.rbPassTest = new System.Windows.Forms.RadioButton();
            this.lblCreatedByUser = new System.Windows.Forms.Label();
            this.lblTestAppointmentID = new System.Windows.Forms.Label();
            this.lblTestID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTestInfo.SuspendLayout();
            this.pTestResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTestInfo
            // 
            this.gbTestInfo.Controls.Add(this.llblTestAppointmentInfo);
            this.gbTestInfo.Controls.Add(this.tbNotes);
            this.gbTestInfo.Controls.Add(this.pTestResult);
            this.gbTestInfo.Controls.Add(this.lblCreatedByUser);
            this.gbTestInfo.Controls.Add(this.lblTestAppointmentID);
            this.gbTestInfo.Controls.Add(this.lblTestID);
            this.gbTestInfo.Controls.Add(this.label10);
            this.gbTestInfo.Controls.Add(this.label9);
            this.gbTestInfo.Controls.Add(this.label8);
            this.gbTestInfo.Controls.Add(this.label4);
            this.gbTestInfo.Controls.Add(this.label1);
            this.gbTestInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTestInfo.Location = new System.Drawing.Point(3, 3);
            this.gbTestInfo.Name = "gbTestInfo";
            this.gbTestInfo.Size = new System.Drawing.Size(864, 255);
            this.gbTestInfo.TabIndex = 0;
            this.gbTestInfo.TabStop = false;
            this.gbTestInfo.Text = "Type Test";
            // 
            // llblTestAppointmentInfo
            // 
            this.llblTestAppointmentInfo.AutoSize = true;
            this.llblTestAppointmentInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblTestAppointmentInfo.Location = new System.Drawing.Point(486, 96);
            this.llblTestAppointmentInfo.Name = "llblTestAppointmentInfo";
            this.llblTestAppointmentInfo.Size = new System.Drawing.Size(172, 20);
            this.llblTestAppointmentInfo.TabIndex = 25;
            this.llblTestAppointmentInfo.TabStop = true;
            this.llblTestAppointmentInfo.Text = "Test Appointment Info";
            this.llblTestAppointmentInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblTestAppointmentInfo_LinkClicked);
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(231, 195);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(628, 52);
            this.tbNotes.TabIndex = 21;
            // 
            // pTestResult
            // 
            this.pTestResult.Controls.Add(this.rbFailTest);
            this.pTestResult.Controls.Add(this.rbPassTest);
            this.pTestResult.Location = new System.Drawing.Point(231, 140);
            this.pTestResult.Name = "pTestResult";
            this.pTestResult.Size = new System.Drawing.Size(151, 31);
            this.pTestResult.TabIndex = 20;
            // 
            // rbFailTest
            // 
            this.rbFailTest.AutoSize = true;
            this.rbFailTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFailTest.Location = new System.Drawing.Point(78, 3);
            this.rbFailTest.Name = "rbFailTest";
            this.rbFailTest.Size = new System.Drawing.Size(57, 24);
            this.rbFailTest.TabIndex = 1;
            this.rbFailTest.Text = "Fail";
            this.rbFailTest.UseVisualStyleBackColor = true;
            // 
            // rbPassTest
            // 
            this.rbPassTest.AutoSize = true;
            this.rbPassTest.Checked = true;
            this.rbPassTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPassTest.Location = new System.Drawing.Point(4, 3);
            this.rbPassTest.Name = "rbPassTest";
            this.rbPassTest.Size = new System.Drawing.Size(68, 24);
            this.rbPassTest.TabIndex = 0;
            this.rbPassTest.TabStop = true;
            this.rbPassTest.Text = "Pass";
            this.rbPassTest.UseVisualStyleBackColor = true;
            // 
            // lblCreatedByUser
            // 
            this.lblCreatedByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUser.Location = new System.Drawing.Point(666, 46);
            this.lblCreatedByUser.Name = "lblCreatedByUser";
            this.lblCreatedByUser.Size = new System.Drawing.Size(193, 23);
            this.lblCreatedByUser.TabIndex = 18;
            this.lblCreatedByUser.Text = "[?????]";
            // 
            // lblTestAppointmentID
            // 
            this.lblTestAppointmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestAppointmentID.Location = new System.Drawing.Point(231, 95);
            this.lblTestAppointmentID.Name = "lblTestAppointmentID";
            this.lblTestAppointmentID.Size = new System.Drawing.Size(193, 23);
            this.lblTestAppointmentID.TabIndex = 15;
            this.lblTestAppointmentID.Text = "[?????]";
            // 
            // lblTestID
            // 
            this.lblTestID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestID.Location = new System.Drawing.Point(231, 46);
            this.lblTestID.Name = "lblTestID";
            this.lblTestID.Size = new System.Drawing.Size(193, 23);
            this.lblTestID.TabIndex = 10;
            this.lblTestID.Text = "[?????]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(95, 143);
            this.label10.Margin = new System.Windows.Forms.Padding(5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 25);
            this.label10.TabIndex = 9;
            this.label10.Text = "Test Result:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(148, 192);
            this.label9.Margin = new System.Windows.Forms.Padding(5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Notes:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Test Appointment ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(480, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Created By User:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test ID:";
            // 
            // ctrlTakeTestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbTestInfo);
            this.Name = "ctrlTakeTestInfo";
            this.Size = new System.Drawing.Size(870, 264);
            this.gbTestInfo.ResumeLayout(false);
            this.gbTestInfo.PerformLayout();
            this.pTestResult.ResumeLayout(false);
            this.pTestResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTestInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTestAppointmentID;
        private System.Windows.Forms.Label lblTestID;
        private System.Windows.Forms.Label lblCreatedByUser;
        private System.Windows.Forms.Panel pTestResult;
        private System.Windows.Forms.RadioButton rbFailTest;
        private System.Windows.Forms.RadioButton rbPassTest;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.LinkLabel llblTestAppointmentInfo;
    }
}
