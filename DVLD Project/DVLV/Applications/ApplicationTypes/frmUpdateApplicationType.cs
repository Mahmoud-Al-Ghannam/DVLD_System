using DVLD_BusinessLayer;
using DVLD.Global_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationType.enApplicationType _ApplicationTypeID;
        private clsApplicationType _ApplicationType;
        public frmUpdateApplicationType(clsApplicationType.enApplicationType applicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = applicationTypeID;
            _LoadDataToControls();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void _LoadDataToControls()
        {
            _ApplicationType = clsApplicationType.FindApplicationTypeByID(_ApplicationTypeID);
            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            tbTitle.Text = _ApplicationType.ApplicationTypeTitle;
            tbFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }
        private void _LoadDataToApplicationTypeObject()
        {
            _ApplicationType.ApplicationTypeTitle = tbTitle.Text;
            _ApplicationType.ApplicationTypeFees = Convert.ToDecimal(tbFees.Text);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_IsDataValidated())
            {
                MessageBox.Show("Error: Some fields are incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDataToApplicationTypeObject();
            if (_ApplicationType.Save()) MessageBox.Show("Application type info is saved successfully", "Save Application Type Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error: Application type info is not saved", "Save Application Type Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool _IsDataValidated()
        {
            if (tbTitle.Text.Length == 0)
            {
                errorProvider.SetError(tbTitle, "This field must to be non-empty");
                return false;
            }
            else errorProvider.SetError(tbTitle, "");


            if (tbFees.Text.Length == 0)
            {
                errorProvider.SetError(tbFees, "This field must to be non-empty");
                return false;
            }
            else if (!clsValidation.IsDecimal(tbFees.Text))
            {
                errorProvider.SetError(tbFees, "The fees must to be real number");
                return false;
            }
            else errorProvider.SetError(tbFees, "");


            return true;
        }
    }
}
