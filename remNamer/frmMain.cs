using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using remNamer.Class;

namespace remNamer
{
    public partial class FrmMain : MaterialForm
    {
        private OpenFileDialog OpenFileDialog = new OpenFileDialog();
        private List<FileToRename> FileList = new List<FileToRename>();
        private MaterialSkinManager MaterialSkinManager;
        private PatternFinder PatternFinder = new PatternFinder();

        public FrmMain()
        {
            InitializeComponent();

            //Material skin setup
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange300, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            //Windows not allow select folder without this
            OpenFileDialog.ValidateNames = false;
            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.CheckPathExists = true;
            OpenFileDialog.FileName = "Folder Selection";

            //Resize columns in DataGridViews
            dgvFileInfo.AllowUserToResizeColumns = true;
            dgvFileInfo.AllowUserToResizeRows = true;
            dgvFileInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPatterns.AllowUserToResizeColumns = true;
            dgvPatterns.AllowUserToResizeRows = true;
            dgvPatterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            //User can set the directory directly
            if (!String.IsNullOrEmpty(txtOriginDirectory.Text))
            {
                OpenFileDialog.InitialDirectory = txtOriginDirectory.Text;
            }

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFileDialog.FileName.StartsWith(Environment.GetEnvironmentVariable("windir")))
                {
                    MessageBox.Show("System files is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtOriginDirectory.Text = OpenFileDialog.FileName.Replace("Folder Selection", "");

                ApplyExtensionFilter();
            }
        }

        private void SwitchViewMode_CheckedChanged(object sender, EventArgs e)
        {
            MaterialSwitch switchView = (MaterialSwitch)sender;
            ChangeTheme(switchView.Checked);
        }

