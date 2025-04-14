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

namespace DVLD.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID;
        private clsTestType _TestType;
        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
            _LoadDataToControls();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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


        private void _LoadDataToTestTypeObject()
        {
            _TestType.TestTypeTitle = tbTitle.Text;
            _TestType.TestTypeFees = Convert.ToDecimal(tbFees.Text);
            _TestType.TestTypeDescription = tbDescriptioin.Text;
        }

        private void _LoadDataToControls()
        {
            _TestType = clsTestType.FindTestTypeByID(_TestTypeID);
            lblID.Text = _TestType.TestTypeID.ToString();
            tbTitle.Text = _TestType.TestTypeTitle;
            tbFees.Text = _TestType.TestTypeFees.ToString();
            tbDescriptioin.Text = _TestType.TestTypeDescription.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!_IsDataValidated()) 
            {
                MessageBox.Show("Error: Some fields are incomplete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadDataToTestTypeObject();
            
            if (_TestType.Save()) MessageBox.Show("Test type info is saved successfully", "Save Test Type Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Error: Test type info is not saved", "Save Test Type Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
