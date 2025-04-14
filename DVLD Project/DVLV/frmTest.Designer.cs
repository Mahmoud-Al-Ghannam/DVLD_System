namespace DVLD
{
    partial class frmTest
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
            this.tbStr = new System.Windows.Forms.TextBox();
            this.tbStrHash = new System.Windows.Forms.TextBox();
            this.btnHash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbStr
            // 
            this.tbStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStr.Location = new System.Drawing.Point(14, 39);
            this.tbStr.Margin = new System.Windows.Forms.Padding(5);
            this.tbStr.Name = "tbStr";
            this.tbStr.Size = new System.Drawing.Size(638, 30);
            this.tbStr.TabIndex = 11;
            // 
            // tbStrHash
            // 
            this.tbStrHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStrHash.Location = new System.Drawing.Point(14, 79);
            this.tbStrHash.Margin = new System.Windows.Forms.Padding(5);
            this.tbStrHash.Name = "tbStrHash";
            this.tbStrHash.Size = new System.Drawing.Size(638, 30);
            this.tbStrHash.TabIndex = 10;
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(115, 280);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(124, 57);
            this.btnHash.TabIndex = 12;
            this.btnHash.Text = "Hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(666, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.tbStr);
            this.Controls.Add(this.tbStrHash);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStr;
        private System.Windows.Forms.TextBox tbStrHash;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Label label1;
    }
}

