using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Tests
{
    public partial class frmShowTestAppointmentInfo : Form
    {
        public frmShowTestAppointmentInfo(int TestAppointmentID)
        {
            InitializeComponent();
            ctrlTestAppointmentInfo1.LoadInfo(TestAppointmentID);
        }
    }
}