        private void DgvPatterns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvPatterns.CurrentCell != null && dgvPatterns.CurrentCell.Value != null)
            {
                string preSpace = "";
                if (txtToSearch.Text != "")
                {
                    preSpace = " ";
                }

                txtToSearch.AppendText(preSpace + dgvPatterns.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            PreviewSearchAndReplaceChanges();
        }

        private void BtnPreviewIncremental_Click(object sender, EventArgs e)
        {
            PreviewIncrementalChanges();
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            //Be sure that collections are updated
            if (tabControl1.SelectedIndex == 0)
            {
                PreviewSearchAndReplaceChanges();
            }
            else
            {
                PreviewIncrementalChanges();
            }

            //Block form
            this.Enabled = false;

            //Change files
            foreach (var item in this.FileList)
            {
                item.RenameFile();
            }

            //Reload files
            ApplyExtensionFilter();

            //Unblock form
            this.Enabled = true;
        }

        private void BtnApplyFileFilter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtExtensionFilter.Text) && !String.IsNullOrWhiteSpace(txtExtensionFilter.Text))
            {
                ApplyExtensionFilter();
            }
        }

        private void ChangeTheme(Boolean isDarkTheme)
        {

            Color gridForeColor = Color.Black;
            Color backColor = Color.White;
            MaterialSkinManager.Themes themeToSet = MaterialSkinManager.Themes.LIGHT;

            if (isDarkTheme)
            {
                gridForeColor = Color.White;
                backColor = Color.DarkGray;
                themeToSet = MaterialSkinManager.Themes.DARK;
            }

            //dgv not works well with dark mode so we need to change it manually
            dgvFileInfo.ForeColor = gridForeColor;
            dgvPatterns.ForeColor = gridForeColor;
            MaterialSkinManager.Theme = themeToSet;

            foreach (DataGridViewRow row in dgvFileInfo.Rows)
            {
                row.DefaultCellStyle.BackColor = backColor;
            }
            foreach (DataGridViewRow row in dgvPatterns.Rows)
            {
                row.DefaultCellStyle.BackColor = backColor;
            }
        }

        private void LoadDataBinding_Files(bool searchPatterns)
        {
            BindingSource BindingSource = new BindingSource();
            BindingSource.DataSource = FileList;
            dgvFileInfo.DataSource = BindingSource;

            if (searchPatterns)
            {
                var patternsDictionary = PatternFinder.SearchPatterns(FileList);
                LoadDataBinding_Patterns(patternsDictionary);
            }

            //Need to refresh material theme...
            ChangeTheme(switchViewMode.Checked);
        }

        private void LoadFilesToDataGrid(string[] extensionFilters)
        {
            if (txtOriginDirectory.Text != string.Empty && !Path.HasExtension(txtOriginDirectory.Text))
            {
                //Clean list from previous executions
                FileList = new List<FileToRename>();

                try
                {
                    var files = GetFiles(txtOriginDirectory.Text, chkSearchFilesRecursively.Checked, extensionFilters);

                    foreach (var item in files)
                    {
                        //Apply filter if exist
                        FileList.Add(new FileToRename(item));
                    }

                    //Refresh grids
                    LoadDataBinding_Files(chkSearchPatterns.Checked);
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private List<string> GetFiles(string initialDirPath, bool recursiveSearch, string[] extensionFilters)
        {
            //Get files in root directory
            List<string> files = new List<string>();

            if (recursiveSearch)
            {
                var directories = Directory.GetDirectories(initialDirPath);

                foreach (var subDirectoryPath in directories)
                {
                    var subItems = GetFilesUsingFilters(subDirectoryPath, extensionFilters);
                    files.AddRange(subItems);
                }
            }
            else
            {
                files = GetFilesUsingFilters(initialDirPath, extensionFilters);
            }

            return files;
        }

        private List<string> GetFilesUsingFilters(string directoryPath, string[] extensionFilters)
        {
            List<string> files = null;
            if (extensionFilters != null)
            {
                files = extensionFilters.SelectMany(filter => Directory.GetFiles(directoryPath, filter)).ToList();
            }
            else
            {
                files = Directory.GetFiles(directoryPath).ToList();
            }

            return files;
        }

        private void LoadDataBinding_Patterns(Dictionary<string, int> dict)
        {
            try
            {
                if (dict.Values.Count > 0)
                {
                    BindingSource bindingSourcePattern = new BindingSource();
                    dict = dict.OrderBy(o => o.Key).ToDictionary(x => x.Key, x => x.Value);
                    bindingSourcePattern.DataSource = dict;
                    dgvPatterns.DataSource = bindingSourcePattern;

                    dgvPatterns.Columns[0].HeaderText = "Word";
                    dgvPatterns.Columns[1].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplyExtensionFilter()
        {
            //Get filters
            string availableExt = txtExtensionFilter.Text.Trim();
            string[] availableExtArray = null;

            //First validate filter
            if (!string.IsNullOrEmpty(txtExtensionFilter.Text)
                && !string.IsNullOrWhiteSpace(txtExtensionFilter.Text)
                && availableExt.IndexOf(";") != -1)
            {
                //Multifilter                
                availableExtArray = availableExt.Split(';');
            }

            //Refresh dgv
            LoadFilesToDataGrid(availableExtArray);
        }

        private void PreviewIncrementalChanges()
        {
            if (txtIncremental.Text != string.Empty)
            {
                string titleToSet = txtIncremental.Text;

                for (int i = 0; i < FileList.Count; i++)
                {
                    FileList[i].SetNameAfterChanges(titleToSet.Replace("*", (i + 1).ToString()));
                }
            }

            //Refresh dgv
            LoadDataBinding_Files(false);
        }

        private void PreviewSearchAndReplaceChanges()
        {
            if (txtToSearch.Text != string.Empty)
            {
                foreach (var item in FileList)
                {
                    item.SetNameAfterChanges(item.Name.Replace(txtToSearch.Text, txtReplace.Text));
                }
            }

            //Refresh dgv
            LoadDataBinding_Files(false);
        }

        private void TxtToSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtToSearch.Text != string.Empty)
            {
                btnPreview.Enabled = true;
            }
            else
            {
                btnPreview.Enabled = false;
            }

            ChangeBtnRenameEnable();
        }

        private void TxtIncremental_TextChanged(object sender, EventArgs e)
        {
            if (txtIncremental.Text != string.Empty)
            {
                btnPreviewIncremental.Enabled = true;
            }
            else
            {
                btnPreviewIncremental.Enabled = false;
            }

            ChangeBtnRenameEnable();
        }

        private void ChangeBtnRenameEnable()
        {
            if (txtIncremental.Text != string.Empty || txtToSearch.Text != string.Empty)
            {
                btnRename.Enabled = true;
            }
            else
            {
                btnRename.Enabled = false;
            }
        }
    }
}
