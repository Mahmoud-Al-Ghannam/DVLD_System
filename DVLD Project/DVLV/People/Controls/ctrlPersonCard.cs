using DVLD_BusinessLayer;
using DVLD.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        public class PersonEventArgs : EventArgs
        {
            public int PersonID { get; }
            public PersonEventArgs (int PersonID)
            {
                this.PersonID = PersonID;
            }
        }
        public event EventHandler<PersonEventArgs> On_LoadedPersonInfo;
        private void _RaiseEventOnLoadedPersonInfo (PersonEventArgs e)
        {
            if (On_LoadedPersonInfo != null)
                On_LoadedPersonInfo?.Invoke(this, e);
        }
        
        public clsPerson SelectedPerson { get; private set; }
        public int PersonID { get; private set; }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadInfo (int PersonID)
        { 
            SelectedPerson = clsPerson.FindPersonByID(PersonID);
            if(SelectedPerson == null)
            {
                MessageBox.Show($"Error: The person with ID = {PersonID} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.PersonID = -1;
                ResetInfo ();
            } else
            {
                this.PersonID = PersonID;
                _FillInfo ();
            }
        }

        public void ResetInfo ()
        {
            SelectedPerson = null;
            PersonID = -1;

            lblEditPersonInfo.Enabled = false;
            lblPersonID.Text = "[?????]";
            lblName.Text = "[?????]";
            lblNationalNO.Text = "[?????]";
            lblGendor.Text = "[?????]";
            lblEmail.Text = "[?????]";
            lblPhone.Text = "[?????]";
            lblAddress.Text = "[?????]";
            lblCountry.Text = "[?????]";
            lblDateOfBirth.Text = "[?????]";

            pbPersonImage.Image = Resources.Male_512;
        }

        private void _FillInfo ()
        {
            if(SelectedPerson == null)
            {
                ResetInfo();
                return;
            }

            lblEditPersonInfo.Enabled = true;
            lblPersonID.Text = SelectedPerson.PersonID.ToString();
            lblName.Text = SelectedPerson.FullName;
            lblNationalNO.Text = SelectedPerson.NationalNO;
            lblGendor.Text = SelectedPerson.Gendor.ToString();
            lblEmail.Text = SelectedPerson.Email;
            lblPhone.Text = SelectedPerson.Phone;
            lblAddress.Text = SelectedPerson.Address;
            lblCountry.Text = clsCountry.FindCountryByID(SelectedPerson.NationalityCountryID).CountryName;
            lblDateOfBirth.Text = SelectedPerson.DateOfBirth.ToShortDateString();
            _LoadImage();
            _RaiseEventOnLoadedPersonInfo(new PersonEventArgs(this.PersonID));
        }

        private void _LoadImage ()
        {
            if(SelectedPerson.Gendor == clsPerson.enGendor.Male) 
                pbPersonImage.Image = Resources.Male_512;
            else 
                pbPersonImage.Image = Resources.Female_512;

            if(SelectedPerson.ImagePath != null && SelectedPerson.ImagePath != "")
            {
                if (File.Exists(SelectedPerson.ImagePath))
                    pbPersonImage.ImageLocation = SelectedPerson.ImagePath;
                else
                    MessageBox.Show($"Could not find the image ({SelectedPerson.ImagePath}) of person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SelectedPerson == null) return;
            frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);
            form.ShowDialog();
            LoadInfo(PersonID);
        }
    }
}
