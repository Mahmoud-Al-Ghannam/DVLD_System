namespace DVLD.People.Controls
{
    partial class ctrlPersonCardWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.pbSearchForPerson = new System.Windows.Forms.PictureBox();
            this.pbAddNewPerson = new System.Windows.Forms.PictureBox();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.PersonCard = new DVLD.People.Controls.ctrlPersonCard();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbSearchForPerson);
            this.gbFilter.Controls.Add(this.pbAddNewPerson);
            this.gbFilter.Controls.Add(this.tbFilterValue);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.cbFilterBy);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(6, 3);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(832, 75);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbSearchForPerson
            // 
            this.pbSearchForPerson.BackgroundImage = global::DVLD.Properties.Resources.SearchPerson;
            this.pbSearchForPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSearchForPerson.Location = new System.Drawing.Point(414, 28);
            this.pbSearchForPerson.Margin = new System.Windows.Forms.Padding(5);
            this.pbSearchForPerson.Name = "pbSearchForPerson";
            this.pbSearchForPerson.Size = new System.Drawing.Size(32, 32);
            this.pbSearchForPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSearchForPerson.TabIndex = 4;
            this.pbSearchForPerson.TabStop = false;
            this.pbSearchForPerson.Click += new System.EventHandler(this.imgSearchForPerson_Click);
            // 
            // pbAddNewPerson
            // 
            this.pbAddNewPerson.BackgroundImage = global::DVLD.Properties.Resources.AddPerson_32;
            this.pbAddNewPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAddNewPerson.Location = new System.Drawing.Point(456, 28);
            this.pbAddNewPerson.Margin = new System.Windows.Forms.Padding(5);
            this.pbAddNewPerson.Name = "pbAddNewPerson";
            this.pbAddNewPerson.Size = new System.Drawing.Size(32, 32);
            this.pbAddNewPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddNewPerson.TabIndex = 3;
            this.pbAddNewPerson.TabStop = false;
            this.pbAddNewPerson.Click += new System.EventHandler(this.pbAddNewPerson_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(241, 28);
            this.tbFilterValue.Name = "tbFilterValue";
            this.tbFilterValue.Size = new System.Drawing.Size(146, 30);
            this.tbFilterValue.TabIndex = 2;
            this.tbFilterValue.TextChanged += new System.EventHandler(this.tbFilterValue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter By:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "Person ID",
            "National NO"});
            this.cbFilterBy.Location = new System.Drawing.Point(84, 27);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(151, 33);
            this.cbFilterBy.TabIndex = 0;
            // 
            // PersonCard
            // 
            this.PersonCard.Location = new System.Drawing.Point(6, 84);
            this.PersonCard.Name = "PersonCard";
            this.PersonCard.Size = new System.Drawing.Size(832, 324);
            this.PersonCard.TabIndex = 0;
            this.PersonCard.On_LoadedPersonInfo += new System.EventHandler<DVLD.People.Controls.ctrlPersonCard.PersonEventArgs>(this.PersonCard_On_LoadedPersonInfo);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.PersonCard);
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(844, 401);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPersonCard PersonCard;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.PictureBox pbSearchForPerson;
        private System.Windows.Forms.PictureBox pbAddNewPerson;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
