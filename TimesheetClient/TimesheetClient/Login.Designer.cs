namespace TimesheetClient
{
    partial class Login
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
            this._grpBxRegister = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this._txtBxEmployeeToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this._lblError = new System.Windows.Forms.Label();
            this._grpBxRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // _grpBxRegister
            // 
            this._grpBxRegister.Controls.Add(this._lblError);
            this._grpBxRegister.Controls.Add(this.label5);
            this._grpBxRegister.Controls.Add(this._txtBxEmployeeToken);
            this._grpBxRegister.Location = new System.Drawing.Point(12, 57);
            this._grpBxRegister.Name = "_grpBxRegister";
            this._grpBxRegister.Size = new System.Drawing.Size(411, 62);
            this._grpBxRegister.TabIndex = 8;
            this._grpBxRegister.TabStop = false;
            this._grpBxRegister.Text = "Login:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Employee Token:";
            // 
            // _txtBxEmployeeToken
            // 
            this._txtBxEmployeeToken.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._txtBxEmployeeToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._txtBxEmployeeToken.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtBxEmployeeToken.ForeColor = System.Drawing.SystemColors.Desktop;
            this._txtBxEmployeeToken.Location = new System.Drawing.Point(146, 26);
            this._txtBxEmployeeToken.Name = "_txtBxEmployeeToken";
            this._txtBxEmployeeToken.Size = new System.Drawing.Size(243, 21);
            this._txtBxEmployeeToken.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "The name or email entered is already in use.";
            // 
            // _btnLogin
            // 
            this._btnLogin.Location = new System.Drawing.Point(348, 125);
            this._btnLogin.Name = "_btnLogin";
            this._btnLogin.Size = new System.Drawing.Size(75, 23);
            this._btnLogin.TabIndex = 9;
            this._btnLogin.Text = "Login";
            this._btnLogin.UseVisualStyleBackColor = true;
            this._btnLogin.Click += new System.EventHandler(this._btnLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "Enter your employee token supplied to you while registering.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 130);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(207, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Request e-mail containing employee token";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // _lblError
            // 
            this._lblError.AutoSize = true;
            this._lblError.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblError.ForeColor = System.Drawing.Color.Red;
            this._lblError.Location = new System.Drawing.Point(142, 11);
            this._lblError.Name = "_lblError";
            this._lblError.Size = new System.Drawing.Size(0, 13);
            this._lblError.TabIndex = 4;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 152);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._btnLogin);
            this.Controls.Add(this._grpBxRegister);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please enter employee token";
            this._grpBxRegister.ResumeLayout(false);
            this._grpBxRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _grpBxRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _txtBxEmployeeToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label _lblError;
    }
}