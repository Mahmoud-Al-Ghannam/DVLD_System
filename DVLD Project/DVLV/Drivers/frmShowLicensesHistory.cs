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

namespace DVLD.Drivers
{
    public partial class frmShowLicensesHistory : Form
    {
        public frmShowLicensesHistory(int PersonID)
        {
            InitializeComponent();
            clsDriver Driver = clsDriver.FindDriverByPersonID(PersonID);
            ctrlDriverCard2.LoadInfo(Driver.DriverID);
            ctrlLicensesHistory1.LoadInfo(Driver.DriverID);
        }
    }
}
