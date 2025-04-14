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

namespace DVLD.Tests.TestTypes
{
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
            _RefreshListTestTypes();
        }


        private void _RefreshListTestTypes()
        {
            dgvTestTypes.DataSource = clsTestType.GetAllTestTypes();
            dgvTestTypes.Refresh();
            _FormatDataGridViewOfTestTypes();
            lblNumberOfRecords.Text = dgvTestTypes.RowCount.ToString();
        }

        private void _FormatDataGridViewOfTestTypes()
        {
            dgvTestTypes.Columns["TestTypeID"].HeaderText = "ID";
            dgvTestTypes.Columns["TestTypeID"].Width = 100;

            dgvTestTypes.Columns["TestTypeTitle"].HeaderText = "Title";
            dgvTestTypes.Columns["TestTypeTitle"].Width = 200;

            dgvTestTypes.Columns["TestTypeDescription"].HeaderText = "Description";
            dgvTestTypes.Columns["TestTypeDescription"].Width = 300;

            dgvTestTypes.Columns["TestTypeFees"].HeaderText = "Fees";
            dgvTestTypes.Columns["TestTypeFees"].Width = 100;
        }

        private void smiEditTestType_Click(object sender, EventArgs e)
        {
            clsTestType.enTestType TestTypeID = (clsTestType.enTestType)dgvTestTypes.SelectedRows[0].Cells["TestTypeID"].Value;
            frmUpdateTestType form = new frmUpdateTestType(TestTypeID);
            form.ShowDialog();

            _RefreshListTestTypes();
        }
    }
}
