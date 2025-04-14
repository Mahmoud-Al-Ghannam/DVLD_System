using DVLD.Global_Classes;
using DVLD_BusinessLayer;
using System;
using System.Windows.Forms;

namespace DVLD.Tests.Controls
{
    public partial class ctrlTakeTestInfo : UserControl
    {

        public int TestAppointmentID { get; private set; }
        public clsTestAppointment SelectedTestAppointment { get; private set; }
        public int? TestID
        {
            get
            {
                if (clsValidation.IsInteger(lblTestID.Text.Trim()))
                    return Convert.ToInt32(lblTestID.Text.Trim());
                return null;
            }
        }
        public string Notes
        {
            get { return tbNotes.Text; }
        }
        public string CreatedByUser
        {
            get { return lblCreatedByUser.Text; }
        }
        public bool rbPassTest_Checked
        {
            get { return rbPassTest.Checked; }
        }
        public bool rbFailTest_Checked
        {
            get { return rbFailTest.Checked; }
        }


        private bool _Enabled;
        public bool Enabled
        {
            get { return _Enabled; }
            set
            {
                _Enabled = value;
                pTestResult.Enabled = value;
                tbNotes.Enabled = value;
            }
        }

        public ctrlTakeTestInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TestAppointmentID)
        {
            if (clsTestAppointment.IsTestAppointmentExistByID(TestAppointmentID))
            {
                this.TestAppointmentID = TestAppointmentID;
                SelectedTestAppointment = clsTestAppointment.FindTestAppointmentByID(TestAppointmentID);
                _FillInfo();
            }
            else
            {
                this.TestAppointmentID = -1;
                MessageBox.Show($"Error: The test appointment with ID = {TestAppointmentID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetInfo();
            }
        }
        public void ResetInfo()
        {
            TestAppointmentID = -1;
            SelectedTestAppointment = null;
            lblTestID.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            lblTestAppointmentID.Text = "[?????]";
            tbNotes.Text = "";
            gbTestInfo.Text = "Type Test";
            llblTestAppointmentInfo.Enabled = false;
        }
        private void _FillInfo()
        {
            lblCreatedByUser.Text = clsGlobalClass.CurrentUser.Username;
            lblTestAppointmentID.Text = TestAppointmentID.ToString();
            gbTestInfo.Text = SelectedTestAppointment.TestTypeInfo.TestTypeText;
            llblTestAppointmentInfo.Enabled = true;
            clsTest Test = clsTest.FindTestByTestAppointmentID(TestAppointmentID);
            if (Test != null)
            {
                lblTestID.Text = Test.TestID.ToString();
                tbNotes.Text = Test.Notes;
                rbPassTest.Checked = Test.TestResult;
            }
        }

        private void llblTestAppointmentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTestAppointmentInfo frm = new frmShowTestAppointmentInfo(TestAppointmentID);
            frm.ShowDialog();
        }
    }
}
