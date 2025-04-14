namespace DVLD.People
{
    partial class frmListPeople
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPeople));
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.cmsPerson = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smiShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.smiAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.smiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.cmsPerson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.White;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.cmsPerson;
            resources.ApplyResources(this.dgvPeople, "dgvPeople");
            this.dgvPeople.MultiSelect = false;
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // cmsPerson
            // 
            this.cmsPerson.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsPerson.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiShowDetails,
            this.toolStripSeparator1,
            this.smiAddNewPerson,
            this.smiEdit,
            this.smiDelete});
            this.cmsPerson.Name = "cmsPerson";
            resources.ApplyResources(this.cmsPerson, "cmsPerson");
            this.cmsPerson.Opening += new System.ComponentModel.CancelEventHandler(this.cmsPerson_Opening);
            // 
            // smiShowDetails
            // 
            this.smiShowDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.smiShowDetails.Name = "smiShowDetails";
            resources.ApplyResources(this.smiShowDetails, "smiShowDetails");
            this.smiShowDetails.Click += new System.EventHandler(this.smiShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // smiAddNewPerson
            // 
            this.smiAddNewPerson.Image = global::DVLD.Properties.Resources.AddPerson_32;
            this.smiAddNewPerson.Name = "smiAddNewPerson";
            resources.ApplyResources(this.smiAddNewPerson, "smiAddNewPerson");
            this.smiAddNewPerson.Click += new System.EventHandler(this.smiAddNewPerson_Click);
            // 
            // smiEdit
            // 
            this.smiEdit.Image = global::DVLD.Properties.Resources.edit_32;
            this.smiEdit.Name = "smiEdit";
            resources.ApplyResources(this.smiEdit, "smiEdit");
            this.smiEdit.Click += new System.EventHandler(this.smiEdit_Click);
            // 
            // smiDelete
            // 
            this.smiDelete.Image = global::DVLD.Properties.Resources.Delete_32;
            this.smiDelete.Name = "smiDelete";
            resources.ApplyResources(this.smiDelete, "smiDelete");
            this.smiDelete.Click += new System.EventHandler(this.smiDelete_Click);
            // 
            // tbFilterValue
            // 
            resources.ApplyResources(this.tbFilterValue, "tbFilterValue");
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            this.tbFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterValue_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.DropDownWidth = 200;
            resources.ApplyResources(this.cbFilterBy, "cbFilterBy");
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            resources.GetString("cbFilterBy.Items"),
            resources.GetString("cbFilterBy.Items1"),
            resources.GetString("cbFilterBy.Items2"),
            resources.GetString("cbFilterBy.Items3"),
            resources.GetString("cbFilterBy.Items4"),
            resources.GetString("cbFilterBy.Items5"),
            resources.GetString("cbFilterBy.Items6"),
            resources.GetString("cbFilterBy.Items7"),
            resources.GetString("cbFilterBy.Items8"),
            resources.GetString("cbFilterBy.Items9"),
            resources.GetString("cbFilterBy.Items10"),
            resources.GetString("cbFilterBy.Items11"),
            resources.GetString("cbFilterBy.Items12")});
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.People_64;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Name = "label2";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.BackgroundImage = global::DVLD.Properties.Resources.AddPerson_32;
            resources.ApplyResources(this.btnAddNewPerson, "btnAddNewPerson");
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.btnAddNewPerson_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblNumberOfRecords
            // 
            resources.ApplyResources(this.lblNumberOfRecords, "lblNumberOfRecords");
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            // 
            // frmListPeople
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewPerson);
            this.Controls.Add(this.tbFilterValue);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dgvPeople);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmListPeople";
            this.Load += new System.EventHandler(this.frmPeopleManagment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.cmsPerson.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.ContextMenuStrip cmsPerson;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ToolStripMenuItem smiEdit;
        private System.Windows.Forms.ToolStripMenuItem smiAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem smiDelete;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem smiShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfRecords;
    }
}