using DVLD.People;
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
    public partial class ctrlDriverCard : UserControl
    {
        public class DriverEventArgs : EventArgs
        {
            public int DriverID { get; }
            public DriverEventArgs(int DriverID)
            {
                this.DriverID = DriverID;
            }
        }
        public event EventHandler<DriverEventArgs> On_LoadedDriverInfo;
        private void _RaiseEventOnLoadedDriverInfo(DriverEventArgs e)
        {
            if (On_LoadedDriverInfo != null)
                On_LoadedDriverInfo?.Invoke(this, e);
        }

        public int DriverID { get; private set; }
        public clsDriver SelectedDriver { get; private set; }

        public ctrlDriverCard()
        {
            InitializeComponent();
            ResetInfo();
        }

        public void LoadInfo(int DriverID)
        {
            SelectedDriver = clsDriver.FindDriverByID(DriverID);

            if (SelectedDriver == null)
            {
                MessageBox.Show($"Error: The driver with ID = {DriverID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DriverID = -1;
                ResetInfo();
            }
            else
            {
                this.DriverID = DriverID;
                _FillInfo();
            }


        }

        public void ResetInfo()
        {
            SelectedDriver = null;
            DriverID = -1;
            lblDriverID.Text = "[?????]";
            lblCreatedDate.Text = "[?????]";
            lblCreatedByUser.Text = "[?????]";
            ctrlPersonCard1.ResetInfo();
        }

        private void _FillInfo()
        {
            lblDriverID.Text = DriverID.ToString();
            lblCreatedDate.Text = SelectedDriver.CreatedDate.ToString();
            lblCreatedByUser.Text = SelectedDriver.CreatedByUserInfo.Username;
            ctrlPersonCard1.LoadInfo(SelectedDriver.PersonID);
            _RaiseEventOnLoadedDriverInfo(new DriverEventArgs(DriverID));
        }

    }
}
