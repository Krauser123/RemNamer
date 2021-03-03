using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace remNamer
{
    public partial class FrmMain : MaterialForm
    {
        const int LENGTH_CRITERIA = 3;

        private CommonOpenFileDialog cmdDialog = new CommonOpenFileDialog();
        private BindingSource bindingSource = new BindingSource();
        private List<FileToRename> fileList = new List<FileToRename>();
        private MaterialSkinManager materialSkinManager;

        public FrmMain()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            cmdDialog.IsFolderPicker = true;
            cmdDialog.EnsurePathExists = true;
        }

        private void LoadFilesToDataGrid()
        {
            if (txtOriginDirectory.Text != string.Empty)
            {
                try
                {
                    var files = Directory.GetFiles(txtOriginDirectory.Text);

                    foreach (var item in files)
                    {
                        fileList.Add(new FileToRename(item));
                    }

                    LoadDataBinding_Files();
                }
                catch (DirectoryNotFoundException e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDataBinding_Files()
        {
            bindingSource.DataSource = fileList;
            dgvFileInfo.DataSource = bindingSource;

            dgvFileInfo.AllowUserToResizeColumns = true;
            dgvFileInfo.AllowUserToResizeRows = true;

            //Resize columns in DataGridView
            FitDataGridColumns();

            SearchPatterns();
        }

        private void LoadDataBinding_Patterns(Dictionary<string, int> dict)
        {
            BindingSource bindingSourcePattern = new BindingSource();
            bindingSourcePattern.DataSource = dict;
            dgvPatterns.DataSource = bindingSourcePattern;

            dgvPatterns.AllowUserToResizeColumns = false;
            dgvPatterns.AllowUserToResizeRows = false;
        }

        private void FitDataGridColumns()
        {
            //Initialize counter
            int totalWidth = 0;

            //Auto Resize the columns to fit the data
            foreach (DataGridViewColumn column in dgvFileInfo.Columns)
            {
                dgvFileInfo.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                int widthCol = dgvFileInfo.Columns[column.Index].Width;

                dgvFileInfo.Columns[column.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvFileInfo.Columns[column.Index].Width = widthCol;
                totalWidth += widthCol;
            }
        }

        private void SearchPatterns()
        {
            if (fileList != null)
            {
                var exampleItems = GetRandomExampleItems();

                var namesWithoutExt = exampleItems.Select(o => o.NameWithoutExtension).ToList();
                var joinedNames = String.Join(" ", namesWithoutExt);

                var patterns = countPatterns(joinedNames);

                LoadDataBinding_Patterns(patterns);
            }

        }

        private Dictionary<string, int> countPatterns(string text)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            //Just cleaning up a bit
            text = text.Replace(",", "");
            //sInput = sInput.Replace(".", ""); //Just cleaning up a bit

            //Create an array of words
            string[] arr = text.Split(' ');

            foreach (string word in arr)
            {
                if (word.Length >= LENGTH_CRITERIA)
                {
                    if (dict.ContainsKey(word))
                    {
                        dict[word] = dict[word] + 1; //Increment the count
                    }
                    else
                    {
                        dict[word] = 1; //put it in the dictionary with a count 1
                    }
                }
            }

            //Remove matches equals to 1
            var itemsToRemove = dict.Where(o => o.Value == 1).ToList();
            foreach (var item in itemsToRemove)
            {
                dict.Remove(item.Key);
            }

            return dict;
        }

        private List<FileToRename> GetRandomExampleItems()
        {
            int numberOfItemsToPick = Convert.ToInt32(fileList.Count / 8);

            //Pick X random items
            Random rnd = new Random();
            var temp = new List<FileToRename>();
            for (int i = 0; i < numberOfItemsToPick; i++)
            {
                temp.Add(fileList[rnd.Next(0, fileList.Count)]);
            }


            return temp;
        }

        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {
            if (cmdDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                if (cmdDialog.FileName.StartsWith(Environment.GetEnvironmentVariable("windir")))
                {
                    MessageBox.Show("System files is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                txtOriginDirectory.Text = cmdDialog.FileName;

                LoadFilesToDataGrid();
            }
        }

        private void switchViewMode_CheckedChanged(object sender, EventArgs e)
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
    }
}
