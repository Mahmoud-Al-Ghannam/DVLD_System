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

namespace DVLD.Drivers.Controls
{
    public partial class ctrlLicensesHistory : UserControl
    {
        public DataTable dtLocalLicenses { get; private set; }
        public DataTable dtInternationalLicenses { get; private set; }
        public int DriverID { get; private set; }
        public ctrlLicensesHistory()
        {
            InitializeComponent();
        }

        public void LoadInfo (int DriverID)
        {
            if(clsDriver.IsDriverExistByID(DriverID))
            {
                this.DriverID = DriverID;
                dtLocalLicenses = clsDriver.GetAllLocalDrivingLicenses(DriverID);
                dtInternationalLicenses = clsDriver.GetAllInternationalDrivingLicenses(DriverID);

                dgvLocalLicenses.DataSource = dtLocalLicenses;
                dgvInternationalLicenses.DataSource = dtInternationalLicenses;

                dgvLocalLicenses.Refresh();
                dgvInternationalLicenses.Refresh();

                lblNumberOfRecordsOfInternationalLicenses.Text = dgvInternationalLicenses.RowCount.ToString();
                lblNumberOfRecordsOfLocalLicenses.Text = dgvLocalLicenses.RowCount.ToString();
            } else
            {
                MessageBox.Show($"Error: The driver with ID = {DriverID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DriverID = -1;
                dtInternationalLicenses = dtLocalLicenses = null;

                lblNumberOfRecordsOfInternationalLicenses.Text = "0";
                lblNumberOfRecordsOfLocalLicenses.Text = "0";
            }
        }
    }
}
