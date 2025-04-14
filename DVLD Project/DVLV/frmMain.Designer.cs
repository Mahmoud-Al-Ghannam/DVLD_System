namespace DVLD
{
    partial class frmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicensesServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAddNewInternationalLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.smiRenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiReplacmentForLostOrDamage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.smiReleaseDetainedDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.smiRetakeTest = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageLocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageInternationalLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.detaindLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.smiReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageApplicationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.smiManageTestTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCurrentUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.smiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiApplications,
            this.smiDrivers,
            this.smiUsers,
            this.smiPeople,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 72);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiApplications
            // 
            this.smiApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicensesServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detaindLicenseToolStripMenuItem,
            this.smiManageApplicationTypes,
            this.smiManageTestTypes});
            this.smiApplications.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.smiApplications.Image = global::DVLD.Properties.Resources.Applications_64;
            this.smiApplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smiApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiApplications.Name = "smiApplications";
            this.smiApplications.Size = new System.Drawing.Size(208, 68);
            this.smiApplications.Text = "Applications";
            // 
            // drivingLicensesServicesToolStripMenuItem
            // 
            this.drivingLicensesServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenseToolStripMenuItem,
            this.smiRenewDrivingLicense,
            this.toolStripSeparator1,
            this.smiReplacmentForLostOrDamage,
            this.toolStripSeparator2,
            this.smiReleaseDetainedDrivingLicense,
            this.smiRetakeTest});
            this.drivingLicensesServicesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.drivingLicensesServicesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicensesServicesToolStripMenuItem.Name = "drivingLicensesServicesToolStripMenuItem";
            this.drivingLicensesServicesToolStripMenuItem.Size = new System.Drawing.Size(394, 70);
            this.drivingLicensesServicesToolStripMenuItem.Text = "Driving Licenses Services";
            // 
            // newDrivingLicenseToolStripMenuItem
            // 
            this.newDrivingLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiAddNewLocalDrivingLicenseApplication,
            this.smiAddNewInternationalLicense});
            this.newDrivingLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.newDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicenseToolStripMenuItem.Name = "newDrivingLicenseToolStripMenuItem";
            this.newDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(498, 38);
            this.newDrivingLicenseToolStripMenuItem.Text = "New Driving License";
            // 
            // smiAddNewLocalDrivingLicenseApplication
            // 
            this.smiAddNewLocalDrivingLicenseApplication.Image = global::DVLD.Properties.Resources.Local_32;
            this.smiAddNewLocalDrivingLicenseApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiAddNewLocalDrivingLicenseApplication.Name = "smiAddNewLocalDrivingLicenseApplication";
            this.smiAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(308, 38);
            this.smiAddNewLocalDrivingLicenseApplication.Text = "Local License";
            this.smiAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.smiAddNewLocalDrivingLicenseApplication_Click);
            // 
            // smiAddNewInternationalLicense
            // 
            this.smiAddNewInternationalLicense.Image = global::DVLD.Properties.Resources.International_32;
            this.smiAddNewInternationalLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiAddNewInternationalLicense.Name = "smiAddNewInternationalLicense";
            this.smiAddNewInternationalLicense.Size = new System.Drawing.Size(308, 38);
            this.smiAddNewInternationalLicense.Text = "International License";
            this.smiAddNewInternationalLicense.Click += new System.EventHandler(this.smiAddNewInternationalLicense_Click);
            // 
            // smiRenewDrivingLicense
            // 
            this.smiRenewDrivingLicense.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.smiRenewDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiRenewDrivingLicense.Name = "smiRenewDrivingLicense";
            this.smiRenewDrivingLicense.Size = new System.Drawing.Size(498, 38);
            this.smiRenewDrivingLicense.Text = "Renew Driving License";
            this.smiRenewDrivingLicense.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(495, 6);
            // 
            // smiReplacmentForLostOrDamage
            // 
            this.smiReplacmentForLostOrDamage.Image = global::DVLD.Properties.Resources.Damaged_Driving_License_32;
            this.smiReplacmentForLostOrDamage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiReplacmentForLostOrDamage.Name = "smiReplacmentForLostOrDamage";
            this.smiReplacmentForLostOrDamage.Size = new System.Drawing.Size(498, 38);
            this.smiReplacmentForLostOrDamage.Text = "Replacment for Lost or Damaged License";
            this.smiReplacmentForLostOrDamage.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(495, 6);
            // 
            // smiReleaseDetainedDrivingLicense
            // 
            this.smiReleaseDetainedDrivingLicense.Image = global::DVLD.Properties.Resources.Detained_Driving_License_32;
            this.smiReleaseDetainedDrivingLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiReleaseDetainedDrivingLicense.Name = "smiReleaseDetainedDrivingLicense";
            this.smiReleaseDetainedDrivingLicense.Size = new System.Drawing.Size(498, 38);
            this.smiReleaseDetainedDrivingLicense.Text = "Release Detained Driving LIcense";
            this.smiReleaseDetainedDrivingLicense.Click += new System.EventHandler(this.smiReleaseDetainedDrivingLicense_Click);
            // 
            // smiRetakeTest
            // 
            this.smiRetakeTest.Image = global::DVLD.Properties.Resources.Retake_Test_32;
            this.smiRetakeTest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiRetakeTest.Name = "smiRetakeTest";
            this.smiRetakeTest.Size = new System.Drawing.Size(498, 38);
            this.smiRetakeTest.Text = "Retake Test";
            this.smiRetakeTest.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiManageLocalDrivingLicenseApplications,
            this.smiManageInternationalLicenseApplications});
            this.manageApplicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Manage_Applications_64;
            this.manageApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(394, 70);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // smiManageLocalDrivingLicenseApplications
            // 
            this.smiManageLocalDrivingLicenseApplications.Image = global::DVLD.Properties.Resources.Driver_License_48;
            this.smiManageLocalDrivingLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiManageLocalDrivingLicenseApplications.Name = "smiManageLocalDrivingLicenseApplications";
            this.smiManageLocalDrivingLicenseApplications.Size = new System.Drawing.Size(450, 54);
            this.smiManageLocalDrivingLicenseApplications.Text = "Local Driving License Applications";
            this.smiManageLocalDrivingLicenseApplications.Click += new System.EventHandler(this.smiManageLocalDrivingLicenseApplications_Click);
            // 
            // smiManageInternationalLicenseApplications
            // 
            this.smiManageInternationalLicenseApplications.Image = global::DVLD.Properties.Resources.International_32;
            this.smiManageInternationalLicenseApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiManageInternationalLicenseApplications.Name = "smiManageInternationalLicenseApplications";
            this.smiManageInternationalLicenseApplications.Size = new System.Drawing.Size(450, 54);
            this.smiManageInternationalLicenseApplications.Text = "International License Applications";
            this.smiManageInternationalLicenseApplications.Click += new System.EventHandler(this.smiManageInternationalLicenseApplications_Click);
            // 
            // detaindLicenseToolStripMenuItem
            // 
            this.detaindLicenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.smiDetainLicense,
            this.smiReleaseDetainedLicense});
            this.detaindLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_64;
            this.detaindLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detaindLicenseToolStripMenuItem.Name = "detaindLicenseToolStripMenuItem";
            this.detaindLicenseToolStripMenuItem.Size = new System.Drawing.Size(394, 70);
            this.detaindLicenseToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = global::DVLD.Properties.Resources.Detain_64;
            this.manageDetainedLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(395, 70);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // smiDetainLicense
            // 
            this.smiDetainLicense.Image = global::DVLD.Properties.Resources.Detain_64;
            this.smiDetainLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiDetainLicense.Name = "smiDetainLicense";
            this.smiDetainLicense.Size = new System.Drawing.Size(395, 70);
            this.smiDetainLicense.Text = "Detain License";
            this.smiDetainLicense.Click += new System.EventHandler(this.smiDetainLicense_Click);
            // 
            // smiReleaseDetainedLicense
            // 
            this.smiReleaseDetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.smiReleaseDetainedLicense.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiReleaseDetainedLicense.Name = "smiReleaseDetainedLicense";
            this.smiReleaseDetainedLicense.Size = new System.Drawing.Size(395, 70);
            this.smiReleaseDetainedLicense.Text = "Release Detained License";
            this.smiReleaseDetainedLicense.Click += new System.EventHandler(this.smiReleaseDetainedLicense_Click);
            // 
            // smiManageApplicationTypes
            // 
            this.smiManageApplicationTypes.Image = global::DVLD.Properties.Resources.Application_Types_64;
            this.smiManageApplicationTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiManageApplicationTypes.Name = "smiManageApplicationTypes";
            this.smiManageApplicationTypes.Size = new System.Drawing.Size(394, 70);
            this.smiManageApplicationTypes.Text = "Manage Application Types";
            this.smiManageApplicationTypes.Click += new System.EventHandler(this.manageApplicationTypesToolStripMenuItem_Click);
            // 
            // smiManageTestTypes
            // 
            this.smiManageTestTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.smiManageTestTypes.Image = global::DVLD.Properties.Resources.Test_Type_64;
            this.smiManageTestTypes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiManageTestTypes.Name = "smiManageTestTypes";
            this.smiManageTestTypes.Size = new System.Drawing.Size(394, 70);
            this.smiManageTestTypes.Text = "Manage Test Types";
            this.smiManageTestTypes.Click += new System.EventHandler(this.smiManageTestTypes_Click);
            // 
            // smiDrivers
            // 
            this.smiDrivers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.smiDrivers.Image = global::DVLD.Properties.Resources.Drivers_64;
            this.smiDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiDrivers.Name = "smiDrivers";
            this.smiDrivers.Size = new System.Drawing.Size(158, 68);
            this.smiDrivers.Text = "Drivers";
            this.smiDrivers.Click += new System.EventHandler(this.smiDrivers_Click);
            // 
            // smiUsers
            // 
            this.smiUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.smiUsers.Image = global::DVLD.Properties.Resources.Users_2_64;
            this.smiUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smiUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiUsers.Name = "smiUsers";
            this.smiUsers.Size = new System.Drawing.Size(141, 68);
            this.smiUsers.Text = "Users";
            this.smiUsers.Click += new System.EventHandler(this.smiUsers_Click);
            // 
            // smiPeople
            // 
            this.smiPeople.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.smiPeople.Image = global::DVLD.Properties.Resources.People_64;
            this.smiPeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.smiPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.smiPeople.Name = "smiPeople";
            this.smiPeople.Size = new System.Drawing.Size(153, 68);
            this.smiPeople.Text = "People";
            this.smiPeople.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiCurrentUserInfo,
            this.smiChangePassword,
            this.smiSignOut});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.toolStripMenuItem1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(251, 68);
            this.toolStripMenuItem1.Text = "Account Settings";
            // 
            // smiCurrentUserInfo
            // 
            this.smiCurrentUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smiCurrentUserInfo.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.smiCurrentUserInfo.Name = "smiCurrentUserInfo";
            this.smiCurrentUserInfo.Size = new System.Drawing.Size(230, 28);
            this.smiCurrentUserInfo.Text = "Current User Info";
            this.smiCurrentUserInfo.Click += new System.EventHandler(this.smiCurrentUserInfo_Click);
            // 
            // smiChangePassword
            // 
            this.smiChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smiChangePassword.Image = global::DVLD.Properties.Resources.Password_32;
            this.smiChangePassword.Name = "smiChangePassword";
            this.smiChangePassword.Size = new System.Drawing.Size(230, 28);
            this.smiChangePassword.Text = "Change Password";
            this.smiChangePassword.Click += new System.EventHandler(this.smiChangePassword_Click);
            // 
            // smiSignOut
            // 
            this.smiSignOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.smiSignOut.Image = global::DVLD.Properties.Resources.Sign_Out_32;
            this.smiSignOut.Name = "smiSignOut";
            this.smiSignOut.Size = new System.Drawing.Size(230, 28);
            this.smiSignOut.Text = "Sign Out";
            this.smiSignOut.Click += new System.EventHandler(this.smiSignOut_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::DVLD.Properties.Resources.Logo_Final;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(952, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiPeople;
        private System.Windows.Forms.ToolStripMenuItem smiUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem smiCurrentUserInfo;
        private System.Windows.Forms.ToolStripMenuItem smiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem smiSignOut;
        private System.Windows.Forms.ToolStripMenuItem smiApplications;
        private System.Windows.Forms.ToolStripMenuItem smiManageTestTypes;
        private System.Windows.Forms.ToolStripMenuItem smiManageApplicationTypes;
        private System.Windows.Forms.ToolStripMenuItem detaindLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicensesServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiManageLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem smiManageInternationalLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiDetainLicense;
        private System.Windows.Forms.ToolStripMenuItem smiReleaseDetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiRenewDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem smiReplacmentForLostOrDamage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem smiReleaseDetainedDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem smiRetakeTest;
        private System.Windows.Forms.ToolStripMenuItem smiDrivers;
        private System.Windows.Forms.ToolStripMenuItem smiAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ToolStripMenuItem smiAddNewInternationalLicense;
    }
}