using DVLD.Properties;
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

namespace DVLD.Tests.Controls
{
    public partial class ctrlTestInfo : UserControl
    {
        public class TestEventArgs : EventArgs
        {
            public int TestID { get; }
            public TestEventArgs(int TestID)
            {
                this.TestID = TestID;
            }
        }
        public event EventHandler<TestEventArgs> On_LoadedTestInfo;
        private void _RaiseEventOnLoadedTestInfo(TestEventArgs e)
        {
            if (On_LoadedTestInfo != null)
                On_LoadedTestInfo?.Invoke(this, e);
        }

        public clsTest SelectedTest { get; private set; }
        public int TestID { get; private set; }
        public ctrlTestInfo()
        {
            InitializeComponent();
            ResetInfo();
        }

        public void LoadInfo(int TestID)
        {
            SelectedTest = clsTest.FindTestByID(TestID);
            if (SelectedTest == null)
            {
                MessageBox.Show($"Error: The test with ID = {TestID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TestID = -1;
                ResetInfo();
            }
            else
            {
                this.TestID = TestID;
                _FillInfo();
            }
        }

        public void ResetInfo()
        {
            SelectedTest = null;
            TestID = -1;

            lblTestID.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            lblNotes.Text = "[?????]";
            lblTestAppointmentID.Text = "[?????]";
            lblTestResult.Text = "[?????]";
        }

        private void _FillInfo()
        {
            if (SelectedTest == null)
            {
                ResetInfo();
                return;
            }

            lblTestID.Text = SelectedTest.TestID.ToString();
            lblCreatedByUser.Text = SelectedTest.CreatedByUserInfo.Username;
            lblNotes.Text = SelectedTest.Notes;
            lblTestAppointmentID.Text = SelectedTest.TestAppointmentID.ToString();
            lblTestResult.Text = (SelectedTest.TestResult?"Pass":"Fail");
            gbTestInfo.Text = SelectedTest.TestAppointmentInfo.TestTypeInfo.TestTypeTitle;
            _RaiseEventOnLoadedTestInfo(new TestEventArgs(this.TestID));
        }

        private void llblTestAppointmentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTestAppointmentInfo frm = new frmShowTestAppointmentInfo(SelectedTest.TestAppointmentID);
            frm.ShowDialog();
        }
    }
}
