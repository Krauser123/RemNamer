using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using remNamer.Class;

namespace remNamer
{
    public partial class FrmMain : MaterialForm
    {
        private readonly Color HIGHLIGHTCOLOR = Color.Violet;

        private OpenFileDialog OpenFileDialog = new OpenFileDialog();
        private List<FileToRename> FileList = new List<FileToRename>();
        private MaterialSkinManager MaterialSkinManager;
        private PatternFinder PatternFinder = new PatternFinder();
        private BindingSource BindingSourceDfvFiles = new BindingSource();

        public FrmMain()
        {
            InitializeComponent();

            SetupMaterialSkin();
            SetupOpenFileDialog();
            SetupDataGridViews();
        }

        /// <summary>
        /// Material skin setup
        /// </summary>
        private void SetupMaterialSkin()
        {
            MaterialSkinManager = MaterialSkinManager.Instance;
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.DeepOrange300, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        /// <summary>
        /// Setup OpenFileDialog to open folders
        /// </summary>
        private void SetupOpenFileDialog()
        {
            OpenFileDialog.ValidateNames = false;
            OpenFileDialog.CheckFileExists = false;
            OpenFileDialog.CheckPathExists = true;
            OpenFileDialog.FileName = "Folder Selection";
        }

        /// <summary>
        /// Resize columns in DataGridViews
        /// </summary>
        private void SetupDataGridViews()
        {
            dgvFileInfo.AllowUserToResizeColumns = true;
            dgvFileInfo.AllowUserToResizeRows = true;
            dgvFileInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPatterns.AllowUserToResizeColumns = true;
            dgvPatterns.AllowUserToResizeRows = true;
            dgvPatterns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        #region Controls - Events

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolder();
        }

        private void SwitchViewMode_CheckedChanged(object sender, EventArgs e)
        {
            MaterialSwitch switchView = (MaterialSwitch)sender;
            ChangeTheme(switchView.Checked);
        }

        private void DgvPatterns_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvPatterns_CellClickCopy(sender, e);
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            RenameFiles(false);
        }

        private void BtnPreviewIncremental_Click(object sender, EventArgs e)
        {
            RenameFiles(false);
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            RenameFiles(true);
        }

