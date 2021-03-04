using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;
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

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            //Windows not allow select folder without this
            cmdDialog.ValidateNames = false;
            cmdDialog.CheckFileExists = false;
            cmdDialog.CheckPathExists = true;
            cmdDialog.FileName = "Folder Selection";
        }

        private void LoadFilesToDataGrid()
        {
            if (txtOriginDirectory.Text != string.Empty)
            {
                //Clean list from previous executions
                fileList = new List<FileToRename>();

                try
                {
                    var files = Directory.GetFiles(txtOriginDirectory.Text);

                    foreach (var item in files)
                    {
                        fileList.Add(new FileToRename(item));
                    }

                    LoadDataBinding_Files(chkSearchPatterns.Checked);
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataBinding_Files(bool searchPatterns)
        {
            bindingSource.DataSource = fileList;
            dgvFileInfo.DataSource = bindingSource;

            dgvFileInfo.AllowUserToResizeColumns = true;
            dgvFileInfo.AllowUserToResizeRows = true;

            //Resize columns in DataGridView
            FitDataGridColumns(ref dgvFileInfo);

            if (searchPatterns)
            {
                var dict = patternFinder.SearchPatterns(fileList);
                LoadDataBinding_Patterns(dict);
            }
        }

        private void LoadDataBinding_Patterns(Dictionary<string, int> dict)
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

        private void FitDataGridColumns(ref DataGridView dgv)
        {
            //Initialize counter
            int totalWidth = 0;

            //Auto Resize the columns to fit the data
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                dgv.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol = dgv.Columns[column.Index].Width;

                dgv.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgv.Columns[column.Index].Width = widthCol;
                totalWidth += widthCol;
            }
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

                LoadFilesToDataGrid();
            }
        }

        private void SwitchViewMode_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            else
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
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
            if (txtToSearch.Text != string.Empty)
            {
                foreach (var item in fileList)
                {
                    item.NameAfterChanges = item.Name.Replace(txtToSearch.Text, txtReplace.Text);
                }
            }
            LoadDataBinding_Files(false);
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            //Block form
            this.Enabled = false;

            //Change files
            foreach (var item in this.fileList)
            {
                item.RenameFile();
            }

            //Reload files
            LoadFilesToDataGrid();

            //Unblock form
            this.Enabled = true;
        }
    }
}
