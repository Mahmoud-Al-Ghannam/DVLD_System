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
    public partial class frmShowDriverInfo : Form
    {
        private int _DirverID;
        public frmShowDriverInfo(int DriverID)
        {
            InitializeComponent();
            _DirverID = DriverID;
            ctrlDriverCard1.LoadInfo(_DirverID);
        }
    }
}
