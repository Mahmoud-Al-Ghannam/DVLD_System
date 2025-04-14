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

namespace DVLD.Applications.LocalDrivingLicenseApplications
{
    public partial class frmShowLDLApplicationInfo : Form
    {
        private int _LDLApplicationID;
        public frmShowLDLApplicationInfo(int LDLApplicationID)
        {
            InitializeComponent();
            _LDLApplicationID = LDLApplicationID;
            ctrlLDLApplicationInfo1.LoadInfo(_LDLApplicationID);
        }
    }
}
