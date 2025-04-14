namespace DVLD.Users.Controls
{
    partial class ctrlUserCardWithFilter
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
            this.pbSearchForUser = new System.Windows.Forms.PictureBox();
            this.pbAddNewUser = new System.Windows.Forms.PictureBox();
            this.tbFilterValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.UserCard = new DVLD.Users.Controls.ctrlUserCard();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.pbSearchForUser);
            this.gbFilter.Controls.Add(this.pbAddNewUser);
            this.gbFilter.Controls.Add(this.tbFilterValue);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Controls.Add(this.cbFilterBy);
            this.gbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(6, 14);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(835, 75);
            this.gbFilter.TabIndex = 2;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // pbSearchForUser
            // 
            this.pbSearchForUser.BackgroundImage = global::DVLD.Properties.Resources.SearchPerson;
            this.pbSearchForUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbSearchForUser.Location = new System.Drawing.Point(419, 29);
            this.pbSearchForUser.Margin = new System.Windows.Forms.Padding(5);
            this.pbSearchForUser.Name = "pbSearchForUser";
            this.pbSearchForUser.Size = new System.Drawing.Size(30, 30);
            this.pbSearchForUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSearchForUser.TabIndex = 4;
            this.pbSearchForUser.TabStop = false;
            this.pbSearchForUser.Click += new System.EventHandler(this.pbSearchForUser_Click);
            // 
            // pbAddNewUser
            // 
            this.pbAddNewUser.BackgroundImage = global::DVLD.Properties.Resources.AddPerson_32;
            this.pbAddNewUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbAddNewUser.Location = new System.Drawing.Point(459, 28);
            this.pbAddNewUser.Margin = new System.Windows.Forms.Padding(5);
            this.pbAddNewUser.Name = "pbAddNewUser";
            this.pbAddNewUser.Size = new System.Drawing.Size(32, 32);
            this.pbAddNewUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddNewUser.TabIndex = 3;
            this.pbAddNewUser.TabStop = false;
            this.pbAddNewUser.Click += new System.EventHandler(this.pbAddNewUser_Click);
            // 
            // tbFilterValue
            // 
            this.tbFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilterValue.Location = new System.Drawing.Point(246, 28);
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
            "User ID",
            "Username"});
            this.cbFilterBy.Location = new System.Drawing.Point(89, 27);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(151, 33);
            this.cbFilterBy.TabIndex = 0;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // UserCard
            // 
            this.UserCard.Location = new System.Drawing.Point(3, 95);
            this.UserCard.Name = "UserCard";
            this.UserCard.Size = new System.Drawing.Size(838, 413);
            this.UserCard.TabIndex = 0;
            this.UserCard.On_LoadedUserInfo += new System.EventHandler<DVLD.Users.Controls.ctrlUserCard.UserEventArgs>(this.UserCard_On_LoadedUserInfo);
            // 
            // ctrlUserCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.UserCard);
            this.Name = "ctrlUserCardWithFilter";
            this.Size = new System.Drawing.Size(848, 512);
            this.Load += new System.EventHandler(this.ctrlUserCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchForUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddNewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlUserCard UserCard;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.PictureBox pbSearchForUser;
        private System.Windows.Forms.PictureBox pbAddNewUser;
        private System.Windows.Forms.TextBox tbFilterValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
