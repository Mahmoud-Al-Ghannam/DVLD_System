using DVLD.GlobalClasses;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD
{
    public partial class frmTest : System.Windows.Forms.Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void btnHash_Click(object sender, EventArgs e)
        {
            tbStrHash.Text = clsUtil.ComputeHash(tbStr.Text.Trim());
            label1.Text = tbStrHash.Text.Length.ToString();
        }
    }
}
