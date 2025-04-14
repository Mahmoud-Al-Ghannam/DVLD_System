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

namespace DVLD.People
{
    public partial class frmShowPersonInfo : System.Windows.Forms.Form
    {
        public int PersonID { get;private set; }
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent(); 
            this.PersonID = PersonID;
            PersonCard.LoadInfo(PersonID);
        }

    }
}
