using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;

namespace DVLD.Applications
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationType_Load(object sender, EventArgs e)
        {
            _RefreshListApplicationTypes();
        }

        private void _RefreshListApplicationTypes()
        {
            dgvApplicationTypes.DataSource = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.Refresh();
            _FormatDataGridViewOfApplicationTypes();
            lblNumberOfRecords.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void _FormatDataGridViewOfApplicationTypes()
        {
            dgvApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
            dgvApplicationTypes.Columns["ApplicationTypeID"].Width = 100;

            dgvApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].Width = 300;

            dgvApplicationTypes.Columns["ApplicationTypeFees"].HeaderText = "Fees";
            dgvApplicationTypes.Columns["ApplicationTypeFees"].Width = 100;

        }

        private void smiEditApplicationType_Click(object sender, EventArgs e)
        {
            clsApplicationType.enApplicationType ApplicationTypeID = (clsApplicationType.enApplicationType)dgvApplicationTypes.SelectedRows[0].Cells["ApplicationTypeID"].Value;
            frmUpdateApplicationType form = new frmUpdateApplicationType(ApplicationTypeID);
            form.ShowDialog();

            _RefreshListApplicationTypes();
        }

        private void cmsApplicationType_Opening(object sender, CancelEventArgs e)
        {
            if (dgvApplicationTypes.RowCount == 0) cmsApplicationType.Enabled = false;
        }
    }
}