        private void BtnApplyFileFilter_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtExtensionFilter.Text) && !String.IsNullOrWhiteSpace(txtExtensionFilter.Text))
            {
                ApplyExtensionFilter();
            }
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

        #endregion

        #region Controls - Methods

        private void LoadDataBindingDfvFiles(bool searchPatterns)
        {
            // Assign list to BindingSource.
            BindingSourceDfvFiles.DataSource = FileList;
            dgvFileInfo.DataSource = BindingSourceDfvFiles;


            // Adjust columns width
            SetColumnWidthsInDfvFiles();

            // Highlight rows with changes
            ApplyHighLightToRowWithChanges();

            if (searchPatterns)
            {
                var patternsDictionary = PatternFinder.SearchPatterns(FileList);
                LoadDataBindingDgvPatterns(patternsDictionary);
            }

            //Need to refresh material theme
            ChangeTheme(switchViewMode.Checked);
        }

        private void ApplyHighLightToRowWithChanges()
        {
            foreach (DataGridViewRow row in dgvFileInfo.Rows)
            {
                var fileToRename = row.DataBoundItem as FileToRename;
                if (fileToRename.Name != fileToRename.NameAfterChanges)
                {
                    row.DefaultCellStyle.BackColor = HIGHLIGHTCOLOR;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void SetColumnWidthsInDfvFiles()
        {
            int totalWidth = dgvFileInfo.Width;
            dgvFileInfo.Columns[0].Width = (int)(totalWidth * 0.35);
            dgvFileInfo.Columns[1].Width = (int)(totalWidth * 0.35);
            dgvFileInfo.Columns[2].Width = (int)(totalWidth * 0.10);
            dgvFileInfo.Columns[3].Width = (int)(totalWidth * 0.10);
            dgvFileInfo.Columns[4].Width = (int)(totalWidth * 0.10);
        }

        private void LoadFilesToDataGrid(string[] extensionFilters)
        {
            if (txtOriginDirectory.Text != string.Empty && !Path.HasExtension(txtOriginDirectory.Text))
            {
                //Clean list from previous executions
                //FileList = new List<FileToRename>();

                try
                {
                    var files = Helper.GetFiles(txtOriginDirectory.Text, chkSearchFilesRecursively.Checked, extensionFilters);

                    foreach (var item in files)
                    {
                        //Apply filter if exist
                        FileList.Add(new FileToRename(item));
                    }

                    //Refresh grids
                    LoadDataBindingDfvFiles(chkSearchPatterns.Checked);
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Load patterns in dgvPatterns
        /// </summary>
        /// <param name="patterns">Patterns to load</param>
        private void LoadDataBindingDgvPatterns(Dictionary<string, int> patterns)
        {
            try
            {
                if (patterns.Values.Count > 0)
                {
                    var bindingSourcePattern = new BindingSource();
                    patterns = patterns.OrderBy(o => o.Key).ToDictionary(x => x.Key, x => x.Value);
                    bindingSourcePattern.DataSource = patterns;
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

        #endregion

        /// <summary>
        /// Rename files in disk, this operation cannot be undone
        /// </summary>
        /// <param name="saveInDisk">set to false to preview changes</param>
        private void RenameFiles(bool saveInDisk)
        {
            //Check if we need search with RegExp
            string textToSearch = PreviewSearchAndReplaceWithRegExp();

            //Be sure that collections are updated
            if (tabCtrlSearchTypes.SelectedIndex == 0)
            {
                PreviewSearchAndReplace(textToSearch);
            }
            else
            {
                PreviewIncremental(textToSearch);
            }

            //Block form
            this.Enabled = false;

            if (saveInDisk)
            {
                //Change files using properties
                foreach (var item in this.FileList)
                {
                    item.RenameFile();
                }
            }

            //Reload files from disk
            ApplyExtensionFilter();

            //Unblock form
            this.Enabled = true;
        }

        /// <summary>
        /// Change themes between metro light and dark
        /// </summary>
        /// <param name="isDarkTheme"></param>
        private void ChangeTheme(bool isDarkTheme)
        {
            var gridForeColor = isDarkTheme ? Color.White : Color.Black;
            var backColor = isDarkTheme ? Color.DarkGray : Color.White;
            var themeToSet = isDarkTheme ? MaterialSkinManager.Themes.DARK : MaterialSkinManager.Themes.LIGHT;

            //dgv not works well with dark mode so we need to change it manually
            dgvFileInfo.ForeColor = gridForeColor;
            dgvPatterns.ForeColor = gridForeColor;
            MaterialSkinManager.Theme = themeToSet;

            foreach (DataGridViewRow row in dgvFileInfo.Rows)
            {
                if (row.DefaultCellStyle.BackColor != HIGHLIGHTCOLOR)
                {
                    row.DefaultCellStyle.BackColor = backColor;
                }
            }

            foreach (DataGridViewRow row in dgvPatterns.Rows)
            {
                row.DefaultCellStyle.BackColor = backColor;
            }
        }

        /// <summary>
        /// Apply extension filter set by user on dataGridView
        /// </summary>
        private void ApplyExtensionFilter()
        {
            //Get filters
            string availableExt = txtExtensionFilter.Text.Trim();
            string[] availableExtensions = null;

            //First validate filter
            if (!string.IsNullOrEmpty(txtExtensionFilter.Text)
                && !string.IsNullOrWhiteSpace(txtExtensionFilter.Text)
                && availableExt.IndexOf(";") != -1)
            {
                //Multifilter                
                availableExtensions = availableExt.Split(';');
            }

            //Refresh dataGridView
            LoadFilesToDataGrid(availableExtensions);
        }

        private void PreviewIncremental(string textToSearch)
        {
            if (textToSearch != string.Empty)
            {
                for (int i = 0; i < FileList.Count; i++)
                {
                    string newName = textToSearch.Replace("*", (i + 1).ToString());

                    //Replace incremental
                    FileList[i].SetNameAfterChanges(newName);
                }
            }
        }

        private void PreviewSearchAndReplace(string textToSearch)
        {
            if (textToSearch != string.Empty)
            {
                foreach (var item in FileList)
                {
                    //We need to use name without extension because maybe you want to replace a dot
                    string newName = item.NameWithoutExtension.Replace(textToSearch, txtReplace.Text);

                    //Update properties
                    item.SetNameAfterChanges(newName);
                }
            }
        }

        private string PreviewSearchAndReplaceWithRegExp()
        {
            string textInSelectedTextBox;

            if (tabCtrlSearchTypes.SelectedIndex == 0)
            {
                textInSelectedTextBox = txtToSearch.Text;
            }
            else
            {
                textInSelectedTextBox = txtIncremental.Text;
            }

            //Set RegExp
            var regBrackets = new Regex(@"\[(.*?)\]");
            var regParenthesis = new Regex(@"\(([^\)]+)\)");

            foreach (var item in FileList)
            {
                //If we not found the pattern we keep the original name
                var newItemName = regBrackets.Replace(item.NameWithoutExtension, txtReplace.Text);
                newItemName = regParenthesis.Replace(newItemName, txtReplace.Text);

                //Update properties
                item.SetNameAfterChanges(newItemName);
            }

            //Remove %Any% from next searches
            var txtReplaceWithoutRegExp = textInSelectedTextBox.Replace(PatternFinder.TextForAnyInBrackets, "");
            txtReplaceWithoutRegExp = txtReplaceWithoutRegExp.Replace(PatternFinder.TextForAnyInParenthesis, "");

            return txtReplaceWithoutRegExp;
        }

        /// <summary>
        /// Handle enable state for Rename button
        /// </summary>
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

        private void OpenFolder()
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
                OpenFileDialog.FileName = "Folder Selection";
                ApplyExtensionFilter();
            }
        }

        private void DgvPatterns_CellClickCopy(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && dgvPatterns.CurrentCell != null && dgvPatterns.CurrentCell.Value != null)
            {
                string preSpace = "";
                if (txtToSearch.Text != "")
                {
                    preSpace = " ";
                }

                if (tabCtrlSearchTypes.SelectedIndex == 0)
                {
                    txtToSearch.AppendText(preSpace + dgvPatterns.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    txtIncremental.AppendText(preSpace + dgvPatterns.CurrentRow.Cells[0].Value.ToString());
                }
            }
        }
    }
}
