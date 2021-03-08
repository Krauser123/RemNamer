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
        private OpenFileDialog cmdDialog = new OpenFileDialog();
        private BindingSource bindingSource = new BindingSource();
        private List<FileToRename> fileList = new List<FileToRename>();
        private MaterialSkinManager materialSkinManager;
        private PatternFinder patternFinder = new PatternFinder();

        public FrmMain()
        {
            InitializeComponent();

            //Material skin setup
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange300, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            //Windows not allow select folder without this
            cmdDialog.ValidateNames = false;
            cmdDialog.CheckFileExists = false;
            cmdDialog.CheckPathExists = true;
            cmdDialog.FileName = "Folder Selection";
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            //User can set the directory directly
            if (!String.IsNullOrEmpty(txtOriginDirectory.Text))
            {
                cmdDialog.InitialDirectory = txtOriginDirectory.Text;
            }

            if (cmdDialog.ShowDialog() == DialogResult.OK)
            {
                if (cmdDialog.FileName.StartsWith(Environment.GetEnvironmentVariable("windir")))
                {
                    MessageBox.Show("System files is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtOriginDirectory.Text = cmdDialog.FileName.Replace("Folder Selection", "");

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
                if (txtToSearch.Text == "")
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
            foreach (var item in this.fileList)
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
            materialSkinManager.Theme = themeToSet;

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
            bindingSource.DataSource = fileList;
            dgvFileInfo.DataSource = bindingSource;

            dgvFileInfo.AllowUserToResizeColumns = true;
            dgvFileInfo.AllowUserToResizeRows = true;

            //Resize columns in DataGridView
            dgvFileInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (searchPatterns)
            {
                var dict = patternFinder.SearchPatterns(fileList);
                LoadDataBinding_Patterns(dict);
            }
        }

        private void LoadFilesToDataGrid(string[] extensionFilters)
        {
            if (txtOriginDirectory.Text != string.Empty && !Path.HasExtension(txtOriginDirectory.Text))
            {
                //Clean list from previous executions
                fileList = new List<FileToRename>();

                try
                {
                    var files = GetFiles(txtOriginDirectory.Text, chkSearchFilesRecursively.Checked, extensionFilters);

                    foreach (var item in files)
                    {
                        //Apply filter if exist
                        fileList.Add(new FileToRename(item));
                    }

                    //Refresh grids
                    LoadDataBinding_Files(chkSearchPatterns.Checked);
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //Need to refresh material theme...
                    ChangeTheme(switchViewMode.Checked);
                }
            }
        }

        private List<string> GetFiles(string initialDir, bool recursiveSearch, string[] extensionFilters)
        {
            //Get files in root directory
            List<string> files = null;

            if (extensionFilters != null)
            {
                files = extensionFilters.SelectMany(filter => Directory.GetFiles(initialDir, filter)).ToList();
            }
            else
            {
                files = Directory.GetFiles(initialDir).ToList();
            }

            if (recursiveSearch)
            {
                var dir = Directory.GetDirectories(initialDir);

                foreach (var subDir in dir)
                {
                    var subItems = extensionFilters.SelectMany(filter => Directory.GetFiles(subDir, filter)).ToList();
                    files.AddRange(subItems);
                }
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
                    bindingSourcePattern.DataSource = dict;
                    dgvPatterns.DataSource = bindingSourcePattern;

                    dgvPatterns.AllowUserToResizeColumns = true;
                    dgvPatterns.AllowUserToResizeRows = true;

                    dgvPatterns.Columns[0].HeaderText = "Word";
                    dgvPatterns.Columns[1].Visible = false;

                    dgvPatterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            string[] availableExtArray = new string[] { availableExt };

            //First validate filter
            if (!string.IsNullOrEmpty(txtExtensionFilter.Text) && !string.IsNullOrWhiteSpace(txtExtensionFilter.Text))
            {
                //Multifilter
                if (availableExt.IndexOf(";") != -1)
                {
                    availableExtArray = availableExt.Split(';');
                }
            }
            else
            {
                availableExtArray = null;
            }

            LoadFilesToDataGrid(availableExtArray);
        }

        private void PreviewIncrementalChanges()
        {
            if (txtIncremental.Text != string.Empty)
            {
                string titleToSet = txtIncremental.Text;

                for (int i = 0; i < fileList.Count; i++)
                {
                    fileList[i].SetNameAfterChanges(titleToSet.Replace("*", (i + 1).ToString()));
                }
            }

            LoadDataBinding_Files(false);
        }

        private void PreviewSearchAndReplaceChanges()
        {
            if (txtToSearch.Text != string.Empty)
            {
                foreach (var item in fileList)
                {
                    item.SetNameAfterChanges(item.Name.Replace(txtToSearch.Text, txtReplace.Text));
                }
            }

            LoadDataBinding_Files(false);
        }

    }
}
