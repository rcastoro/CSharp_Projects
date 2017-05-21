namespace MailXOR.UI
{
    partial class ComposeEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComposeEmail));
            this._composeEmailPanel = new System.Windows.Forms.Panel();
            this._emailBodyWebBrowser = new System.Windows.Forms.WebBrowser();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._openAttachmentDialog = new System.Windows.Forms.OpenFileDialog();
            this._sendToTxt = new System.Windows.Forms.TextBox();
            this._sendToLbl = new System.Windows.Forms.Label();
            this._subjectLbl = new System.Windows.Forms.Label();
            this._sendSubjectTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._attachmentQuantityLbl = new System.Windows.Forms.Label();
            this._attachmentsLbl = new System.Windows.Forms.Label();
            this._sendMailBtn = new System.Windows.Forms.PictureBox();
            this._addAttachmentBtn = new System.Windows.Forms.PictureBox();
            this._composeEmailPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._sendMailBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._addAttachmentBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // _composeEmailPanel
            // 
            this._composeEmailPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._composeEmailPanel.Controls.Add(this._emailBodyWebBrowser);
            this._composeEmailPanel.Controls.Add(this.label3);
            this._composeEmailPanel.Controls.Add(this.label2);
            this._composeEmailPanel.Controls.Add(this.label1);
            this._composeEmailPanel.Location = new System.Drawing.Point(26, 0);
            this._composeEmailPanel.Name = "_composeEmailPanel";
            this._composeEmailPanel.Size = new System.Drawing.Size(706, 481);
            this._composeEmailPanel.TabIndex = 0;
            // 
            // _emailBodyWebBrowser
            // 
            this._emailBodyWebBrowser.Location = new System.Drawing.Point(0, 66);
            this._emailBodyWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this._emailBodyWebBrowser.Name = "_emailBodyWebBrowser";
            this._emailBodyWebBrowser.Size = new System.Drawing.Size(706, 415);
            this._emailBodyWebBrowser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(214, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "();";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(-1, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "new";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(57, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "ComposeEmail";
            // 
            // _openAttachmentDialog
            // 
            this._openAttachmentDialog.FileName = "openFileDialog1";
            // 
            // _sendToTxt
            // 
            this._sendToTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._sendToTxt.Location = new System.Drawing.Point(65, 3);
            this._sendToTxt.Name = "_sendToTxt";
            this._sendToTxt.Size = new System.Drawing.Size(640, 20);
            this._sendToTxt.TabIndex = 6;
            // 
            // _sendToLbl
            // 
            this._sendToLbl.AutoSize = true;
            this._sendToLbl.Location = new System.Drawing.Point(36, 6);
            this._sendToLbl.Name = "_sendToLbl";
            this._sendToLbl.Size = new System.Drawing.Size(26, 13);
            this._sendToLbl.TabIndex = 7;
            this._sendToLbl.Text = "To: ";
            // 
            // _subjectLbl
            // 
            this._subjectLbl.AutoSize = true;
            this._subjectLbl.Location = new System.Drawing.Point(13, 28);
            this._subjectLbl.Name = "_subjectLbl";
            this._subjectLbl.Size = new System.Drawing.Size(46, 13);
            this._subjectLbl.TabIndex = 8;
            this._subjectLbl.Text = "Subject:";
            // 
            // _sendSubjectTxt
            // 
            this._sendSubjectTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._sendSubjectTxt.Location = new System.Drawing.Point(65, 25);
            this._sendSubjectTxt.Name = "_sendSubjectTxt";
            this._sendSubjectTxt.Size = new System.Drawing.Size(640, 20);
            this._sendSubjectTxt.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this._attachmentQuantityLbl);
            this.panel1.Controls.Add(this._attachmentsLbl);
            this.panel1.Controls.Add(this._sendMailBtn);
            this.panel1.Controls.Add(this._addAttachmentBtn);
            this.panel1.Controls.Add(this._sendSubjectTxt);
            this.panel1.Controls.Add(this._subjectLbl);
            this.panel1.Controls.Add(this._sendToLbl);
            this.panel1.Controls.Add(this._sendToTxt);
            this.panel1.Location = new System.Drawing.Point(26, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 82);
            this.panel1.TabIndex = 8;
            // 
            // _attachmentQuantityLbl
            // 
            this._attachmentQuantityLbl.AutoSize = true;
            this._attachmentQuantityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._attachmentQuantityLbl.Location = new System.Drawing.Point(538, 59);
            this._attachmentQuantityLbl.Name = "_attachmentQuantityLbl";
            this._attachmentQuantityLbl.Size = new System.Drawing.Size(0, 13);
            this._attachmentQuantityLbl.TabIndex = 12;
            // 
            // _attachmentsLbl
            // 
            this._attachmentsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._attachmentsLbl.Location = new System.Drawing.Point(2, 50);
            this._attachmentsLbl.Name = "_attachmentsLbl";
            this._attachmentsLbl.Size = new System.Drawing.Size(530, 28);
            this._attachmentsLbl.TabIndex = 13;
            this._attachmentsLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _sendMailBtn
            // 
            this._sendMailBtn.Image = global::MailXOR.UI.Properties.Resources.sendMail3;
            this._sendMailBtn.Location = new System.Drawing.Point(582, 49);
            this._sendMailBtn.Name = "_sendMailBtn";
            this._sendMailBtn.Size = new System.Drawing.Size(121, 31);
            this._sendMailBtn.TabIndex = 11;
            this._sendMailBtn.TabStop = false;
            this._sendMailBtn.Click += new System.EventHandler(this._sendMailBtn_Click);
            // 
            // _addAttachmentBtn
            // 
            this._addAttachmentBtn.Image = global::MailXOR.UI.Properties.Resources.addAttachment1;
            this._addAttachmentBtn.Location = new System.Drawing.Point(548, 49);
            this._addAttachmentBtn.Name = "_addAttachmentBtn";
            this._addAttachmentBtn.Size = new System.Drawing.Size(28, 28);
            this._addAttachmentBtn.TabIndex = 10;
            this._addAttachmentBtn.TabStop = false;
            this._addAttachmentBtn.Click += new System.EventHandler(this._addAttachmentBtn_Click);
            this._addAttachmentBtn.MouseHover += new System.EventHandler(this._addAttachmentBtn_MouseHover);
            // 
            // ComposeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._composeEmailPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComposeEmail";
            this.Text = "ScaleMail - Compose";
            this.Load += new System.EventHandler(this.ComposeEmail_Load);
            this._composeEmailPanel.ResumeLayout(false);
            this._composeEmailPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._sendMailBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._addAttachmentBtn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _composeEmailPanel;
        private System.Windows.Forms.OpenFileDialog _openAttachmentDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _sendToTxt;
        private System.Windows.Forms.Label _sendToLbl;
        private System.Windows.Forms.Label _subjectLbl;
        private System.Windows.Forms.TextBox _sendSubjectTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox _sendMailBtn;
        private System.Windows.Forms.PictureBox _addAttachmentBtn;
        private System.Windows.Forms.Label _attachmentQuantityLbl;
        private System.Windows.Forms.Label _attachmentsLbl;
        private System.Windows.Forms.WebBrowser _emailBodyWebBrowser;
    }
}