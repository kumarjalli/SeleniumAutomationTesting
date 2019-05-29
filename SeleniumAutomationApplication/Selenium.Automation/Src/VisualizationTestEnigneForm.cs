
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace Selenium.Automation
{
    public partial class VisualizationTestEnigneForm : Form {
        #region "Locals"
        private BackgroundWorker m_TestRunner;
        private BindingList<DoorTestingResult> m_TestData;
        private SynchronizationContext m_UIContext = null;
        #endregion

        #region "Constructor"
        public VisualizationTestEnigneForm() {
            InitializeComponent();
            m_TestData = new BindingList<DoorTestingResult>();
            dgvResults.DataSource = m_TestData;
            //dgvResults.Columns["Url"].Width = 300;
            //dgvResults.Columns["Description"].Width = 150;
            dgvResults.Columns["ExecutionTime"].Width = 100;
            dgvResults.Columns["ExecutionTime"].HeaderText = "Execution Time(Sec)";
            dgvResults.Columns["Result"].Width = 100;
            m_UIContext = SynchronizationContext.Current ?? new SynchronizationContext();
        }
        #endregion

        #region "Events"
        private void exportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvResults.Rows.Count > 0)
                {
                    string filName = System.IO.Path.Combine(txtImagePath.Text, "Test Cases.xls");
                    ExcelHelper.ExportData(dgvResults, filName);
                }
            }
            catch (Exception ex)
            {
                txtStatus.Text += ex.ToString() + @"\n";
            }
        }

        private void cboOS_SelectionChangeCommitted(object sender, EventArgs e) {
            if (!string.IsNullOrWhiteSpace(cboOS.SelectedText)) {
                switch (cboOS.SelectedText) {
                    case "Android":
                        cboBrowser.Enabled = false;
                        break;
                    case "iOS(iPad)":
                        cboBrowser.Enabled = false;
                        break;
                    default:
                        cboBrowser.Enabled = true;
                        txtRemoteHub.Enabled = true;
                        break;
                }
            }
        }

        private void btnTestLinks_Click(object sender, EventArgs e) {
            TestLinks();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            txtImagePath.Text = BrowseForFolder("Select Image Output Path");
        }

        private void btnUserPath_Click(object sender, EventArgs e) {
            txtImagePath.Text = BrowseForFolder("Select User Images Folder Path");
        }

        private void chkAllCollections_CheckedChanged(object sender, EventArgs e) {
            //grpCollections.Enabled = chkAllCollections.Checked;
            if (chkAllCollections.Checked) {
                SelectAllCollections(true);
            }
            else {
                SelectAllCollections(false);
            }
        }

        private void btnStartSetupTest_Click(object sender, EventArgs e) {
            StartSetupTest();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            TestMyDoorImages(false);
        }

        private void btnQuickTest_Click(object sender, EventArgs e) {
            TestMyDoorImages(true);
        }

        #endregion

        #region "Form Events"

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            lblStartTime.Text = "";
            lblEndTime.Text = "";
            prgStatus.Visible = false;
            chkAllCollections.Checked = true;
            SelectAllCollections(true);
            cboBrowser.Items.Clear();
            cboBrowser.DataSource = (Enum.GetNames(typeof(Browsers))).ToList<string>();
            cboOS.Items.Clear();
            cboOS.DataSource = (Enum.GetNames(typeof(OperatingSystem))).ToList<string>();
            LoadSettings();
        }

        protected override void OnClosing(CancelEventArgs e) {
            base.OnClosing(e);
            SaveSettings();
        }

        private void LoadSettings() {
            try {
                txtImagePath.Text = Properties.Settings.Default.txtImagePath;
                txtOrderNo.Text = Properties.Settings.Default.txtZipCode;
                txtUrl.Text = Properties.Settings.Default.txtURL;
                txtUserName.Text = Properties.Settings.Default.txtUserName;
                txtPassword.Text = Properties.Settings.Default.txtPassword;
                txtTimeout.Text = Properties.Settings.Default.txtTimeout.ToString();
                cboBrowser.SelectedItem = Properties.Settings.Default.cboBrowser;
                chkClear.Checked = Properties.Settings.Default.chkClear;
                chkData.Checked = Properties.Settings.Default.chkData;
                chkImages.Checked = Properties.Settings.Default.chkImages;
                chkStopOnError.Checked = Properties.Settings.Default.chkStopOnError;
                chkAllCollections.Checked = Properties.Settings.Default.chkAllCollections;
                chkCaptureAllImages.Checked = Properties.Settings.Default.chkCaptureAllImages;
                txtRemoteHub.Text = Properties.Settings.Default.txtRemoteHub;
                cboOS.SelectedItem = Properties.Settings.Default.cboOS;
                cboWidthFeet.SelectedItem = Properties.Settings.Default.cboWidthFt;
                cboWidthInches.SelectedItem = Properties.Settings.Default.cboWidthIn;
                cboHeightFeet.SelectedItem = Properties.Settings.Default.cboHeightFt;
                cboHeightInches.SelectedItem = Properties.Settings.Default.cboHeightIn;
            }
            catch (Exception ex) {
                txtStatus.Text += ex.ToString();
            }
        }

        private void SaveSettings() {
            try {
                Properties.Settings.Default.txtImagePath = txtImagePath.Text;
                Properties.Settings.Default.txtZipCode = txtOrderNo.Text;
                Properties.Settings.Default.txtURL = txtUrl.Text;
                Properties.Settings.Default.cboBrowser = cboBrowser.Text;
                Properties.Settings.Default.chkClear = chkClear.Checked;
                Properties.Settings.Default.chkData = chkData.Checked;
                Properties.Settings.Default.chkImages = chkImages.Checked;
                Properties.Settings.Default.chkStopOnError = chkStopOnError.Checked;
                Properties.Settings.Default.chkAllCollections = chkAllCollections.Checked;
                Properties.Settings.Default.chkCaptureAllImages = chkCaptureAllImages.Checked;
                Properties.Settings.Default.txtTimeout = txtTimeout.Text;
                Properties.Settings.Default.txtRemoteHub = txtRemoteHub.Text;
                Properties.Settings.Default.cboOS = cboOS.Text;
                Properties.Settings.Default.txtUserName = txtUserName.Text;
                Properties.Settings.Default.txtPassword = txtPassword.Text;
                Properties.Settings.Default.cboWidthFt = cboWidthFeet.Text;
                Properties.Settings.Default.cboWidthIn = cboWidthInches.Text;
                Properties.Settings.Default.cboHeightFt = cboHeightFeet.Text;
                Properties.Settings.Default.cboHeightIn = cboHeightInches.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex) {
                txtStatus.Text += ex.ToString();
            }
        }
        #endregion

        #region "Async"

        private void TestingCompleted(object sender, RunWorkerCompletedEventArgs e) {
            grpMain.Enabled = true;
            prgStatus.Visible = false;
            btnStop.Enabled = false;
            lblMessage.Text = "Test Setup Data Completed.";
            lblEndTime.Text = DateTime.Now.ToShortTimeString();
        }

        private void UpdateProgressChange(object sender, ProgressChangedEventArgs e) {
            if (txtStatus.InvokeRequired) {
                m_UIContext.Send(UpdateProgressChange, (e.UserState));
            }
            else {
                UpdateProgressChange(e.UserState);
            }
        }

        private void UpdateProgressChange(object userState) {

            if (userState.GetType() == typeof(string)) {
                lblMessage.Text = (string)userState;
            }
            else if (userState.GetType() == typeof(Exception)) {
                txtStatus.Text += ((Exception)userState).ToString();
            }
            else if (userState.GetType() == typeof(DoorTestingResult))
            {
                m_TestData.Add((DoorTestingResult)userState);
                m_TestData.ResetBindings();
                if (m_TestData.Count > 0) {
                  if (dgvResults.Rows.Count > 0)
                  {
                    dgvResults.FirstDisplayedScrollingRowIndex = dgvResults.Rows.Count - 1;
                  }
                  else
                  {
                    dgvResults.FirstDisplayedScrollingRowIndex = 0;
                  }
                }
            }
            else {
                txtStatus.Text += userState.ToString();
            }
        }

        private void TestLinksAsync(object sender, DoWorkEventArgs e) {
            ((TestingContext)e.Argument).TestRunner = (BackgroundWorker)sender;
            MyDoorPageController.TestPages(((TestingContext)e.Argument));
        }


        private void TestMyDoorImagesAsync(object sender, DoWorkEventArgs e) {
            lblStartTime.Text = DateTime.Now.ToShortTimeString();
            ((TestingContext)e.Argument).TestRunner = (BackgroundWorker)sender;
            MyDoorPageController.TestConfigurator(((TestingContext)e.Argument), true);
        }

        private void TestSetupdataAsync(object sender, DoWorkEventArgs e) {
            lblStartTime.Text = DateTime.Now.ToShortTimeString();
            ((TestingContext)e.Argument).TestRunner = (BackgroundWorker)sender;
            MyDoorPageController.TestConfiguratorSetup((TestingContext)e.Argument);
        }

        #endregion

        #region "Private"

        private List<DoorLine> GetSelectedCollections() {
            List<DoorLine> lineCollection = new List<DoorLine>();
            if (clbCollection.GetItemChecked(0)) {
                lineCollection.Add(DoorLine.Avante);
            }
            if (clbCollection.GetItemChecked(1)) {
                lineCollection.Add(DoorLine.CanyonRidge);
            }
            if (clbCollection.GetItemChecked(2)) {
              lineCollection.Add(DoorLine.ReserveLimited);
            }
            if (clbCollection.GetItemChecked(3))
            {
              lineCollection.Add(DoorLine.ReserveSemiCustom);
            }
            if (clbCollection.GetItemChecked(4)) {
                lineCollection.Add(DoorLine.Coachman);
            }
            if (clbCollection.GetItemChecked(5)) {
                lineCollection.Add(DoorLine.Gallery);
            }

            if (clbCollection.GetItemChecked(6)) {
                lineCollection.Add(DoorLine.GrandHarbor);
            }
            if (clbCollection.GetItemChecked(7)) {
                lineCollection.Add(DoorLine.Premium);
            }
            if (clbCollection.GetItemChecked(8)) {
                lineCollection.Add(DoorLine.ValuePlus);
            }
            if (clbCollection.GetItemChecked(9)) {
                lineCollection.Add(DoorLine.Value);
            }
            return lineCollection;
        }

        private TestingContext ValidateParameters() {
            TestingContext context = null;
            errProvider.Clear();
            bool validParameters = true;
            if (txtOrderNo.Text.Length == 0) {
                errProvider.SetError(txtOrderNo, "Enter Zip Code");
                validParameters = false;
            }
            if (txtUrl.Text.Length == 0) {
                errProvider.SetError(txtUrl, "Enter URL");
                validParameters = false;
            }
            if (txtTimeout.Text.Length == 0) {
                txtTimeout.Text = "120";
            }

            if (cboOS.Text.Length == 0) {
                errProvider.SetError(cboOS, "Select a Operating System to test");
                validParameters = false;
            }
            if (cboOS.SelectedText == OperatingSystem.Andoid.ToString() ||
              cboOS.SelectedText == OperatingSystem.iOS.ToString()) {
                if (txtRemoteHub.Text.Length == 0) {
                    errProvider.SetError(txtRemoteHub, "Enter Remote Hub Url");
                    validParameters = false;
                }
            }
            else {
                if (cboBrowser.Text.Length == 0) {
                    errProvider.SetError(cboBrowser, "Select a Browser to test");
                    validParameters = false;
                }
            }
            if (txtUserName.Text.Length == 0) {
                errProvider.SetError(txtUserName, "Enter User Name");
                validParameters = false;
            }
            if (txtPassword.Text.Length == 0) {
                errProvider.SetError(txtPassword, "Enter Password");
                validParameters = false;
            }
            if (cboWidthFeet.Text.Length == 0)
            {
                errProvider.SetError(cboWidthFeet, "Select Width Feet");
                validParameters = false;
            }
            if (cboWidthInches.Text.Length == 0)
            {
                errProvider.SetError(cboWidthInches, "Select Width Inches");
                validParameters = false;
            }
            if (cboHeightFeet.Text.Length == 0)
            {
                errProvider.SetError(cboHeightFeet, "Select Height Feet");
                validParameters = false;
            }
            if (cboHeightInches.Text.Length == 0)
            {
                errProvider.SetError(cboHeightInches, "Select Height Inches");
                validParameters = false;
            }
            if (txtImagePath.Text.Length == 0) {
                errProvider.SetError(txtImagePath, "Enter Image Path");
                validParameters = false;
            }
            if (!chkAllCollections.Checked && (clbCollection.CheckedItems.Count == 0)) {
                errProvider.SetError(grpCollections, "Select one or more collections to test");
                validParameters = false;
            }
            Browsers browser = (Browsers)(Enum.Parse(typeof(Browsers), cboBrowser.Text, true));
            OperatingSystem os = (OperatingSystem)(Enum.Parse(typeof(OperatingSystem), cboOS.Text, true));
            if (browser == Browsers.Android || os == OperatingSystem.Andoid || os == OperatingSystem.iOS || os == OperatingSystem.Mac) {

                if (txtRemoteHub.Text.Length == 0) {
                    errProvider.SetError(txtRemoteHub, "Enter Remote Hub Url");
                    validParameters = false;
                }
            }

            if (validParameters) {
                context = new TestingContext(new Uri(txtUrl.Text.Trim()), browser, os);
                context.PerformanceTest = chkPerformanceTest.Checked;
                if (chkPerformanceTest.Checked)
                {
                  context.ClearData = false;
                  context.ValidateData = false;
                  context.ValidateImages = false;
                  context.CaptureAllImages = false;
                  context.StopOnError = false;
                }
                else
                {
                  context.ClearData = chkClear.Checked;
                  context.ValidateData = chkData.Checked;
                  context.ValidateImages = chkImages.Checked;
                  context.CaptureAllImages = chkCaptureAllImages.Checked;
                  context.StopOnError = chkStopOnError.Checked;
                }
                context.ImagePath = txtImagePath.Text.Trim();
                context.TestAttributes.Add("OrderNumber", txtOrderNo.Text.Trim());
                context.TestAttributes.Add("UserName", txtUserName.Text.Trim());
                context.TestAttributes.Add("Password", txtPassword.Text.Trim());
                context.TestAttributes.Add("Collection", GetSelectedCollections());
                context.TestAttributes.Add("WidthIn", cboWidthInches.Text.Trim());
                context.TestAttributes.Add("WidthFt", cboWidthFeet.Text.Trim());
                context.TestAttributes.Add("HeightIn", cboHeightInches.Text.Trim());
                context.TestAttributes.Add("HeightFt", cboHeightFeet.Text.Trim());
                if (!string.IsNullOrWhiteSpace(txtRemoteHub.Text)) {
                    context.RemoteUrl = new Uri(txtRemoteHub.Text.Trim());
                }
            }
            return context;
        }

        private void TestMyDoorImages(bool quickTest) {
            try {
                ClearData();
                TestingContext context = ValidateParameters();
                if (context != null) {
                    prgStatus.Visible = true;
                    lblMessage.Text = "Testing Visualization Engine..";
                    lblStartTime.Text = DateTime.Now.ToShortTimeString();
                    context.QuickTest = quickTest;
                    m_TestRunner = new BackgroundWorker();
                    m_TestRunner.WorkerSupportsCancellation = true;
                    m_TestRunner.WorkerReportsProgress = true;
                    m_TestRunner.DoWork += new DoWorkEventHandler(TestMyDoorImagesAsync);
                    m_TestRunner.ProgressChanged += new ProgressChangedEventHandler(UpdateProgressChange);
                    m_TestRunner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestingCompleted);
                    m_TestRunner.RunWorkerAsync(context);
                }
                else {
                    grpMain.Enabled = true;
                    prgStatus.Visible = false;
                }
            }
            catch (Exception ex) {
                grpMain.Enabled = true;
                prgStatus.Visible = false;
                lblMessage.Text = "";
                txtStatus.Text += ex.ToString();
            }
        }

        private void StartSetupTest() {
            try {
                grpMain.Enabled = false;
                TestingContext context = ValidateParameters();

                if (context != null) {
                    prgStatus.Visible = true;
                    lblMessage.Text = "Testing Visualization Engine..";
                    lblStartTime.Text = DateTime.Now.ToShortTimeString();
                    m_TestRunner = new BackgroundWorker();
                    m_TestRunner.WorkerSupportsCancellation = true;
                    m_TestRunner.WorkerReportsProgress = true;
                    m_TestRunner.DoWork += new DoWorkEventHandler(TestSetupdataAsync);
                    m_TestRunner.ProgressChanged += new ProgressChangedEventHandler(UpdateProgressChange);
                    m_TestRunner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestingCompleted);
                    m_TestRunner.RunWorkerAsync(context);
                }
                else {
                    grpMain.Enabled = true;
                    prgStatus.Visible = false;
                }
            }
            catch (Exception ex) {
                grpMain.Enabled = true;
                prgStatus.Visible = false;
                lblMessage.Text = "";
                txtStatus.Text += ex.ToString();
            }
        }

        private void SelectAllCollections(bool selectOptions) {
            for (int index = 0; index < clbCollection.Items.Count; index++) {
                clbCollection.SetItemChecked(index, selectOptions);
            }
        }

        private string BrowseForFolder(string msg) {
            return "";
        }
        private void TestImages() {
            try {
                ClearData();
                TestingContext context = ValidateParameters();
                if (context != null) {
                    prgStatus.Visible = true;
                    lblMessage.Text = "Testing Images..";
                    lblStartTime.Text = DateTime.Now.ToShortTimeString();
                    m_TestRunner = new BackgroundWorker();
                    m_TestRunner.WorkerSupportsCancellation = true;
                    m_TestRunner.WorkerReportsProgress = true;
                    m_TestRunner.DoWork += new DoWorkEventHandler(TestImagesAsync);
                    m_TestRunner.ProgressChanged += new ProgressChangedEventHandler(UpdateProgressChange);
                    m_TestRunner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestingCompleted);
                    m_TestRunner.RunWorkerAsync(context);
                }
                else {
                    grpMain.Enabled = true;
                    prgStatus.Visible = false;
                }
            }
            catch (Exception ex) {
                txtStatus.Text += ex.ToString();
                grpMain.Enabled = true;
                prgStatus.Visible = false;
                lblMessage.Text = "Test Failed.";
                lblEndTime.Text = DateTime.Now.ToShortTimeString();
            }
        }
        private void TestLinks() {
            try {
                ClearData();
                TestingContext context = ValidateParameters();
                if (context != null) {
                    prgStatus.Visible = true;
                    lblMessage.Text = "Testing Links..";
                    lblStartTime.Text = DateTime.Now.ToShortTimeString();
                    m_TestRunner = new BackgroundWorker();
                    m_TestRunner.WorkerSupportsCancellation = true;
                    m_TestRunner.WorkerReportsProgress = true;
                    m_TestRunner.DoWork += new DoWorkEventHandler(TestLinksAsync);
                    m_TestRunner.ProgressChanged += new ProgressChangedEventHandler(UpdateProgressChange);
                    m_TestRunner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestingCompleted);
                    m_TestRunner.RunWorkerAsync(context);
                }
                else {
                    grpMain.Enabled = true;
                    prgStatus.Visible = false;
                }
            }
            catch (Exception ex) {
                txtStatus.Text += ex.ToString();
                grpMain.Enabled = true;
                prgStatus.Visible = false;
                lblMessage.Text = "Test Failed.";
                lblEndTime.Text = DateTime.Now.ToShortTimeString();
            }
        }
        private void ClearData() {
            grpMain.Enabled = false;
            lblEndTime.Text = "";
            errProvider.Clear();
            txtStatus.Text = "";
            m_TestData.Clear();
        }

        #endregion

        private void btnHardware_Click(object sender, EventArgs e) {
            try {
                ClearData();
                TestingContext context = ValidateParameters();
                if (context != null) {
                    prgStatus.Visible = true;
                    lblMessage.Text = "Testing Visualization Engine..";
                    lblStartTime.Text = DateTime.Now.ToShortTimeString();

                    m_TestRunner = new BackgroundWorker();
                    m_TestRunner.WorkerSupportsCancellation = true;
                    m_TestRunner.WorkerReportsProgress = true;
                    m_TestRunner.DoWork += new DoWorkEventHandler(TestAdminLinksAsync);
                    m_TestRunner.ProgressChanged += new ProgressChangedEventHandler(UpdateProgressChange);
                    m_TestRunner.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestingCompleted);
                    m_TestRunner.RunWorkerAsync(context);
                }
                else {
                    grpMain.Enabled = true;
                    prgStatus.Visible = false;
                }
            }
            catch (Exception ex) {
                grpMain.Enabled = true;
                prgStatus.Visible = false;
                lblMessage.Text = "";
                txtStatus.Text += ex.ToString();
            }

        }


        private void TestAdminLinksAsync(object sender, DoWorkEventArgs e) {
            ((TestingContext)e.Argument).TestRunner = (BackgroundWorker)sender;
            APIController.PopulateSetupData(((TestingContext)e.Argument));
        }
        private void TestImagesAsync(object sender, DoWorkEventArgs e) {
            ((TestingContext)e.Argument).TestRunner = (BackgroundWorker)sender;
            MyDoorPageController.TestImages(((TestingContext)e.Argument));
        }

        private void btnTopSections_Click(object sender, EventArgs e) {

        }

        private void btnTestImages_Click(object sender, EventArgs e) {
            TestImages();
        }

        private void exportToXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
          try
          {
            if (dgvResults.Rows.Count > 0)
            {
              string filName = System.IO.Path.Combine(txtImagePath.Text, "Test Cases.xml");
           //    ExcelHelper.ExportData(dgvResults, filName);
            }
          }
          catch (Exception ex)
          {
            txtStatus.Text += ex.ToString() + @"\n";
          }
        }

        private void VisualizationTestEnigneForm_Load(object sender, EventArgs e)
        {
          lblVersion.Text = Application.ProductVersion;
        }

        private void chkPerformanceTest_CheckedChanged(object sender, EventArgs e)
        {
          bool enableoptions = chkPerformanceTest.Checked;
          grpOptions.Enabled = !enableoptions;
         
        }
    }

}
  