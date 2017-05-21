namespace TimesheetClient
{
    partial class _timesheetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_timesheetForm));
            this._gridTimesheet = new System.Windows.Forms.DataGridView();
            this._iconList = new System.Windows.Forms.ImageList(this.components);
            this._lblDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._gridTimesheet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _gridTimesheet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this._gridTimesheet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._gridTimesheet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridTimesheet.Location = new System.Drawing.Point(12, 12);
            this._gridTimesheet.Name = "_gridTimesheet";
            this._gridTimesheet.Size = new System.Drawing.Size(469, 388);
            this._gridTimesheet.TabIndex = 0;
            // 
            // _iconList
            // 
            this._iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_iconList.ImageStream")));
            this._iconList.TransparentColor = System.Drawing.Color.Transparent;
            this._iconList.Images.SetKeyName(0, "_iconClock");
            // 
            // _lblDate
            // 
            this._lblDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this._lblDate.AutoSize = true;
            this._lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblDate.Location = new System.Drawing.Point(3, 9);
            this._lblDate.Name = "_lblDate";
            this._lblDate.Size = new System.Drawing.Size(57, 20);
            this._lblDate.TabIndex = 1;
            this._lblDate.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._lblDate);
            this.panel1.Location = new System.Drawing.Point(487, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 388);
            this.panel1.TabIndex = 2;
            // 
            // _timesheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 412);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._gridTimesheet);
            this.Name = "_timesheetForm";
            this.Text = "TimesheetForm";
            ((System.ComponentModel.ISupportInitialize)(this._gridTimesheet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _gridTimesheet;
        private System.Windows.Forms.ImageList _iconList;
        private System.Windows.Forms.Label _lblDate;
        private System.Windows.Forms.Panel panel1;
    }
}