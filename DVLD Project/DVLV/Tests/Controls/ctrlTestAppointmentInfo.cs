using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD.Tests.Controls.ctrlTestInfo;

namespace DVLD.Tests.Controls
{
    public partial class ctrlTestAppointmentInfo : UserControl
    {
        public class TestAppointmentEventArgs : EventArgs
        {
            public int TestAppointmentID { get; }
            public TestAppointmentEventArgs(int TestAppointmentID)
            {
                this.TestAppointmentID = TestAppointmentID;
            }
        }
        public event EventHandler<TestAppointmentEventArgs> On_LoadedTestAppointmentInfo;
        private void _RaiseEventOnLoadedTestAppointmentInfo(TestAppointmentEventArgs e)
        {
            if (On_LoadedTestAppointmentInfo != null)
                On_LoadedTestAppointmentInfo?.Invoke(this, e);
        }

        public clsTestAppointment SelectedTestAppointment { get; private set; }
        public int TestAppointmentID { get; private set; }
        public ctrlTestAppointmentInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int TestAppointmentID)
        {
            SelectedTestAppointment = clsTestAppointment.FindTestAppointmentByID(TestAppointmentID);
            if (SelectedTestAppointment == null)
            {
                MessageBox.Show($"Error: The test appointment with ID = {TestAppointmentID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TestAppointmentID = -1;
                ResetInfo();
            }
            else
            {
                this.TestAppointmentID = TestAppointmentID;
                _FillInfo();
            }
        }

        public void ResetInfo()
        {
            SelectedTestAppointment = null;
            TestAppointmentID = -1;

            lblTestAppointmentID.Text = "[?????]";
            lblTestType.Text = "[?????]";
            lblIsLocked.Text = "[?????]";
            lblPaidFees.Text = "[?????]";
            lblLDLApplicationID.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            lblAppointmentDate.Text = "[?????]";
            lblRetakeTestApplicationID.Text = "[?????]";
            lblRetakeTestFees.Text = "[?????]";
        }

        private void _FillInfo()    
        {
            if (SelectedTestAppointment == null)
            {
                ResetInfo();
                return;
            }

            lblTestAppointmentID.Text = SelectedTestAppointment.TestAppointmentID.ToString();
            lblTestType.Text = SelectedTestAppointment.TestTypeInfo.TestTypeTitle;
            lblIsLocked.Text = (SelectedTestAppointment.IsLocked ? "Yes" : "No");
            lblPaidFees.Text = SelectedTestAppointment.PaidFees.ToString();
            lblLDLApplicationID.Text = SelectedTestAppointment.LocalDrivingLicenseApplicationID.ToString();
            lblCreatedByUser.Text = SelectedTestAppointment.CreatedByUserInfo.Username;
            lblAppointmentDate.Text = SelectedTestAppointment.AppointmentDate.ToString("yyyy MMM dd hh:mm:ss");
            if (SelectedTestAppointment.RetakeTestApplicationInfo == null)
            {
                lblRetakeTestApplicationID.Text = "N/A";
                lblRetakeTestFees.Text = "0";
            }
            else
            {
                lblRetakeTestApplicationID.Text = SelectedTestAppointment.RetakeTestApplicationID.ToString();
                lblRetakeTestFees.Text = SelectedTestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
            }
            _RaiseEventOnLoadedTestAppointmentInfo(new TestAppointmentEventArgs(TestAppointmentID));
        }

    }
}
