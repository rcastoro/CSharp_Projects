namespace TimesheetClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._iconList = new System.Windows.Forms.ImageList(this.components);
            this._pnlCC = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._listviewTimesheets = new System.Windows.Forms.ListView();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this._lblViewTimesheet_Title = new System.Windows.Forms.Label();
            this._pnlAddTimesheet = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this._grpBx_AddTimesheet_Details = new System.Windows.Forms.GroupBox();
            this._lbl_AddTimesheet_TimestampValue = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._lbl_AddTimesheet_EmailValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._lbl_AddTimesheet_TotalHoursValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._gridAddTimesheet = new System.Windows.Forms.DataGridView();
            this.grpBx_AddTimesheet_Details = new System.Windows.Forms.GroupBox();
            this._btnSubmitTimesheet = new System.Windows.Forms.Button();
            this._refreshAddTimesheetGrid = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this._dt_AddTimesheet_To = new System.Windows.Forms.DateTimePicker();
            this._dt_AddTimesheet_From = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this._pnlViewTimesheet = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBx_ViewTimesheet_Details = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this._dt_ViewTimesheet_To = new System.Windows.Forms.DateTimePicker();
            this._dt_ViewTimesheet_From = new System.Windows.Forms.DateTimePicker();
            this._lbl_ViewTimesheet_TotalHours = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._picReturn = new System.Windows.Forms.PictureBox();
            this._pnlGridViewTimesheet = new System.Windows.Forms.Panel();
            this._gridTimesheet = new System.Windows.Forms.DataGridView();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._addTimesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._viewTimesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlCC.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this._pnlAddTimesheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this._grpBx_AddTimesheet_Details.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridAddTimesheet)).BeginInit();
            this.grpBx_AddTimesheet_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._refreshAddTimesheetGrid)).BeginInit();
            this._pnlViewTimesheet.SuspendLayout();
            this.grpBx_ViewTimesheet_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picReturn)).BeginInit();
            this._pnlGridViewTimesheet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._gridTimesheet)).BeginInit();
            this.SuspendLayout();
            // 
            // _iconList
            // 
            this._iconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_iconList.ImageStream")));
            this._iconList.TransparentColor = System.Drawing.Color.Transparent;
            this._iconList.Images.SetKeyName(0, "_iconAdd");
            this._iconList.Images.SetKeyName(1, "_iconSubmitted");
            this._iconList.Images.SetKeyName(2, "_iconPending");
            this._iconList.Images.SetKeyName(3, "_iconNone");
            this._iconList.Images.SetKeyName(4, "_iconReturn");
            // 
            // _pnlCC
            // 
            this._pnlCC.Controls.Add(this.panel1);
            this._pnlCC.Location = new System.Drawing.Point(0, 29);
            this._pnlCC.Name = "_pnlCC";
            this._pnlCC.Size = new System.Drawing.Size(738, 383);
            this._pnlCC.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._listviewTimesheets);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 330);
            this.panel1.TabIndex = 0;
            // 
            // _listviewTimesheets
            // 
            this._listviewTimesheets.BackColor = System.Drawing.Color.White;
            this._listviewTimesheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listviewTimesheets.LargeImageList = this._iconList;
            this._listviewTimesheets.Location = new System.Drawing.Point(0, 0);
            this._listviewTimesheets.Name = "_listviewTimesheets";
            this._listviewTimesheets.Size = new System.Drawing.Size(714, 330);
            this._listviewTimesheets.TabIndex = 3;
            this._listviewTimesheets.UseCompatibleStateImageBehavior = false;
            this._listviewTimesheets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._listviewTimesheets_MouseDoubleClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(104, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 33);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // _lblViewTimesheet_Title
            // 
            this._lblViewTimesheet_Title.AutoSize = true;
            this._lblViewTimesheet_Title.Font = new System.Drawing.Font("MS Reference Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblViewTimesheet_Title.Location = new System.Drawing.Point(42, 28);
            this._lblViewTimesheet_Title.Name = "_lblViewTimesheet_Title";
            this._lblViewTimesheet_Title.Size = new System.Drawing.Size(184, 24);
            this._lblViewTimesheet_Title.TabIndex = 5;
            this._lblViewTimesheet_Title.Text = "Clock    Watcher";
            // 
            // _pnlAddTimesheet
            // 
            this._pnlAddTimesheet.BackColor = System.Drawing.SystemColors.Control;
            this._pnlAddTimesheet.Controls.Add(this.pictureBox3);
            this._pnlAddTimesheet.Controls.Add(this._grpBx_AddTimesheet_Details);
            this._pnlAddTimesheet.Controls.Add(this.label8);
            this._pnlAddTimesheet.Controls.Add(this.panel2);
            this._pnlAddTimesheet.Controls.Add(this.grpBx_AddTimesheet_Details);
            this._pnlAddTimesheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlAddTimesheet.Location = new System.Drawing.Point(0, 24);
            this._pnlAddTimesheet.Name = "_pnlAddTimesheet";
            this._pnlAddTimesheet.Size = new System.Drawing.Size(738, 388);
            this._pnlAddTimesheet.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(702, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 34);
            this.pictureBox3.TabIndex = 13;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // _grpBx_AddTimesheet_Details
            // 
            this._grpBx_AddTimesheet_Details.Controls.Add(this._lbl_AddTimesheet_TimestampValue);
            this._grpBx_AddTimesheet_Details.Controls.Add(this.label10);
            this._grpBx_AddTimesheet_Details.Controls.Add(this._lbl_AddTimesheet_EmailValue);
            this._grpBx_AddTimesheet_Details.Controls.Add(this.label7);
            this._grpBx_AddTimesheet_Details.Controls.Add(this._lbl_AddTimesheet_TotalHoursValue);
            this._grpBx_AddTimesheet_Details.Controls.Add(this.label9);
            this._grpBx_AddTimesheet_Details.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._grpBx_AddTimesheet_Details.Location = new System.Drawing.Point(12, 223);
            this._grpBx_AddTimesheet_Details.Name = "_grpBx_AddTimesheet_Details";
            this._grpBx_AddTimesheet_Details.Size = new System.Drawing.Size(240, 153);
            this._grpBx_AddTimesheet_Details.TabIndex = 12;
            this._grpBx_AddTimesheet_Details.TabStop = false;
            this._grpBx_AddTimesheet_Details.Text = "Timesheet Details:";
            // 
            // _lbl_AddTimesheet_TimestampValue
            // 
            this._lbl_AddTimesheet_TimestampValue.AutoSize = true;
            this._lbl_AddTimesheet_TimestampValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._lbl_AddTimesheet_TimestampValue.Location = new System.Drawing.Point(10, 121);
            this._lbl_AddTimesheet_TimestampValue.Name = "_lbl_AddTimesheet_TimestampValue";
            this._lbl_AddTimesheet_TimestampValue.Size = new System.Drawing.Size(0, 13);
            this._lbl_AddTimesheet_TimestampValue.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label10.Location = new System.Drawing.Point(6, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Timestamp:";
            // 
            // _lbl_AddTimesheet_EmailValue
            // 
            this._lbl_AddTimesheet_EmailValue.AutoSize = true;
            this._lbl_AddTimesheet_EmailValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._lbl_AddTimesheet_EmailValue.Location = new System.Drawing.Point(9, 81);
            this._lbl_AddTimesheet_EmailValue.Name = "_lbl_AddTimesheet_EmailValue";
            this._lbl_AddTimesheet_EmailValue.Size = new System.Drawing.Size(0, 13);
            this._lbl_AddTimesheet_EmailValue.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Submitting Email:";
            // 
            // _lbl_AddTimesheet_TotalHoursValue
            // 
            this._lbl_AddTimesheet_TotalHoursValue.AutoSize = true;
            this._lbl_AddTimesheet_TotalHoursValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this._lbl_AddTimesheet_TotalHoursValue.Location = new System.Drawing.Point(91, 29);
            this._lbl_AddTimesheet_TotalHoursValue.Name = "_lbl_AddTimesheet_TotalHoursValue";
            this._lbl_AddTimesheet_TotalHoursValue.Size = new System.Drawing.Size(0, 13);
            this._lbl_AddTimesheet_TotalHoursValue.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.25F);
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Total Hours:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(265, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Add Timesheet";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._gridAddTimesheet);
            this.panel2.Location = new System.Drawing.Point(265, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 335);
            this.panel2.TabIndex = 11;
            // 
            // _gridAddTimesheet
            // 
            this._gridAddTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridAddTimesheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridAddTimesheet.Location = new System.Drawing.Point(0, 0);
            this._gridAddTimesheet.Name = "_gridAddTimesheet";
            this._gridAddTimesheet.Size = new System.Drawing.Size(461, 335);
            this._gridAddTimesheet.TabIndex = 0;
            this._gridAddTimesheet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridAddTimesheet_CellClick);
            this._gridAddTimesheet.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._gridAddTimesheet_CellValueChanged);
            this._gridAddTimesheet.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this._gridAddTimesheet_DataError);
            // 
            // grpBx_AddTimesheet_Details
            // 
            this.grpBx_AddTimesheet_Details.Controls.Add(this._btnSubmitTimesheet);
            this.grpBx_AddTimesheet_Details.Controls.Add(this._refreshAddTimesheetGrid);
            this.grpBx_AddTimesheet_Details.Controls.Add(this.linkLabel1);
            this.grpBx_AddTimesheet_Details.Controls.Add(this.label6);
            this.grpBx_AddTimesheet_Details.Controls.Add(this._dt_AddTimesheet_To);
            this.grpBx_AddTimesheet_Details.Controls.Add(this._dt_AddTimesheet_From);
            this.grpBx_AddTimesheet_Details.Controls.Add(this.label5);
            this.grpBx_AddTimesheet_Details.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBx_AddTimesheet_Details.Location = new System.Drawing.Point(12, 34);
            this.grpBx_AddTimesheet_Details.Name = "grpBx_AddTimesheet_Details";
            this.grpBx_AddTimesheet_Details.Size = new System.Drawing.Size(240, 176);
            this.grpBx_AddTimesheet_Details.TabIndex = 10;
            this.grpBx_AddTimesheet_Details.TabStop = false;
            this.grpBx_AddTimesheet_Details.Text = "Add Timesheet:";
            // 
            // _btnSubmitTimesheet
            // 
            this._btnSubmitTimesheet.Location = new System.Drawing.Point(83, 147);
            this._btnSubmitTimesheet.Name = "_btnSubmitTimesheet";
            this._btnSubmitTimesheet.Size = new System.Drawing.Size(150, 23);
            this._btnSubmitTimesheet.TabIndex = 11;
            this._btnSubmitTimesheet.Text = "Submit Timesheet";
            this._btnSubmitTimesheet.UseVisualStyleBackColor = true;
            this._btnSubmitTimesheet.Click += new System.EventHandler(this._btnSubmitTimesheet_Click);
            // 
            // _refreshAddTimesheetGrid
            // 
            this._refreshAddTimesheetGrid.Image = ((System.Drawing.Image)(resources.GetObject("_refreshAddTimesheetGrid.Image")));
            this._refreshAddTimesheetGrid.Location = new System.Drawing.Point(216, 110);
            this._refreshAddTimesheetGrid.Name = "_refreshAddTimesheetGrid";
            this._refreshAddTimesheetGrid.Size = new System.Drawing.Size(18, 19);
            this._refreshAddTimesheetGrid.TabIndex = 10;
            this._refreshAddTimesheetGrid.TabStop = false;
            this._refreshAddTimesheetGrid.Click += new System.EventHandler(this._refreshAddTimesheetGrid_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Verdana", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.CadetBlue;
            this.linkLabel1.Location = new System.Drawing.Point(119, 115);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(98, 12);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Manual Override";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(213, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "To";
            // 
            // _dt_AddTimesheet_To
            // 
            this._dt_AddTimesheet_To.CalendarFont = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_AddTimesheet_To.Enabled = false;
            this._dt_AddTimesheet_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_AddTimesheet_To.Location = new System.Drawing.Point(6, 88);
            this._dt_AddTimesheet_To.Name = "_dt_AddTimesheet_To";
            this._dt_AddTimesheet_To.Size = new System.Drawing.Size(228, 21);
            this._dt_AddTimesheet_To.TabIndex = 7;
            // 
            // _dt_AddTimesheet_From
            // 
            this._dt_AddTimesheet_From.CalendarFont = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_AddTimesheet_From.CalendarMonthBackground = System.Drawing.Color.White;
            this._dt_AddTimesheet_From.Enabled = false;
            this._dt_AddTimesheet_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_AddTimesheet_From.Location = new System.Drawing.Point(6, 45);
            this._dt_AddTimesheet_From.Name = "_dt_AddTimesheet_From";
            this._dt_AddTimesheet_From.Size = new System.Drawing.Size(228, 21);
            this._dt_AddTimesheet_From.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Pay Period:";
            // 
            // _pnlViewTimesheet
            // 
            this._pnlViewTimesheet.Controls.Add(this.label1);
            this._pnlViewTimesheet.Controls.Add(this.grpBx_ViewTimesheet_Details);
            this._pnlViewTimesheet.Controls.Add(this.pictureBox1);
            this._pnlViewTimesheet.Controls.Add(this._picReturn);
            this._pnlViewTimesheet.Controls.Add(this._pnlGridViewTimesheet);
            this._pnlViewTimesheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlViewTimesheet.Location = new System.Drawing.Point(0, 24);
            this._pnlViewTimesheet.Name = "_pnlViewTimesheet";
            this._pnlViewTimesheet.Size = new System.Drawing.Size(738, 388);
            this._pnlViewTimesheet.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(262, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "View Timesheet";
            // 
            // grpBx_ViewTimesheet_Details
            // 
            this.grpBx_ViewTimesheet_Details.Controls.Add(this.label4);
            this.grpBx_ViewTimesheet_Details.Controls.Add(this._dt_ViewTimesheet_To);
            this.grpBx_ViewTimesheet_Details.Controls.Add(this._dt_ViewTimesheet_From);
            this.grpBx_ViewTimesheet_Details.Controls.Add(this._lbl_ViewTimesheet_TotalHours);
            this.grpBx_ViewTimesheet_Details.Controls.Add(this.label3);
            this.grpBx_ViewTimesheet_Details.Controls.Add(this.label2);
            this.grpBx_ViewTimesheet_Details.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBx_ViewTimesheet_Details.Location = new System.Drawing.Point(12, 33);
            this.grpBx_ViewTimesheet_Details.Name = "grpBx_ViewTimesheet_Details";
            this.grpBx_ViewTimesheet_Details.Size = new System.Drawing.Size(240, 277);
            this.grpBx_ViewTimesheet_Details.TabIndex = 8;
            this.grpBx_ViewTimesheet_Details.TabStop = false;
            this.grpBx_ViewTimesheet_Details.Text = "Details:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(207, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // _dt_ViewTimesheet_To
            // 
            this._dt_ViewTimesheet_To.CalendarFont = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_ViewTimesheet_To.Enabled = false;
            this._dt_ViewTimesheet_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_ViewTimesheet_To.Location = new System.Drawing.Point(6, 97);
            this._dt_ViewTimesheet_To.Name = "_dt_ViewTimesheet_To";
            this._dt_ViewTimesheet_To.Size = new System.Drawing.Size(228, 21);
            this._dt_ViewTimesheet_To.TabIndex = 5;
            // 
            // _dt_ViewTimesheet_From
            // 
            this._dt_ViewTimesheet_From.CalendarFont = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_ViewTimesheet_From.CalendarMonthBackground = System.Drawing.Color.White;
            this._dt_ViewTimesheet_From.Enabled = false;
            this._dt_ViewTimesheet_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._dt_ViewTimesheet_From.Location = new System.Drawing.Point(6, 54);
            this._dt_ViewTimesheet_From.Name = "_dt_ViewTimesheet_From";
            this._dt_ViewTimesheet_From.Size = new System.Drawing.Size(228, 21);
            this._dt_ViewTimesheet_From.TabIndex = 4;
            // 
            // _lbl_ViewTimesheet_TotalHours
            // 
            this._lbl_ViewTimesheet_TotalHours.AutoSize = true;
            this._lbl_ViewTimesheet_TotalHours.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbl_ViewTimesheet_TotalHours.Location = new System.Drawing.Point(96, 135);
            this._lbl_ViewTimesheet_TotalHours.Name = "_lbl_ViewTimesheet_TotalHours";
            this._lbl_ViewTimesheet_TotalHours.Size = new System.Drawing.Size(0, 13);
            this._lbl_ViewTimesheet_TotalHours.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total Hours:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pay Period:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 316);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 61);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // _picReturn
            // 
            this._picReturn.Location = new System.Drawing.Point(702, 8);
            this._picReturn.Name = "_picReturn";
            this._picReturn.Size = new System.Drawing.Size(33, 34);
            this._picReturn.TabIndex = 6;
            this._picReturn.TabStop = false;
            this._picReturn.Click += new System.EventHandler(this._picReturn_Click);
            // 
            // _pnlGridViewTimesheet
            // 
            this._pnlGridViewTimesheet.Controls.Add(this._gridTimesheet);
            this._pnlGridViewTimesheet.Location = new System.Drawing.Point(265, 42);
            this._pnlGridViewTimesheet.Name = "_pnlGridViewTimesheet";
            this._pnlGridViewTimesheet.Size = new System.Drawing.Size(461, 358);
            this._pnlGridViewTimesheet.TabIndex = 0;
            // 
            // _gridTimesheet
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this._gridTimesheet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this._gridTimesheet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._gridTimesheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._gridTimesheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this._gridTimesheet.Location = new System.Drawing.Point(0, 0);
            this._gridTimesheet.Name = "_gridTimesheet";
            this._gridTimesheet.Size = new System.Drawing.Size(461, 358);
            this._gridTimesheet.TabIndex = 1;
            // 
            // _menuStrip
            // 
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(738, 24);
            this._menuStrip.TabIndex = 14;
            this._menuStrip.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addTimesheetToolStripMenuItem,
            this._viewTimesheetToolStripMenuItem});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F);
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.menuToolStripMenuItem.Text = "Actions";
            // 
            // _addTimesheetToolStripMenuItem
            // 
            this._addTimesheetToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._addTimesheetToolStripMenuItem.Name = "_addTimesheetToolStripMenuItem";
            this._addTimesheetToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this._addTimesheetToolStripMenuItem.Text = "Add Timesheet";
            this._addTimesheetToolStripMenuItem.Click += new System.EventHandler(this._addTimesheetToolStripMenuItem_Click);
            // 
            // _viewTimesheetToolStripMenuItem
            // 
            this._viewTimesheetToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this._viewTimesheetToolStripMenuItem.Name = "_viewTimesheetToolStripMenuItem";
            this._viewTimesheetToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this._viewTimesheetToolStripMenuItem.Text = "View Timesheet";
            // 
            // employeeTokenToolStripMenuItem
            // 
            this.employeeTokenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.employeeTokenToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 9F);
            this.employeeTokenToolStripMenuItem.Name = "employeeTokenToolStripMenuItem";
            this.employeeTokenToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.employeeTokenToolStripMenuItem.Text = "Employee ID";
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyToClipboardToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to File";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(738, 412);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this._lblViewTimesheet_Title);
            this.Controls.Add(this._pnlAddTimesheet);
            this.Controls.Add(this._pnlViewTimesheet);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._pnlCC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClockWatcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this._pnlCC.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this._pnlAddTimesheet.ResumeLayout(false);
            this._pnlAddTimesheet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this._grpBx_AddTimesheet_Details.ResumeLayout(false);
            this._grpBx_AddTimesheet_Details.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridAddTimesheet)).EndInit();
            this.grpBx_AddTimesheet_Details.ResumeLayout(false);
            this.grpBx_AddTimesheet_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._refreshAddTimesheetGrid)).EndInit();
            this._pnlViewTimesheet.ResumeLayout(false);
            this._pnlViewTimesheet.PerformLayout();
            this.grpBx_ViewTimesheet_Details.ResumeLayout(false);
            this.grpBx_ViewTimesheet_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picReturn)).EndInit();
            this._pnlGridViewTimesheet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._gridTimesheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList _iconList;
        private System.Windows.Forms.Panel _pnlCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView _listviewTimesheets;
        private System.Windows.Forms.Panel _pnlViewTimesheet;
        private System.Windows.Forms.Label _lblViewTimesheet_Title;
        private System.Windows.Forms.Panel _pnlGridViewTimesheet;
        private System.Windows.Forms.DataGridView _gridTimesheet;
        private System.Windows.Forms.PictureBox _picReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpBx_ViewTimesheet_Details;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _lbl_ViewTimesheet_TotalHours;
        private System.Windows.Forms.Panel _pnlAddTimesheet;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView _gridAddTimesheet;
        private System.Windows.Forms.GroupBox grpBx_AddTimesheet_Details;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker _dt_ViewTimesheet_From;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker _dt_ViewTimesheet_To;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker _dt_AddTimesheet_To;
        private System.Windows.Forms.DateTimePicker _dt_AddTimesheet_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox _refreshAddTimesheetGrid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox _grpBx_AddTimesheet_Details;
        private System.Windows.Forms.Button _btnSubmitTimesheet;
        private System.Windows.Forms.Label _lbl_AddTimesheet_TotalHoursValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _lbl_AddTimesheet_EmailValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label _lbl_AddTimesheet_TimestampValue;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeTokenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _addTimesheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _viewTimesheetToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox3;


    }
}

