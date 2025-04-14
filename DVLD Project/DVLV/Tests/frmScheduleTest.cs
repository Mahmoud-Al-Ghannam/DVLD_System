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
    public partial class frmScheduleTest : Form
    {
        private int _LDLApplicationID;
        private clsTestType.enTestType _TestTypeID;

        private DataTable _dtAppointments;
        private DataTable _dtTests;
        public frmScheduleTest(clsTestType.enTestType TestTypeID, int LDLApplicationID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LDLApplicationID = LDLApplicationID;
            _Refresh();
        }
        private void _Refresh ()
        {
            if (_TestTypeID == clsTestType.enTestType.Vision) lblTitle.Text = "Schedule Vision Test";
            else if (_TestTypeID == clsTestType.enTestType.Written) lblTitle.Text = "Schedule Written Test";
            else if (_TestTypeID == clsTestType.enTestType.Partical) lblTitle.Text = "Schedule Partical Test";

            ctrlLDLApplicationInfo1.LoadInfo(_LDLApplicationID);

            _dtAppointments = clsTestAppointment.GetAllTestAppointmentsAccordingToTestTypeAndLDLApplication(_TestTypeID, _LDLApplicationID);
            dgvAppointments.DataSource = _dtAppointments;
            dgvAppointments.Refresh();

            _dtTests = clsTest.GetAllTestsAccordingToTestTypeAndLDLApplication(_TestTypeID, _LDLApplicationID);
            dgvTests.DataSource = _dtTests;
            dgvTests.Refresh();

            lblNumberOfRecordsOfAppointments.Text = dgvAppointments.RowCount.ToString();
            lblNumberOfRecordsOfTests.Text = dgvTests.RowCount.ToString();

            if (clsTestAppointment.CanAddANewTestAppointmentForLocalDrivingLicneseApplictaion(_TestTypeID, _LDLApplicationID))
                btnAddNewAppointment.Enabled = true;
            else
                btnAddNewAppointment.Enabled = false;
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateTestAppointment(_TestTypeID, _LDLApplicationID);
            frm.ShowDialog();
            _Refresh();
        }

        private void smiEditTestAppointment_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int) dgvAppointments.SelectedRows[0].Cells["TestAppointmentID"].Value;
            Form frm = new frmAddUpdateTestAppointment(TestAppointmentID);
            frm.ShowDialog();
            _Refresh();
        }

        private void smiTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvAppointments.CurrentRow.Cells["TestAppointmentID"].Value;
            Form frm = new frmTakeTest(TestAppointmentID);
            frm.ShowDialog();
            _Refresh();
        }

        private void cmsAppointment_Opening(object sender, CancelEventArgs e)
        {
            bool isLocked = (bool)dgvAppointments.CurrentRow.Cells["IsLocked"].Value;
            if(isLocked)
            {
                smiTakeTest.Enabled = false;
                smiEditTestAppointment.Enabled = false;
            }
            else
            {
                smiTakeTest.Enabled = true;
                smiEditTestAppointment.Enabled = true;
            }
        }
    }
}
