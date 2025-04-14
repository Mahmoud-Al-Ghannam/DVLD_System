using DVLD.Global_Classes;
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

namespace DVLD.Tests.Type_Tests
{
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID;
        private clsTestAppointment _TestAppointment;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointment.FindTestAppointmentByID(_TestAppointmentID);
            ctrlTakeTestInfo1.LoadInfo(TestAppointmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Notes = ctrlTakeTestInfo1.Notes;
            bool TestResult = ctrlTakeTestInfo1.rbPassTest_Checked;
            int TestID = _TestAppointment.TakeATest(TestResult, Notes, clsGlobalClass.CurrentUser.UserID);
            if (TestID != -1)
            {
                ctrlTakeTestInfo1.LoadInfo(_TestAppointmentID);
                btnSave.Enabled = false;
                ctrlTakeTestInfo1.Enabled = false;
                MessageBox.Show("Test info is saved successfully", "Save Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error: Test info is not saved", "Save Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
