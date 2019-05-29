namespace Clopay.TestAutomation
{
  partial class VisualizationTestEnigneForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisualizationTestEnigneForm));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.prgStatus = new System.Windows.Forms.ToolStripProgressBar();
      this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel2 = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabResults = new System.Windows.Forms.TabPage();
      this.dgvResults = new System.Windows.Forms.DataGridView();
      this.ctxGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exportToXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabStatus = new System.Windows.Forms.TabPage();
      this.txtStatus = new System.Windows.Forms.RichTextBox();
      this.grpMain = new System.Windows.Forms.GroupBox();
      this.chkPerformanceTest = new System.Windows.Forms.CheckBox();
      this.grpOptions = new System.Windows.Forms.GroupBox();
      this.chkImages = new System.Windows.Forms.CheckBox();
      this.chkStopOnError = new System.Windows.Forms.CheckBox();
      this.chkData = new System.Windows.Forms.CheckBox();
      this.chkClear = new System.Windows.Forms.CheckBox();
      this.chkCaptureAllImages = new System.Windows.Forms.CheckBox();
      this.cboHeightFeet = new System.Windows.Forms.ComboBox();
      this.btnStop = new System.Windows.Forms.Button();
      this.cboWidthFeet = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.cboWidthInches = new System.Windows.Forms.ComboBox();
      this.cboHeightInches = new System.Windows.Forms.ComboBox();
      this.lblheightin = new System.Windows.Forms.Label();
      this.lblwidthft = new System.Windows.Forms.Label();
      this.lblheightft = new System.Windows.Forms.Label();
      this.lblwidthin = new System.Windows.Forms.Label();
      this.lblheight = new System.Windows.Forms.Label();
      this.lblwidth = new System.Windows.Forms.Label();
      this.btnTestImages = new System.Windows.Forms.Button();
      this.btnHardware = new System.Windows.Forms.Button();
      this.btnTopSections = new System.Windows.Forms.Button();
      this.txtCompleted = new System.Windows.Forms.Label();
      this.txtEstimated = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.label14 = new System.Windows.Forms.Label();
      this.lblEndTime = new System.Windows.Forms.Label();
      this.lblStartTime = new System.Windows.Forms.Label();
      this.label12 = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label10 = new System.Windows.Forms.Label();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.btnTestLinks = new System.Windows.Forms.Button();
      this.btnQuickTest = new System.Windows.Forms.Button();
      this.btnStartSetupTest = new System.Windows.Forms.Button();
      this.txtRemoteHub = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.cboOS = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.txtTimeout = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.btnStart = new System.Windows.Forms.Button();
      this.txtUrl = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.btnBrowse = new System.Windows.Forms.Button();
      this.txtImagePath = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.chkAllCollections = new System.Windows.Forms.CheckBox();
      this.grpCollections = new System.Windows.Forms.GroupBox();
      this.clbCollection = new System.Windows.Forms.CheckedListBox();
      this.txtOrderNo = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cboBrowser = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.errProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.statusStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabResults.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
      this.ctxGrid.SuspendLayout();
      this.tabStatus.SuspendLayout();
      this.grpMain.SuspendLayout();
      this.grpOptions.SuspendLayout();
      this.grpCollections.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVersion,
            this.prgStatus,
            this.lblMessage});
      this.statusStrip1.Location = new System.Drawing.Point(0, 486);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
      this.statusStrip1.Size = new System.Drawing.Size(970, 22);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // prgStatus
      // 
      this.prgStatus.Name = "prgStatus";
      this.prgStatus.Size = new System.Drawing.Size(100, 16);
      this.prgStatus.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      // 
      // lblMessage
      // 
      this.lblMessage.Name = "lblMessage";
      this.lblMessage.Size = new System.Drawing.Size(0, 17);
      // 
      // lblVersion
      // 
      this.lblVersion.Name = "lblVersion";
      this.lblVersion.Size = new System.Drawing.Size(59, 17);
      this.lblVersion.Text = "lblVersion";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.panel1);
      this.panel2.Controls.Add(this.grpMain);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.panel2.Size = new System.Drawing.Size(970, 486);
      this.panel2.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.tabControl1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(5, 328);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(4);
      this.panel1.Size = new System.Drawing.Size(960, 154);
      this.panel1.TabIndex = 2;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabResults);
      this.tabControl1.Controls.Add(this.tabStatus);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(4, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(952, 146);
      this.tabControl1.TabIndex = 0;
      // 
      // tabResults
      // 
      this.tabResults.Controls.Add(this.dgvResults);
      this.tabResults.Location = new System.Drawing.Point(4, 23);
      this.tabResults.Name = "tabResults";
      this.tabResults.Padding = new System.Windows.Forms.Padding(3);
      this.tabResults.Size = new System.Drawing.Size(944, 119);
      this.tabResults.TabIndex = 0;
      this.tabResults.Text = "Results";
      this.tabResults.UseVisualStyleBackColor = true;
      // 
      // dgvResults
      // 
      this.dgvResults.AllowUserToAddRows = false;
      this.dgvResults.AllowUserToDeleteRows = false;
      this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvResults.ContextMenuStrip = this.ctxGrid;
      this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvResults.Location = new System.Drawing.Point(3, 3);
      this.dgvResults.MultiSelect = false;
      this.dgvResults.Name = "dgvResults";
      this.dgvResults.ReadOnly = true;
      this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvResults.Size = new System.Drawing.Size(938, 113);
      this.dgvResults.TabIndex = 0;
      // 
      // ctxGrid
      // 
      this.ctxGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToExcelToolStripMenuItem,
            this.exportToXmlToolStripMenuItem});
      this.ctxGrid.Name = "ctxGrid";
      this.ctxGrid.Size = new System.Drawing.Size(154, 48);
      // 
      // exportToExcelToolStripMenuItem
      // 
      this.exportToExcelToolStripMenuItem.Name = "exportToExcelToolStripMenuItem";
      this.exportToExcelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
      this.exportToExcelToolStripMenuItem.Text = "Export To Excel";
      this.exportToExcelToolStripMenuItem.Click += new System.EventHandler(this.exportToExcelToolStripMenuItem_Click);
      // 
      // exportToXmlToolStripMenuItem
      // 
      this.exportToXmlToolStripMenuItem.Name = "exportToXmlToolStripMenuItem";
      this.exportToXmlToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
      this.exportToXmlToolStripMenuItem.Text = "Export To Xml";
      this.exportToXmlToolStripMenuItem.Click += new System.EventHandler(this.exportToXmlToolStripMenuItem_Click);
      // 
      // tabStatus
      // 
      this.tabStatus.Controls.Add(this.txtStatus);
      this.tabStatus.Location = new System.Drawing.Point(4, 23);
      this.tabStatus.Name = "tabStatus";
      this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
      this.tabStatus.Size = new System.Drawing.Size(944, 119);
      this.tabStatus.TabIndex = 1;
      this.tabStatus.Text = "Status";
      this.tabStatus.UseVisualStyleBackColor = true;
      // 
      // txtStatus
      // 
      this.txtStatus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtStatus.Location = new System.Drawing.Point(3, 3);
      this.txtStatus.Name = "txtStatus";
      this.txtStatus.Size = new System.Drawing.Size(938, 113);
      this.txtStatus.TabIndex = 1;
      this.txtStatus.Text = "";
      // 
      // grpMain
      // 
      this.grpMain.Controls.Add(this.chkPerformanceTest);
      this.grpMain.Controls.Add(this.grpOptions);
      this.grpMain.Controls.Add(this.cboHeightFeet);
      this.grpMain.Controls.Add(this.btnStop);
      this.grpMain.Controls.Add(this.cboWidthFeet);
      this.grpMain.Controls.Add(this.label2);
      this.grpMain.Controls.Add(this.cboWidthInches);
      this.grpMain.Controls.Add(this.cboHeightInches);
      this.grpMain.Controls.Add(this.lblheightin);
      this.grpMain.Controls.Add(this.lblwidthft);
      this.grpMain.Controls.Add(this.lblheightft);
      this.grpMain.Controls.Add(this.lblwidthin);
      this.grpMain.Controls.Add(this.lblheight);
      this.grpMain.Controls.Add(this.lblwidth);
      this.grpMain.Controls.Add(this.btnTestImages);
      this.grpMain.Controls.Add(this.btnHardware);
      this.grpMain.Controls.Add(this.btnTopSections);
      this.grpMain.Controls.Add(this.txtCompleted);
      this.grpMain.Controls.Add(this.txtEstimated);
      this.grpMain.Controls.Add(this.label13);
      this.grpMain.Controls.Add(this.label14);
      this.grpMain.Controls.Add(this.lblEndTime);
      this.grpMain.Controls.Add(this.lblStartTime);
      this.grpMain.Controls.Add(this.label12);
      this.grpMain.Controls.Add(this.label11);
      this.grpMain.Controls.Add(this.txtPassword);
      this.grpMain.Controls.Add(this.label10);
      this.grpMain.Controls.Add(this.txtUserName);
      this.grpMain.Controls.Add(this.label9);
      this.grpMain.Controls.Add(this.btnTestLinks);
      this.grpMain.Controls.Add(this.btnQuickTest);
      this.grpMain.Controls.Add(this.btnStartSetupTest);
      this.grpMain.Controls.Add(this.txtRemoteHub);
      this.grpMain.Controls.Add(this.label8);
      this.grpMain.Controls.Add(this.cboOS);
      this.grpMain.Controls.Add(this.label7);
      this.grpMain.Controls.Add(this.txtTimeout);
      this.grpMain.Controls.Add(this.label6);
      this.grpMain.Controls.Add(this.btnStart);
      this.grpMain.Controls.Add(this.txtUrl);
      this.grpMain.Controls.Add(this.label5);
      this.grpMain.Controls.Add(this.btnBrowse);
      this.grpMain.Controls.Add(this.txtImagePath);
      this.grpMain.Controls.Add(this.label4);
      this.grpMain.Controls.Add(this.chkAllCollections);
      this.grpMain.Controls.Add(this.grpCollections);
      this.grpMain.Controls.Add(this.txtOrderNo);
      this.grpMain.Controls.Add(this.label3);
      this.grpMain.Controls.Add(this.cboBrowser);
      this.grpMain.Controls.Add(this.label1);
      this.grpMain.Dock = System.Windows.Forms.DockStyle.Top;
      this.grpMain.Location = new System.Drawing.Point(5, 4);
      this.grpMain.Name = "grpMain";
      this.grpMain.Size = new System.Drawing.Size(960, 324);
      this.grpMain.TabIndex = 0;
      this.grpMain.TabStop = false;
      this.grpMain.Text = "Test Parameters";
      // 
      // chkPerformanceTest
      // 
      this.chkPerformanceTest.AutoSize = true;
      this.chkPerformanceTest.Location = new System.Drawing.Point(537, 232);
      this.chkPerformanceTest.Name = "chkPerformanceTest";
      this.chkPerformanceTest.Size = new System.Drawing.Size(124, 18);
      this.chkPerformanceTest.TabIndex = 81;
      this.chkPerformanceTest.Text = "Performance Test";
      this.chkPerformanceTest.UseVisualStyleBackColor = true;
      this.chkPerformanceTest.CheckedChanged += new System.EventHandler(this.chkPerformanceTest_CheckedChanged);
      // 
      // grpOptions
      // 
      this.grpOptions.Controls.Add(this.chkImages);
      this.grpOptions.Controls.Add(this.chkStopOnError);
      this.grpOptions.Controls.Add(this.chkData);
      this.grpOptions.Controls.Add(this.chkClear);
      this.grpOptions.Controls.Add(this.chkCaptureAllImages);
      this.grpOptions.Location = new System.Drawing.Point(523, 233);
      this.grpOptions.Name = "grpOptions";
      this.grpOptions.Size = new System.Drawing.Size(272, 85);
      this.grpOptions.TabIndex = 80;
      this.grpOptions.TabStop = false;
      // 
      // chkImages
      // 
      this.chkImages.AutoSize = true;
      this.chkImages.Location = new System.Drawing.Point(141, 21);
      this.chkImages.Name = "chkImages";
      this.chkImages.Size = new System.Drawing.Size(112, 18);
      this.chkImages.TabIndex = 11;
      this.chkImages.Text = "Validate Images";
      this.chkImages.UseVisualStyleBackColor = true;
      // 
      // chkStopOnError
      // 
      this.chkStopOnError.AutoSize = true;
      this.chkStopOnError.Location = new System.Drawing.Point(5, 19);
      this.chkStopOnError.Name = "chkStopOnError";
      this.chkStopOnError.Size = new System.Drawing.Size(102, 18);
      this.chkStopOnError.TabIndex = 10;
      this.chkStopOnError.Text = "Stop On Error";
      this.chkStopOnError.UseVisualStyleBackColor = true;
      // 
      // chkData
      // 
      this.chkData.AutoSize = true;
      this.chkData.Location = new System.Drawing.Point(142, 45);
      this.chkData.Name = "chkData";
      this.chkData.Size = new System.Drawing.Size(98, 18);
      this.chkData.TabIndex = 13;
      this.chkData.Text = "Validate Data";
      this.chkData.UseVisualStyleBackColor = true;
      // 
      // chkClear
      // 
      this.chkClear.AutoSize = true;
      this.chkClear.Location = new System.Drawing.Point(5, 43);
      this.chkClear.Name = "chkClear";
      this.chkClear.Size = new System.Drawing.Size(81, 18);
      this.chkClear.TabIndex = 12;
      this.chkClear.Text = "Clear Data";
      this.chkClear.UseVisualStyleBackColor = true;
      // 
      // chkCaptureAllImages
      // 
      this.chkCaptureAllImages.AutoSize = true;
      this.chkCaptureAllImages.Location = new System.Drawing.Point(5, 66);
      this.chkCaptureAllImages.Name = "chkCaptureAllImages";
      this.chkCaptureAllImages.Size = new System.Drawing.Size(128, 18);
      this.chkCaptureAllImages.TabIndex = 14;
      this.chkCaptureAllImages.Text = "Capture All Images";
      this.chkCaptureAllImages.UseVisualStyleBackColor = true;
      // 
      // cboHeightFeet
      // 
      this.cboHeightFeet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboHeightFeet.FormattingEnabled = true;
      this.cboHeightFeet.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
      this.cboHeightFeet.Location = new System.Drawing.Point(383, 152);
      this.cboHeightFeet.Name = "cboHeightFeet";
      this.cboHeightFeet.Size = new System.Drawing.Size(37, 22);
      this.cboHeightFeet.TabIndex = 79;
      // 
      // btnStop
      // 
      this.btnStop.Location = new System.Drawing.Point(770, 212);
      this.btnStop.Name = "btnStop";
      this.btnStop.Size = new System.Drawing.Size(142, 23);
      this.btnStop.TabIndex = 29;
      this.btnStop.Text = "Stop Process";
      this.btnStop.UseVisualStyleBackColor = true;
      // 
      // cboWidthFeet
      // 
      this.cboWidthFeet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboWidthFeet.FormattingEnabled = true;
      this.cboWidthFeet.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
      this.cboWidthFeet.Location = new System.Drawing.Point(188, 154);
      this.cboWidthFeet.Name = "cboWidthFeet";
      this.cboWidthFeet.Size = new System.Drawing.Size(37, 22);
      this.cboWidthFeet.TabIndex = 78;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(38, 159);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(98, 13);
      this.label2.TabIndex = 77;
      this.label2.Text = "Door Size:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cboWidthInches
      // 
      this.cboWidthInches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboWidthInches.FormattingEnabled = true;
      this.cboWidthInches.Items.AddRange(new object[] {
            "0",
            "2",
            "4",
            "6",
            "8",
            "10"});
      this.cboWidthInches.Location = new System.Drawing.Point(260, 152);
      this.cboWidthInches.Name = "cboWidthInches";
      this.cboWidthInches.Size = new System.Drawing.Size(37, 22);
      this.cboWidthInches.TabIndex = 74;
      // 
      // cboHeightInches
      // 
      this.cboHeightInches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboHeightInches.FormattingEnabled = true;
      this.cboHeightInches.Items.AddRange(new object[] {
            "0",
            "3",
            "6",
            "9"});
      this.cboHeightInches.Location = new System.Drawing.Point(459, 154);
      this.cboHeightInches.Name = "cboHeightInches";
      this.cboHeightInches.Size = new System.Drawing.Size(37, 22);
      this.cboHeightInches.TabIndex = 73;
      // 
      // lblheightin
      // 
      this.lblheightin.AutoSize = true;
      this.lblheightin.Location = new System.Drawing.Point(502, 157);
      this.lblheightin.Name = "lblheightin";
      this.lblheightin.Size = new System.Drawing.Size(16, 14);
      this.lblheightin.TabIndex = 75;
      this.lblheightin.Text = "in";
      // 
      // lblwidthft
      // 
      this.lblwidthft.AutoSize = true;
      this.lblwidthft.Location = new System.Drawing.Point(238, 158);
      this.lblwidthft.Name = "lblwidthft";
      this.lblwidthft.Size = new System.Drawing.Size(16, 14);
      this.lblwidthft.TabIndex = 72;
      this.lblwidthft.Text = "ft";
      // 
      // lblheightft
      // 
      this.lblheightft.AutoSize = true;
      this.lblheightft.Location = new System.Drawing.Point(437, 158);
      this.lblheightft.Name = "lblheightft";
      this.lblheightft.Size = new System.Drawing.Size(16, 14);
      this.lblheightft.TabIndex = 71;
      this.lblheightft.Text = "ft";
      // 
      // lblwidthin
      // 
      this.lblwidthin.AutoSize = true;
      this.lblwidthin.Location = new System.Drawing.Point(303, 158);
      this.lblwidthin.Name = "lblwidthin";
      this.lblwidthin.Size = new System.Drawing.Size(16, 14);
      this.lblwidthin.TabIndex = 76;
      this.lblwidthin.Text = "in";
      // 
      // lblheight
      // 
      this.lblheight.AutoSize = true;
      this.lblheight.Location = new System.Drawing.Point(339, 157);
      this.lblheight.Name = "lblheight";
      this.lblheight.Size = new System.Drawing.Size(47, 14);
      this.lblheight.TabIndex = 67;
      this.lblheight.Text = "Height ";
      // 
      // lblwidth
      // 
      this.lblwidth.AutoSize = true;
      this.lblwidth.Location = new System.Drawing.Point(142, 160);
      this.lblwidth.Name = "lblwidth";
      this.lblwidth.Size = new System.Drawing.Size(40, 14);
      this.lblwidth.TabIndex = 68;
      this.lblwidth.Text = "Width";
      // 
      // btnTestImages
      // 
      this.btnTestImages.Location = new System.Drawing.Point(770, 183);
      this.btnTestImages.Name = "btnTestImages";
      this.btnTestImages.Size = new System.Drawing.Size(144, 23);
      this.btnTestImages.TabIndex = 43;
      this.btnTestImages.Text = "Test Images";
      this.btnTestImages.UseVisualStyleBackColor = true;
      this.btnTestImages.Click += new System.EventHandler(this.btnTestImages_Click);
      // 
      // btnHardware
      // 
      this.btnHardware.Location = new System.Drawing.Point(770, 155);
      this.btnHardware.Name = "btnHardware";
      this.btnHardware.Size = new System.Drawing.Size(144, 23);
      this.btnHardware.TabIndex = 42;
      this.btnHardware.Text = "Hardware Test";
      this.btnHardware.UseVisualStyleBackColor = true;
      this.btnHardware.Click += new System.EventHandler(this.btnHardware_Click);
      // 
      // btnTopSections
      // 
      this.btnTopSections.Location = new System.Drawing.Point(770, 127);
      this.btnTopSections.Name = "btnTopSections";
      this.btnTopSections.Size = new System.Drawing.Size(144, 23);
      this.btnTopSections.TabIndex = 41;
      this.btnTopSections.Text = "Top Sections Test";
      this.btnTopSections.UseVisualStyleBackColor = true;
      this.btnTopSections.Click += new System.EventHandler(this.btnTopSections_Click);
      // 
      // txtCompleted
      // 
      this.txtCompleted.Location = new System.Drawing.Point(142, 281);
      this.txtCompleted.Name = "txtCompleted";
      this.txtCompleted.Size = new System.Drawing.Size(166, 13);
      this.txtCompleted.TabIndex = 40;
      this.txtCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // txtEstimated
      // 
      this.txtEstimated.Location = new System.Drawing.Point(142, 257);
      this.txtEstimated.Name = "txtEstimated";
      this.txtEstimated.Size = new System.Drawing.Size(166, 13);
      this.txtEstimated.TabIndex = 39;
      this.txtEstimated.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label13
      // 
      this.label13.Location = new System.Drawing.Point(1, 281);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(135, 13);
      this.label13.TabIndex = 38;
      this.label13.Text = "Completed Test Cases:";
      this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label14
      // 
      this.label14.Location = new System.Drawing.Point(1, 257);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(135, 13);
      this.label14.TabIndex = 37;
      this.label14.Text = "Estimated Test Cases:";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblEndTime
      // 
      this.lblEndTime.Location = new System.Drawing.Point(361, 238);
      this.lblEndTime.Name = "lblEndTime";
      this.lblEndTime.Size = new System.Drawing.Size(98, 13);
      this.lblEndTime.TabIndex = 36;
      this.lblEndTime.Text = "1:00";
      this.lblEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblStartTime
      // 
      this.lblStartTime.Location = new System.Drawing.Point(144, 238);
      this.lblStartTime.Name = "lblStartTime";
      this.lblStartTime.Size = new System.Drawing.Size(98, 13);
      this.lblStartTime.TabIndex = 35;
      this.lblStartTime.Text = "1:00";
      this.lblStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label12
      // 
      this.label12.Location = new System.Drawing.Point(257, 238);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(98, 13);
      this.label12.TabIndex = 34;
      this.label12.Text = "End Time:";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label11
      // 
      this.label11.Location = new System.Drawing.Point(40, 238);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(98, 13);
      this.label11.TabIndex = 33;
      this.label11.Text = "Start Time:";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtPassword
      // 
      this.txtPassword.Location = new System.Drawing.Point(353, 214);
      this.txtPassword.MaxLength = 255;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.PasswordChar = '*';
      this.txtPassword.Size = new System.Drawing.Size(80, 22);
      this.txtPassword.TabIndex = 32;
      this.txtPassword.Text = "1234";
      // 
      // label10
      // 
      this.label10.Location = new System.Drawing.Point(248, 217);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(98, 13);
      this.label10.TabIndex = 31;
      this.label10.Text = "Password:";
      this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtUserName
      // 
      this.txtUserName.Location = new System.Drawing.Point(144, 213);
      this.txtUserName.MaxLength = 100;
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(100, 22);
      this.txtUserName.TabIndex = 30;
      this.txtUserName.Text = "1234";
      // 
      // label9
      // 
      this.label9.Location = new System.Drawing.Point(39, 216);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(98, 13);
      this.label9.TabIndex = 29;
      this.label9.Text = "User Name:";
      this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnTestLinks
      // 
      this.btnTestLinks.Location = new System.Drawing.Point(770, 101);
      this.btnTestLinks.Name = "btnTestLinks";
      this.btnTestLinks.Size = new System.Drawing.Size(144, 23);
      this.btnTestLinks.TabIndex = 27;
      this.btnTestLinks.Text = "Test Links";
      this.btnTestLinks.UseVisualStyleBackColor = true;
      this.btnTestLinks.Click += new System.EventHandler(this.btnTestLinks_Click);
      // 
      // btnQuickTest
      // 
      this.btnQuickTest.Location = new System.Drawing.Point(770, 71);
      this.btnQuickTest.Name = "btnQuickTest";
      this.btnQuickTest.Size = new System.Drawing.Size(144, 23);
      this.btnQuickTest.TabIndex = 25;
      this.btnQuickTest.Text = "Quick Test";
      this.btnQuickTest.UseVisualStyleBackColor = true;
      this.btnQuickTest.Click += new System.EventHandler(this.btnQuickTest_Click);
      // 
      // btnStartSetupTest
      // 
      this.btnStartSetupTest.Location = new System.Drawing.Point(770, 18);
      this.btnStartSetupTest.Name = "btnStartSetupTest";
      this.btnStartSetupTest.Size = new System.Drawing.Size(144, 23);
      this.btnStartSetupTest.TabIndex = 24;
      this.btnStartSetupTest.Text = "Start Setup Test";
      this.btnStartSetupTest.UseVisualStyleBackColor = true;
      this.btnStartSetupTest.Click += new System.EventHandler(this.btnStartSetupTest_Click);
      // 
      // txtRemoteHub
      // 
      this.txtRemoteHub.Location = new System.Drawing.Point(147, 99);
      this.txtRemoteHub.Name = "txtRemoteHub";
      this.txtRemoteHub.Size = new System.Drawing.Size(287, 22);
      this.txtRemoteHub.TabIndex = 3;
      this.txtRemoteHub.Text = "http://hub.testingbot.com:4444/wd/hub";
      // 
      // label8
      // 
      this.label8.Location = new System.Drawing.Point(42, 103);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(98, 13);
      this.label8.TabIndex = 23;
      this.label8.Text = "Remote Hub:";
      this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cboOS
      // 
      this.cboOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboOS.FormattingEnabled = true;
      this.cboOS.Location = new System.Drawing.Point(144, 15);
      this.cboOS.Name = "cboOS";
      this.cboOS.Size = new System.Drawing.Size(181, 22);
      this.cboOS.TabIndex = 0;
      this.cboOS.SelectionChangeCommitted += new System.EventHandler(this.cboOS_SelectionChangeCommitted);
      // 
      // label7
      // 
      this.label7.Location = new System.Drawing.Point(40, 19);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(98, 13);
      this.label7.TabIndex = 19;
      this.label7.Text = "OS:";
      this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtTimeout
      // 
      this.txtTimeout.Location = new System.Drawing.Point(353, 186);
      this.txtTimeout.MaxLength = 3;
      this.txtTimeout.Name = "txtTimeout";
      this.txtTimeout.Size = new System.Drawing.Size(80, 22);
      this.txtTimeout.TabIndex = 9;
      this.txtTimeout.Text = "120";
      // 
      // label6
      // 
      this.label6.Location = new System.Drawing.Point(248, 190);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(98, 13);
      this.label6.TabIndex = 15;
      this.label6.Text = "Action TimeOut:";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(770, 47);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(144, 23);
      this.btnStart.TabIndex = 17;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // txtUrl
      // 
      this.txtUrl.Location = new System.Drawing.Point(146, 72);
      this.txtUrl.Name = "txtUrl";
      this.txtUrl.Size = new System.Drawing.Size(287, 22);
      this.txtUrl.TabIndex = 2;
      this.txtUrl.Text = "http://mydoordev.clopay.com";
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(41, 76);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(98, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "URL:";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Location = new System.Drawing.Point(440, 126);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(32, 23);
      this.btnBrowse.TabIndex = 5;
      this.btnBrowse.Text = "...";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // txtImagePath
      // 
      this.txtImagePath.Location = new System.Drawing.Point(147, 127);
      this.txtImagePath.Name = "txtImagePath";
      this.txtImagePath.Size = new System.Drawing.Size(287, 22);
      this.txtImagePath.TabIndex = 4;
      this.txtImagePath.Text = "E:\\Test Projects\\MyDoor Test Automation\\Images";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(7, 130);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(133, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "Image Output Path:";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // chkAllCollections
      // 
      this.chkAllCollections.AutoSize = true;
      this.chkAllCollections.Checked = true;
      this.chkAllCollections.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkAllCollections.Location = new System.Drawing.Point(533, 17);
      this.chkAllCollections.Name = "chkAllCollections";
      this.chkAllCollections.Size = new System.Drawing.Size(99, 18);
      this.chkAllCollections.TabIndex = 15;
      this.chkAllCollections.Text = "All Collections";
      this.chkAllCollections.UseVisualStyleBackColor = true;
      this.chkAllCollections.CheckedChanged += new System.EventHandler(this.chkAllCollections_CheckedChanged);
      // 
      // grpCollections
      // 
      this.grpCollections.Controls.Add(this.clbCollection);
      this.grpCollections.Location = new System.Drawing.Point(523, 17);
      this.grpCollections.Name = "grpCollections";
      this.grpCollections.Size = new System.Drawing.Size(209, 210);
      this.grpCollections.TabIndex = 12;
      this.grpCollections.TabStop = false;
      // 
      // clbCollection
      // 
      this.clbCollection.CheckOnClick = true;
      this.clbCollection.FormattingEnabled = true;
      this.clbCollection.Items.AddRange(new object[] {
            "Avante",
            "Canyon Ridge",
            "ReserveLimited",
            "ReserveSemiCustom",
            "Coachman",
            "Gallery",
            "Grand Harbor",
            "Premium",
            "Value Plus",
            "Value"});
      this.clbCollection.Location = new System.Drawing.Point(21, 27);
      this.clbCollection.Name = "clbCollection";
      this.clbCollection.Size = new System.Drawing.Size(166, 174);
      this.clbCollection.TabIndex = 0;
      // 
      // txtOrderNo
      // 
      this.txtOrderNo.Location = new System.Drawing.Point(146, 185);
      this.txtOrderNo.MaxLength = 5;
      this.txtOrderNo.Name = "txtOrderNo";
      this.txtOrderNo.Size = new System.Drawing.Size(96, 22);
      this.txtOrderNo.TabIndex = 8;
      this.txtOrderNo.Text = "1234";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(41, 188);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(98, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Order No:";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cboBrowser
      // 
      this.cboBrowser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboBrowser.FormattingEnabled = true;
      this.cboBrowser.Location = new System.Drawing.Point(145, 43);
      this.cboBrowser.Name = "cboBrowser";
      this.cboBrowser.Size = new System.Drawing.Size(181, 22);
      this.cboBrowser.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.Location = new System.Drawing.Point(41, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Browser:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // errProvider
      // 
      this.errProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      this.errProvider.ContainerControl = this;
      // 
      // VisualizationTestEnigneForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(970, 508);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.statusStrip1);
      this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(777, 439);
      this.Name = "VisualizationTestEnigneForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Visualization Engine Test ";
      this.Load += new System.EventHandler(this.VisualizationTestEnigneForm_Load);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabResults.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
      this.ctxGrid.ResumeLayout(false);
      this.tabStatus.ResumeLayout(false);
      this.grpMain.ResumeLayout(false);
      this.grpMain.PerformLayout();
      this.grpOptions.ResumeLayout(false);
      this.grpOptions.PerformLayout();
      this.grpCollections.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errProvider)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripProgressBar prgStatus;
    private System.Windows.Forms.ToolStripStatusLabel lblMessage;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.GroupBox grpMain;
    private System.Windows.Forms.CheckBox chkImages;
    private System.Windows.Forms.CheckBox chkAllCollections;
    private System.Windows.Forms.CheckBox chkStopOnError;
    private System.Windows.Forms.GroupBox grpCollections;
    private System.Windows.Forms.CheckedListBox clbCollection;
    private System.Windows.Forms.TextBox txtOrderNo;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cboBrowser;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtImagePath;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button btnBrowse;
    private System.Windows.Forms.CheckBox chkData;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ErrorProvider errProvider;
    private System.Windows.Forms.CheckBox chkClear;
    private System.Windows.Forms.TextBox txtTimeout;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.CheckBox chkCaptureAllImages;
    private System.Windows.Forms.ComboBox cboOS;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox txtRemoteHub;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabResults;
    private System.Windows.Forms.DataGridView dgvResults;
    private System.Windows.Forms.TabPage tabStatus;
    private System.Windows.Forms.RichTextBox txtStatus;
    private System.Windows.Forms.Button btnStartSetupTest;
    private System.Windows.Forms.Button btnQuickTest;
    private System.Windows.Forms.Button btnTestLinks;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label lblEndTime;
    private System.Windows.Forms.Label lblStartTime;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button btnHardware;
    private System.Windows.Forms.Button btnTopSections;
    private System.Windows.Forms.Label txtCompleted;
    private System.Windows.Forms.Label txtEstimated;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Button btnTestImages;
    private System.Windows.Forms.Button btnStop;
    private System.Windows.Forms.ContextMenuStrip ctxGrid;
    private System.Windows.Forms.ToolStripMenuItem exportToExcelToolStripMenuItem;
    private System.Windows.Forms.ComboBox cboWidthInches;
    private System.Windows.Forms.ComboBox cboHeightInches;
    private System.Windows.Forms.Label lblheightin;
    private System.Windows.Forms.Label lblwidthft;
    private System.Windows.Forms.Label lblheightft;
    private System.Windows.Forms.Label lblwidthin;
    private System.Windows.Forms.Label lblheight;
    private System.Windows.Forms.Label lblwidth;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cboHeightFeet;
    private System.Windows.Forms.ComboBox cboWidthFeet;
    private System.Windows.Forms.ToolStripMenuItem exportToXmlToolStripMenuItem;
    private System.Windows.Forms.ToolStripStatusLabel lblVersion;
    private System.Windows.Forms.CheckBox chkPerformanceTest;
    private System.Windows.Forms.GroupBox grpOptions;
  }
}