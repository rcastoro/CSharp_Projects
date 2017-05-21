namespace MailXOR
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._mailProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._newToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._editAccountSettingsToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composeEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sendAndRecieveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._listboxInbox = new System.Windows.Forms.ListBox();
            this._emailViewWindow = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._listboxFolders = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._inboxTitleTextbox = new System.Windows.Forms.TextBox();
            this._accountToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._replyPictureBtn = new System.Windows.Forms.PictureBox();
            this._fromValueLabel = new System.Windows.Forms.Label();
            this._fromLabel = new System.Windows.Forms.Label();
            this._receivedOnLabel = new System.Windows.Forms.Label();
            this._receivedOnValueLabel = new System.Windows.Forms.Label();
            this._emailTitleLbl = new System.Windows.Forms.Label();
            this._mailBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._updateMailBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._statusStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this._accountToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._replyPictureBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mailProgressBar});
            this._statusStrip.Location = new System.Drawing.Point(0, 620);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(964, 22);
            this._statusStrip.TabIndex = 0;
            // 
            // _mailProgressBar
            // 
            this._mailProgressBar.Name = "_mailProgressBar";
            this._mailProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // _menuStrip
            // 
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._editToolStripMenuItem,
            this.composeEmailToolStripMenuItem,
            this._sendAndRecieveToolStripMenuItem,
            this._helpToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(964, 24);
            this._menuStrip.TabIndex = 1;
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripSubMenuItem,
            this._newToolStripSubMenuItem,
            this._saveToolStripSubMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _openToolStripSubMenuItem
            // 
            this._openToolStripSubMenuItem.Name = "_openToolStripSubMenuItem";
            this._openToolStripSubMenuItem.Size = new System.Drawing.Size(103, 22);
            this._openToolStripSubMenuItem.Text = "Open";
            // 
            // _newToolStripSubMenuItem
            // 
            this._newToolStripSubMenuItem.Name = "_newToolStripSubMenuItem";
            this._newToolStripSubMenuItem.Size = new System.Drawing.Size(103, 22);
            this._newToolStripSubMenuItem.Text = "New";
            // 
            // _saveToolStripSubMenuItem
            // 
            this._saveToolStripSubMenuItem.Name = "_saveToolStripSubMenuItem";
            this._saveToolStripSubMenuItem.Size = new System.Drawing.Size(103, 22);
            this._saveToolStripSubMenuItem.Text = "Save";
            // 
            // _editToolStripMenuItem
            // 
            this._editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editAccountSettingsToolStripSubMenuItem});
            this._editToolStripMenuItem.Name = "_editToolStripMenuItem";
            this._editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this._editToolStripMenuItem.Text = "Edit";
            // 
            // _editAccountSettingsToolStripSubMenuItem
            // 
            this._editAccountSettingsToolStripSubMenuItem.Name = "_editAccountSettingsToolStripSubMenuItem";
            this._editAccountSettingsToolStripSubMenuItem.Size = new System.Drawing.Size(164, 22);
            this._editAccountSettingsToolStripSubMenuItem.Text = "Account Settings";
            this._editAccountSettingsToolStripSubMenuItem.Click += new System.EventHandler(this._editAccountSettingsToolStripSubMenuItem_Click);
            // 
            // composeEmailToolStripMenuItem
            // 
            this.composeEmailToolStripMenuItem.Image = global::MailXOR.Properties.Resources.appbar_arrow_left_right;
            this.composeEmailToolStripMenuItem.Name = "composeEmailToolStripMenuItem";
            this.composeEmailToolStripMenuItem.Size = new System.Drawing.Size(154, 20);
            this.composeEmailToolStripMenuItem.Text = "MailEngine.SendMail()";
            this.composeEmailToolStripMenuItem.Click += new System.EventHandler(this.composeEmailToolStripMenuItem_Click);
            // 
            // _sendAndRecieveToolStripMenuItem
            // 
            this._sendAndRecieveToolStripMenuItem.Image = global::MailXOR.Properties.Resources.appbar_arrow_left_right;
            this._sendAndRecieveToolStripMenuItem.Name = "_sendAndRecieveToolStripMenuItem";
            this._sendAndRecieveToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this._sendAndRecieveToolStripMenuItem.Text = "MailEngine.GetMail();";
            this._sendAndRecieveToolStripMenuItem.Click += new System.EventHandler(this._sendAndRecieveToolStripMenuItem_Click);
            // 
            // _helpToolStripMenuItem
            // 
            this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripSubMenuItem});
            this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
            this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._helpToolStripMenuItem.Text = "Help";
            // 
            // _aboutToolStripSubMenuItem
            // 
            this._aboutToolStripSubMenuItem.Name = "_aboutToolStripSubMenuItem";
            this._aboutToolStripSubMenuItem.Size = new System.Drawing.Size(107, 22);
            this._aboutToolStripSubMenuItem.Text = "About";
            this._aboutToolStripSubMenuItem.Click += new System.EventHandler(this._aboutToolStripSubMenuItem_Click);
            // 
            // _listboxInbox
            // 
            this._listboxInbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listboxInbox.BackColor = System.Drawing.Color.Gainsboro;
            this._listboxInbox.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listboxInbox.ForeColor = System.Drawing.Color.Black;
            this._listboxInbox.FormattingEnabled = true;
            this._listboxInbox.ItemHeight = 16;
            this._listboxInbox.Location = new System.Drawing.Point(0, 135);
            this._listboxInbox.Name = "_listboxInbox";
            this._listboxInbox.Size = new System.Drawing.Size(234, 452);
            this._listboxInbox.TabIndex = 2;
            this._listboxInbox.Click += new System.EventHandler(this._listboxInbox_Click);
            this._listboxInbox.SelectedIndexChanged += new System.EventHandler(this._listboxInbox_SelectedIndexChanged);
            this._listboxInbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this._listboxInbox_MouseMove);
            // 
            // _emailViewWindow
            // 
            this._emailViewWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._emailViewWindow.Location = new System.Drawing.Point(-1, 135);
            this._emailViewWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this._emailViewWindow.Name = "_emailViewWindow";
            this._emailViewWindow.Size = new System.Drawing.Size(721, 523);
            this._emailViewWindow.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainer1.Panel1.Controls.Add(this._listboxFolders);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this._listboxInbox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel2.Controls.Add(this._accountToolStrip);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this._emailViewWindow);
            this.splitContainer1.Size = new System.Drawing.Size(964, 590);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 6;
            // 
            // _listboxFolders
            // 
            this._listboxFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listboxFolders.FormattingEnabled = true;
            this._listboxFolders.Location = new System.Drawing.Point(0, 42);
            this._listboxFolders.Name = "_listboxFolders";
            this._listboxFolders.Size = new System.Drawing.Size(234, 95);
            this._listboxFolders.TabIndex = 4;
            this._listboxFolders.SelectedIndexChanged += new System.EventHandler(this._listboxFolders_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this._inboxTitleTextbox);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 42);
            this.panel2.TabIndex = 3;
            // 
            // _inboxTitleTextbox
            // 
            this._inboxTitleTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._inboxTitleTextbox.BackColor = System.Drawing.SystemColors.HotTrack;
            this._inboxTitleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._inboxTitleTextbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._inboxTitleTextbox.Font = new System.Drawing.Font("Gisha", 18.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._inboxTitleTextbox.ForeColor = System.Drawing.Color.White;
            this._inboxTitleTextbox.Location = new System.Drawing.Point(42, 7);
            this._inboxTitleTextbox.Name = "_inboxTitleTextbox";
            this._inboxTitleTextbox.Size = new System.Drawing.Size(148, 29);
            this._inboxTitleTextbox.TabIndex = 1;
            this._inboxTitleTextbox.Text = "Mailbox";
            this._inboxTitleTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this._inboxTitleTextbox.TextChanged += new System.EventHandler(this._inboxTitleTextbox_TextChanged);
            // 
            // _accountToolStrip
            // 
            this._accountToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this._accountToolStrip.Location = new System.Drawing.Point(0, 0);
            this._accountToolStrip.Name = "_accountToolStrip";
            this._accountToolStrip.Size = new System.Drawing.Size(723, 25);
            this._accountToolStrip.TabIndex = 4;
            this._accountToolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Accounts: ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this._replyPictureBtn);
            this.panel1.Controls.Add(this._fromValueLabel);
            this.panel1.Controls.Add(this._fromLabel);
            this.panel1.Controls.Add(this._receivedOnLabel);
            this.panel1.Controls.Add(this._receivedOnValueLabel);
            this.panel1.Controls.Add(this._emailTitleLbl);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(-1, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 111);
            this.panel1.TabIndex = 3;
            // 
            // _replyPictureBtn
            // 
            this._replyPictureBtn.Image = global::MailXOR.Properties.Resources.replyMail1;
            this._replyPictureBtn.Location = new System.Drawing.Point(11, 58);
            this._replyPictureBtn.Name = "_replyPictureBtn";
            this._replyPictureBtn.Size = new System.Drawing.Size(46, 29);
            this._replyPictureBtn.TabIndex = 8;
            this._replyPictureBtn.TabStop = false;
            this._replyPictureBtn.Visible = false;
            this._replyPictureBtn.Click += new System.EventHandler(this._replyPictureBtn_Click);
            // 
            // _fromValueLabel
            // 
            this._fromValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._fromValueLabel.AutoSize = true;
            this._fromValueLabel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._fromValueLabel.ForeColor = System.Drawing.Color.White;
            this._fromValueLabel.Location = new System.Drawing.Point(132, 55);
            this._fromValueLabel.Name = "_fromValueLabel";
            this._fromValueLabel.Size = new System.Drawing.Size(0, 13);
            this._fromValueLabel.TabIndex = 7;
            this._fromValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._fromValueLabel.Click += new System.EventHandler(this._fromValueLabel_Click);
            this._fromValueLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this._fromValueLabel_MouseMove);
            // 
            // _fromLabel
            // 
            this._fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._fromLabel.AutoSize = true;
            this._fromLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._fromLabel.ForeColor = System.Drawing.Color.White;
            this._fromLabel.Location = new System.Drawing.Point(69, 55);
            this._fromLabel.Name = "_fromLabel";
            this._fromLabel.Size = new System.Drawing.Size(60, 13);
            this._fromLabel.TabIndex = 6;
            this._fromLabel.Text = "Sent By:";
            this._fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._fromLabel.Visible = false;
            // 
            // _receivedOnLabel
            // 
            this._receivedOnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._receivedOnLabel.AutoSize = true;
            this._receivedOnLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._receivedOnLabel.ForeColor = System.Drawing.Color.White;
            this._receivedOnLabel.Location = new System.Drawing.Point(69, 75);
            this._receivedOnLabel.Name = "_receivedOnLabel";
            this._receivedOnLabel.Size = new System.Drawing.Size(91, 13);
            this._receivedOnLabel.TabIndex = 5;
            this._receivedOnLabel.Text = "Received On:";
            this._receivedOnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._receivedOnLabel.Visible = false;
            // 
            // _receivedOnValueLabel
            // 
            this._receivedOnValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._receivedOnValueLabel.AutoSize = true;
            this._receivedOnValueLabel.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._receivedOnValueLabel.ForeColor = System.Drawing.Color.White;
            this._receivedOnValueLabel.Location = new System.Drawing.Point(162, 76);
            this._receivedOnValueLabel.Name = "_receivedOnValueLabel";
            this._receivedOnValueLabel.Size = new System.Drawing.Size(0, 13);
            this._receivedOnValueLabel.TabIndex = 4;
            this._receivedOnValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _emailTitleLbl
            // 
            this._emailTitleLbl.AutoSize = true;
            this._emailTitleLbl.Font = new System.Drawing.Font("Microsoft Tai Le", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._emailTitleLbl.ForeColor = System.Drawing.Color.White;
            this._emailTitleLbl.Location = new System.Drawing.Point(15, 10);
            this._emailTitleLbl.Name = "_emailTitleLbl";
            this._emailTitleLbl.Size = new System.Drawing.Size(0, 32);
            this._emailTitleLbl.TabIndex = 3;
            // 
            // _mailBackgroundWorker
            // 
            this._mailBackgroundWorker.WorkerReportsProgress = true;
            this._mailBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._mailBackgroundWorker_DoWork);
            this._mailBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._mailBackgroundWorker_ProgressChanged);
            this._mailBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._mailBackgroundWorker_RunWorkerCompleted);
            // 
            // _updateMailBackgroundWorker
            // 
            this._updateMailBackgroundWorker.WorkerReportsProgress = true;
            this._updateMailBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._updateMailBackgroundWorker_DoWork);
            this._updateMailBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._updateMailBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 642);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._statusStrip);
            this.Controls.Add(this._menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this._menuStrip;
            this.Name = "MainForm";
            this.Text = "ScaleMail - By Rocco Castoro";
            this.Load += new System.EventHandler(this.MainForm_Shown);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this._accountToolStrip.ResumeLayout(false);
            this._accountToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._replyPictureBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _newToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _editAccountSettingsToolStripSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _sendAndRecieveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutToolStripSubMenuItem;
        private System.Windows.Forms.ListBox _listboxInbox;
        private System.Windows.Forms.WebBrowser _emailViewWindow;
        private System.Windows.Forms.ToolStripMenuItem composeEmailToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _emailTitleLbl;
        private System.Windows.Forms.TextBox _inboxTitleTextbox;
        private System.Windows.Forms.ToolStripProgressBar _mailProgressBar;
        private System.ComponentModel.BackgroundWorker _mailBackgroundWorker;
        private System.ComponentModel.BackgroundWorker _updateMailBackgroundWorker;
        private System.Windows.Forms.ListBox _listboxFolders;
        private System.Windows.Forms.Label _receivedOnValueLabel;
        private System.Windows.Forms.Label _receivedOnLabel;
        private System.Windows.Forms.Label _fromLabel;
        private System.Windows.Forms.Label _fromValueLabel;
        private System.Windows.Forms.PictureBox _replyPictureBtn;
        private System.Windows.Forms.ToolStrip _accountToolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

