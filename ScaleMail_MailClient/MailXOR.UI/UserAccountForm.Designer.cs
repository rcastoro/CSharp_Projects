namespace MailXOR.UI
{
    partial class UserAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._outSSLChkBx = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._outPortTxt = new System.Windows.Forms.TextBox();
            this._outServerTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._protocolLbl = new System.Windows.Forms.Label();
            this._inProtocolCbo = new System.Windows.Forms.ComboBox();
            this._inSSLChkBx = new System.Windows.Forms.CheckBox();
            this._serverLbl = new System.Windows.Forms.Label();
            this._inPortTxt = new System.Windows.Forms.TextBox();
            this._inServerTxt = new System.Windows.Forms.TextBox();
            this._portLbl = new System.Windows.Forms.Label();
            this._presetAccountsCboBx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this._saveSettingsBtn = new System.Windows.Forms.Button();
            this._testSettingsBtn = new System.Windows.Forms.Button();
            this._usernameLbl = new System.Windows.Forms.Label();
            this._passwordLbl = new System.Windows.Forms.Label();
            this._passwordTxt = new System.Windows.Forms.TextBox();
            this._usernameTxt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._presetAccountsCboBx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this._saveSettingsBtn);
            this.groupBox1.Controls.Add(this._testSettingsBtn);
            this.groupBox1.Controls.Add(this._usernameLbl);
            this.groupBox1.Controls.Add(this._passwordLbl);
            this.groupBox1.Controls.Add(this._passwordTxt);
            this.groupBox1.Controls.Add(this._usernameTxt);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configure mail settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._outSSLChkBx);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this._outPortTxt);
            this.groupBox3.Controls.Add(this._outServerTxt);
            this.groupBox3.Location = new System.Drawing.Point(6, 247);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 99);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Outgoing Mail";
            // 
            // _outSSLChkBx
            // 
            this._outSSLChkBx.AutoSize = true;
            this._outSSLChkBx.Location = new System.Drawing.Point(64, 77);
            this._outSSLChkBx.Name = "_outSSLChkBx";
            this._outSSLChkBx.Size = new System.Drawing.Size(46, 17);
            this._outSSLChkBx.TabIndex = 14;
            this._outSSLChkBx.Text = "SSL";
            this._outSSLChkBx.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Outgoing Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Outgoing Port:";
            // 
            // _outPortTxt
            // 
            this._outPortTxt.Location = new System.Drawing.Point(106, 51);
            this._outPortTxt.Name = "_outPortTxt";
            this._outPortTxt.Size = new System.Drawing.Size(120, 20);
            this._outPortTxt.TabIndex = 18;
            // 
            // _outServerTxt
            // 
            this._outServerTxt.Location = new System.Drawing.Point(106, 24);
            this._outServerTxt.Name = "_outServerTxt";
            this._outServerTxt.Size = new System.Drawing.Size(120, 20);
            this._outServerTxt.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._protocolLbl);
            this.groupBox2.Controls.Add(this._inProtocolCbo);
            this.groupBox2.Controls.Add(this._inSSLChkBx);
            this.groupBox2.Controls.Add(this._serverLbl);
            this.groupBox2.Controls.Add(this._inPortTxt);
            this.groupBox2.Controls.Add(this._inServerTxt);
            this.groupBox2.Controls.Add(this._portLbl);
            this.groupBox2.Location = new System.Drawing.Point(6, 129);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 110);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Incoming Mail";
            // 
            // _protocolLbl
            // 
            this._protocolLbl.AutoSize = true;
            this._protocolLbl.Location = new System.Drawing.Point(4, 27);
            this._protocolLbl.Name = "_protocolLbl";
            this._protocolLbl.Size = new System.Drawing.Size(102, 13);
            this._protocolLbl.TabIndex = 1;
            this._protocolLbl.Text = "Mail server protocol:";
            // 
            // _inProtocolCbo
            // 
            this._inProtocolCbo.FormattingEnabled = true;
            this._inProtocolCbo.Items.AddRange(new object[] {
            "POP3",
            "IMAP"});
            this._inProtocolCbo.Location = new System.Drawing.Point(105, 24);
            this._inProtocolCbo.Name = "_inProtocolCbo";
            this._inProtocolCbo.Size = new System.Drawing.Size(87, 21);
            this._inProtocolCbo.TabIndex = 2;
            // 
            // _inSSLChkBx
            // 
            this._inSSLChkBx.AutoSize = true;
            this._inSSLChkBx.Location = new System.Drawing.Point(203, 26);
            this._inSSLChkBx.Name = "_inSSLChkBx";
            this._inSSLChkBx.Size = new System.Drawing.Size(46, 17);
            this._inSSLChkBx.TabIndex = 4;
            this._inSSLChkBx.Text = "SSL";
            this._inSSLChkBx.UseVisualStyleBackColor = true;
            // 
            // _serverLbl
            // 
            this._serverLbl.AutoSize = true;
            this._serverLbl.Location = new System.Drawing.Point(19, 54);
            this._serverLbl.Name = "_serverLbl";
            this._serverLbl.Size = new System.Drawing.Size(87, 13);
            this._serverLbl.TabIndex = 5;
            this._serverLbl.Text = "Incoming Server:";
            // 
            // _inPortTxt
            // 
            this._inPortTxt.Location = new System.Drawing.Point(105, 78);
            this._inPortTxt.Name = "_inPortTxt";
            this._inPortTxt.Size = new System.Drawing.Size(120, 20);
            this._inPortTxt.TabIndex = 13;
            // 
            // _inServerTxt
            // 
            this._inServerTxt.Location = new System.Drawing.Point(105, 51);
            this._inServerTxt.Name = "_inServerTxt";
            this._inServerTxt.Size = new System.Drawing.Size(120, 20);
            this._inServerTxt.TabIndex = 6;
            // 
            // _portLbl
            // 
            this._portLbl.AutoSize = true;
            this._portLbl.Location = new System.Drawing.Point(32, 81);
            this._portLbl.Name = "_portLbl";
            this._portLbl.Size = new System.Drawing.Size(75, 13);
            this._portLbl.TabIndex = 12;
            this._portLbl.Text = "Incoming Port:";
            // 
            // _presetAccountsCboBx
            // 
            this._presetAccountsCboBx.FormattingEnabled = true;
            this._presetAccountsCboBx.Items.AddRange(new object[] {
            "",
            "Hotmail",
            "Gmail",
            "Outlook"});
            this._presetAccountsCboBx.Location = new System.Drawing.Point(13, 43);
            this._presetAccountsCboBx.Name = "_presetAccountsCboBx";
            this._presetAccountsCboBx.Size = new System.Drawing.Size(247, 21);
            this._presetAccountsCboBx.TabIndex = 16;
            this._presetAccountsCboBx.SelectedIndexChanged += new System.EventHandler(this._presetAccountsCboBx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "What kind of mail account would you like to set up?";
            // 
            // _saveSettingsBtn
            // 
            this._saveSettingsBtn.Location = new System.Drawing.Point(175, 352);
            this._saveSettingsBtn.Name = "_saveSettingsBtn";
            this._saveSettingsBtn.Size = new System.Drawing.Size(99, 23);
            this._saveSettingsBtn.TabIndex = 14;
            this._saveSettingsBtn.Text = "Save Settings";
            this._saveSettingsBtn.UseVisualStyleBackColor = true;
            this._saveSettingsBtn.Click += new System.EventHandler(this._saveSettingsBtn_Click);
            // 
            // _testSettingsBtn
            // 
            this._testSettingsBtn.Location = new System.Drawing.Point(70, 352);
            this._testSettingsBtn.Name = "_testSettingsBtn";
            this._testSettingsBtn.Size = new System.Drawing.Size(99, 23);
            this._testSettingsBtn.TabIndex = 11;
            this._testSettingsBtn.Text = "Test Settings";
            this._testSettingsBtn.UseVisualStyleBackColor = true;
            this._testSettingsBtn.Click += new System.EventHandler(this._testSettingsBtn_Click);
            // 
            // _usernameLbl
            // 
            this._usernameLbl.AutoSize = true;
            this._usernameLbl.Location = new System.Drawing.Point(45, 71);
            this._usernameLbl.Name = "_usernameLbl";
            this._usernameLbl.Size = new System.Drawing.Size(58, 13);
            this._usernameLbl.TabIndex = 7;
            this._usernameLbl.Text = "Username:";
            // 
            // _passwordLbl
            // 
            this._passwordLbl.AutoSize = true;
            this._passwordLbl.Location = new System.Drawing.Point(48, 98);
            this._passwordLbl.Name = "_passwordLbl";
            this._passwordLbl.Size = new System.Drawing.Size(56, 13);
            this._passwordLbl.TabIndex = 9;
            this._passwordLbl.Text = "Password:";
            // 
            // _passwordTxt
            // 
            this._passwordTxt.Location = new System.Drawing.Point(104, 95);
            this._passwordTxt.Name = "_passwordTxt";
            this._passwordTxt.PasswordChar = '.';
            this._passwordTxt.Size = new System.Drawing.Size(155, 20);
            this._passwordTxt.TabIndex = 10;
            // 
            // _usernameTxt
            // 
            this._usernameTxt.Location = new System.Drawing.Point(104, 68);
            this._usernameTxt.Name = "_usernameTxt";
            this._usernameTxt.Size = new System.Drawing.Size(155, 20);
            this._usernameTxt.TabIndex = 8;
            // 
            // UserAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 386);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserAccountForm";
            this.ShowInTaskbar = false;
            this.Text = "ScaleMail - Account Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox _inProtocolCbo;
        private System.Windows.Forms.Label _protocolLbl;
        private System.Windows.Forms.Label _serverLbl;
        private System.Windows.Forms.CheckBox _inSSLChkBx;
        private System.Windows.Forms.TextBox _inServerTxt;
        private System.Windows.Forms.TextBox _usernameTxt;
        private System.Windows.Forms.Label _usernameLbl;
        private System.Windows.Forms.TextBox _passwordTxt;
        private System.Windows.Forms.Label _passwordLbl;
        private System.Windows.Forms.Button _testSettingsBtn;
        private System.Windows.Forms.TextBox _inPortTxt;
        private System.Windows.Forms.Label _portLbl;
        private System.Windows.Forms.Button _saveSettingsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _presetAccountsCboBx;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox _outSSLChkBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _outPortTxt;
        private System.Windows.Forms.TextBox _outServerTxt;
    }
}

