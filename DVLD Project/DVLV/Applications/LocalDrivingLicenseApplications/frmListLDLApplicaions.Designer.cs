namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    partial class frmListLDLApplicaions
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
            this.components = new System.ComponentModel.Container();
            this.dgvLocalDrivingLicenseApplications = new System.Windows.Forms.DataGridView();
            this.cmsLDLApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiLDLApplicationInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDeleteLDLApp = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCancelLDLApp = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEditLDLApp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smiScheduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.smiScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.smiScheduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.smiScheduleParticalTest = new System.Windows.Forms.ToolStripMenuItem();
            this.smiIssueDrivingLicenseForFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbLicenseClasses = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).BeginInit();
            this.cmsLDLApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLocalDrivingLicenseApplications
            // 
            this.dgvLocalDrivingLicenseApplications.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplications.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplications.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalDrivingLicenseApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplications.ContextMenuStrip = this.cmsLDLApp;
            this.dgvLocalDrivingLicenseApplications.Location = new System.Drawing.Point(12, 271);
            this.dgvLocalDrivingLicenseApplications.MultiSelect = false;
            this.dgvLocalDrivingLicenseApplications.Name = "dgvLocalDrivingLicenseApplications";
            this.dgvLocalDrivingLicenseApplications.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplications.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenseApplications.RowTemplate.Height = 24;
            this.dgvLocalDrivingLicenseApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalDrivingLicenseApplications.Size = new System.Drawing.Size(1416, 319);
            this.dgvLocalDrivingLicenseApplications.TabIndex = 16;
            // 
            // cmsLDLApp
            // 
            this.cmsLDLApp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLDLApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiLDLApplicationInfo,
            this.toolStripSeparator1,
            this.smiAddNewLocalDrivingLicenseApplication,
            this.smiDeleteLDLApp,
            this.smiCancelLDLApp,
            this.smiEditLDLApp,
            this.toolStripSeparator2,
            this.smiScheduleTest,
            this.smiIssueDrivingLicenseForFirstTime});
            this.cmsLDLApp.Name = "cmsPerson";
            this.cmsLDLApp.Size = new System.Drawing.Size(312, 226);
            this.cmsLDLApp.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLDLApp_Opening);
            // 
            // smiLDLApplicationInfo
            // 
            this.smiLDLApplicationInfo.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.smiLDLApplicationInfo.Name = "smiLDLApplicationInfo";
            this.smiLDLApplicationInfo.Size = new System.Drawing.Size(311, 26);
            this.smiLDLApplicationInfo.Text = "Show LDL Application Info";
            this.smiLDLApplicationInfo.Click += new System.EventHandler(this.smiLDLApplicationInfo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(308, 6);
            // 
            // smiAddNewLocalDrivingLicenseApplication
            // 
            this.smiAddNewLocalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.New_Application_64;
            this.smiAddNewLocalDrivingLicenseApplication.Name = "smiAddNewLocalDrivingLicenseApplication";
            this.smiAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(311, 26);
            this.smiAddNewLocalDrivingLicenseApplication.Text = "Add New L.D.L.  App";
            this.smiAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.smiAddNewLocalDrivingLicenseApplication_Click);
            // 
            // smiDeleteLDLApp
            // 
            this.smiDeleteLDLApp.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.smiDeleteLDLApp.Name = "smiDeleteLDLApp";
            this.smiDeleteLDLApp.Size = new System.Drawing.Size(311, 26);
            this.smiDeleteLDLApp.Text = "Delete";
            this.smiDeleteLDLApp.Click += new System.EventHandler(this.smiDeleteLDLApp_Click);
            // 
            // smiCancelLDLApp
            // 
            this.smiCancelLDLApp.Image = global::DVLD.Properties.Resources.Delete_32;
            this.smiCancelLDLApp.Name = "smiCancelLDLApp";
            this.smiCancelLDLApp.Size = new System.Drawing.Size(311, 26);
            this.smiCancelLDLApp.Text = "Cancel";
            this.smiCancelLDLApp.Click += new System.EventHandler(this.smiCancelLDLApp_Click);
            // 
            // smiEditLDLApp
            // 
            this.smiEditLDLApp.Image = global::DVLD.Properties.Resources.edit_32;
            this.smiEditLDLApp.Name = "smiEditLDLApp";
            this.smiEditLDLApp.Size = new System.Drawing.Size(311, 26);
            this.smiEditLDLApp.Text = "Edit";
            this.smiEditLDLApp.Click += new System.EventHandler(this.smiEditLDLApp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(308, 6);
            // 
            // smiScheduleTest
            // 
            this.smiScheduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiScheduleVisionTest,
            this.smiScheduleWrittenTest,
            this.smiScheduleParticalTest});
            this.smiScheduleTest.Image = global::DVLD.Properties.Resources.Schedule_Test_512;
            this.smiScheduleTest.Name = "smiScheduleTest";
            this.smiScheduleTest.Size = new System.Drawing.Size(311, 26);
            this.smiScheduleTest.Text = "Schedule Test";
            // 
            // smiScheduleVisionTest
            // 
            this.smiScheduleVisionTest.Image = global::DVLD.Properties.Resources.Vision_Test_32;
            this.smiScheduleVisionTest.Name = "smiScheduleVisionTest";
            this.smiScheduleVisionTest.Size = new System.Drawing.Size(235, 26);
            this.smiScheduleVisionTest.Text = "Schedule VIsion Test";
            this.smiScheduleVisionTest.Click += new System.EventHandler(this.smiScheduleVisionTest_Click);
            // 
            // smiScheduleWrittenTest
            // 
            this.smiScheduleWrittenTest.Image = global::DVLD.Properties.Resources.Written_Test_32;
            this.smiScheduleWrittenTest.Name = "smiScheduleWrittenTest";
            this.smiScheduleWrittenTest.Size = new System.Drawing.Size(235, 26);
            this.smiScheduleWrittenTest.Text = "Schedule Written Test";
            this.smiScheduleWrittenTest.Click += new System.EventHandler(this.smiScheduleWrittenTest_Click);
            // 
            // smiScheduleParticalTest
            // 
            this.smiScheduleParticalTest.Image = global::DVLD.Properties.Resources.Cars_48;
            this.smiScheduleParticalTest.Name = "smiScheduleParticalTest";
            this.smiScheduleParticalTest.Size = new System.Drawing.Size(235, 26);
            this.smiScheduleParticalTest.Text = "Schedule Partical Test";
            this.smiScheduleParticalTest.Click += new System.EventHandler(this.smiScheduleParticalTest_Click);
            // 
            // smiIssueDrivingLicenseForFirstTime
            // 
            this.smiIssueDrivingLicenseForFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.smiIssueDrivingLicenseForFirstTime.Name = "smiIssueDrivingLicenseForFirstTime";
            this.smiIssueDrivingLicenseForFirstTime.Size = new System.Drawing.Size(311, 26);
            this.smiIssueDrivingLicenseForFirstTime.Text = "Issue Driving License For First Time";
            this.smiIssueDrivingLicenseForFirstTime.Click += new System.EventHandler(this.smiIssueDrivingLicenseForFirstTime_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNumberOfRecords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(140, 603);
            this.lblNumberOfRecords.Margin = new System.Windows.Forms.Padding(3);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(106, 25);
            this.lblNumberOfRecords.TabIndex = 23;
            this.lblNumberOfRecords.Text = "# Records:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(11, 603);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 10, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records:";
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tbFilterValue.Location = new System.Drawing.Point(273, 235);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(151, 26);
            this.tbFilterValue.TabIndex = 20;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterValue_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.DropDownWidth = 200;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "LDL Application ID",
            "Driving Class",
            "National NO",
            "Full Name",
            "Passed Tests",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(116, 234);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(151, 28);
            this.cbFilterBy.TabIndex = 18;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(309, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(823, 46);
            this.label2.TabIndex = 22;
            this.label2.Text = "Manage Local Driving License Applications";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Filter By:";
            // 
            // cbLicenseClasses
            // 
            this.cbLicenseClasses.DropDownWidth = 200;
            this.cbLicenseClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenseClasses.FormattingEnabled = true;
            this.cbLicenseClasses.Location = new System.Drawing.Point(273, 233);
            this.cbLicenseClasses.Name = "cbLicenseClasses";
            this.cbLicenseClasses.Size = new System.Drawing.Size(151, 28);
            this.cbLicenseClasses.TabIndex = 26;
            this.cbLicenseClasses.SelectedIndexChanged += new System.EventHandler(this.cbLicenseClasses_SelectedIndexChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownWidth = 200;
            this.cbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(273, 233);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(151, 28);
            this.cbStatus.TabIndex = 27;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.BackgroundImage = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewLocalDrivingLicenseApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1364, 197);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(64, 64);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 25;
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Local_32;
            this.pictureBox1.Location = new System.Drawing.Point(771, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.Manage_Applications_64;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(667, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(107, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // frmListLDLApplicaions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1440, 635);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbLicenseClasses);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplications);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmListLDLApplicaions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Local Driving License Applications Form";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplicaions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplications)).EndInit();
            this.cmsLDLApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplications;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApp;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ComboBox cbLicenseClasses;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ToolStripMenuItem smiAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem smiLDLApplicationInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem smiDeleteLDLApp;
        private System.Windows.Forms.ToolStripMenuItem smiCancelLDLApp;
        private System.Windows.Forms.ToolStripMenuItem smiEditLDLApp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem smiScheduleTest;
        private System.Windows.Forms.ToolStripMenuItem smiScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem smiScheduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem smiScheduleParticalTest;
        private System.Windows.Forms.ToolStripMenuItem smiIssueDrivingLicenseForFirstTime;
    }
}