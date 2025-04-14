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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public class PersonEventArgs : EventArgs
        {
            public int PersonID { get; }
            public PersonEventArgs(int PersonID)
            {
                this.PersonID = PersonID;
            }
        }
        public event EventHandler<PersonEventArgs> On_PersonSelected;
        private void _RaiseEventOnPersonSelected(PersonEventArgs e)
        {
            if (On_PersonSelected != null)
                On_PersonSelected?.Invoke(this, e);
        }

        public clsPerson SelectedPerson
        {
            get { return PersonCard.SelectedPerson; }
        }
        public int PersonID
        {
            get { return PersonCard.PersonID; }
        }

        private bool _FilterEnabled;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = value;
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public void LoadInfo(int PersonID , bool FilterEnabled=false)
        {
            PersonCard.LoadInfo(PersonID);
            if (SelectedPerson != null)
            {
                this.FilterEnabled = FilterEnabled;
                cbFilterBy.SelectedIndex = cbFilterBy.FindString("Person ID");
                tbFilterValue.Text = PersonID.ToString();
            }
        }
        public void ResetInfo ()
        {
            PersonCard.ResetInfo();
            FilterEnabled = true;
            cbFilterBy.SelectedIndex = 0;
            tbFilterValue.Text = "";
        }
        
        private void imgSearchForPerson_Click(object sender, EventArgs e)
        {
            string FilterBy = cbFilterBy.Text;
            string FilterValue = tbFilterValue.Text.ToString();

            if (FilterValue == "")
            {
                errorProvider.SetError(tbFilterValue, "This field must to be non-empty");
                return;
            }

            if (FilterBy == "Person ID")
            {
                if (!clsValidation.IsInteger(FilterValue))
                {
                    errorProvider.SetError(tbFilterValue, "Person ID must to be integer");
                    return;
                }

                clsPerson Person = clsPerson.FindPersonByID(Convert.ToInt32(FilterValue));
                if (Person != null)
                {
                    PersonCard.LoadInfo(Person.PersonID);
                }
                else
                {
                    MessageBox.Show($"Person With ID = {FilterValue} is not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (FilterBy == "National NO")
            {
                clsPerson Person = clsPerson.FindPersonByNationalNO(FilterValue);
                if (Person != null)
                {
                    PersonCard.LoadInfo(Person.PersonID);
                }
                else
                {
                    MessageBox.Show($"Person With National NO = {FilterValue} is not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
        }

        private void tbFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (tbFilterValue.Text.Length > 0) errorProvider.SetError(tbFilterValue, "");
        }

        private void pbAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.DataBack += PersonID_DataBackEvent;
            form.ShowDialog();
        }

        private void PersonID_DataBackEvent(object sender, int PersonID)
        {
            LoadInfo(PersonID,true);
        }

        private void PersonCard_On_LoadedPersonInfo(object sender, ctrlPersonCard.PersonEventArgs e)
        {
            _RaiseEventOnPersonSelected(new PersonEventArgs(e.PersonID));
        }
    }
}
