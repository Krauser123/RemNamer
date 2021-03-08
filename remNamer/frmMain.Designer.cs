
namespace remNamer
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.dgvFileInfo = new System.Windows.Forms.DataGridView();
            this.dgvPatterns = new System.Windows.Forms.DataGridView();
            this.btnOpenFolder = new MaterialSkin.Controls.MaterialButton();
            this.chkSearchPatterns = new MaterialSkin.Controls.MaterialCheckbox();
            this.chkSearchFilesRecursively = new MaterialSkin.Controls.MaterialCheckbox();
            this.txtOriginDirectory = new MaterialSkin.Controls.MaterialTextBox();
            this.lblOriginDirectory = new MaterialSkin.Controls.MaterialLabel();
            this.lblPattern = new MaterialSkin.Controls.MaterialLabel();
            this.btnRename = new MaterialSkin.Controls.MaterialButton();
            this.switchViewMode = new MaterialSkin.Controls.MaterialSwitch();
            this.txtExtensionFilter = new MaterialSkin.Controls.MaterialTextBox();
            this.btnApplyFileFilter = new MaterialSkin.Controls.MaterialButton();
            this.lblFileFilters = new MaterialSkin.Controls.MaterialLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPgReplace = new System.Windows.Forms.TabPage();
            this.btnPreview = new MaterialSkin.Controls.MaterialButton();
            this.lblReplace = new MaterialSkin.Controls.MaterialLabel();
            this.lblTextToSearch = new MaterialSkin.Controls.MaterialLabel();
            this.txtReplace = new MaterialSkin.Controls.MaterialTextBox();
            this.txtToSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.tabPgIncremental = new System.Windows.Forms.TabPage();
            this.btnPreviewIncremental = new MaterialSkin.Controls.MaterialButton();
            this.lblTitleIncremental = new MaterialSkin.Controls.MaterialLabel();
            this.txtIncremental = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPgReplace.SuspendLayout();
            this.tabPgIncremental.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFileInfo
            // 
            this.dgvFileInfo.AllowUserToAddRows = false;
            this.dgvFileInfo.AllowUserToDeleteRows = false;
            this.dgvFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileInfo.Location = new System.Drawing.Point(4, 518);
            this.dgvFileInfo.Margin = new System.Windows.Forms.Padding(2);
            this.dgvFileInfo.Name = "dgvFileInfo";
            this.dgvFileInfo.ReadOnly = true;
            this.dgvFileInfo.RowHeadersWidth = 51;
            this.dgvFileInfo.RowTemplate.Height = 24;
            this.dgvFileInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileInfo.Size = new System.Drawing.Size(1070, 248);
            this.dgvFileInfo.TabIndex = 2;
            // 
            // dgvPatterns
            // 
            this.dgvPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatterns.Location = new System.Drawing.Point(4, 275);
            this.dgvPatterns.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPatterns.Name = "dgvPatterns";
            this.dgvPatterns.RowHeadersWidth = 51;
            this.dgvPatterns.RowTemplate.Height = 24;
            this.dgvPatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatterns.Size = new System.Drawing.Size(392, 236);
            this.dgvPatterns.TabIndex = 5;
            this.dgvPatterns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPatterns_CellClick);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.AutoSize = false;
            this.btnOpenFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpenFolder.Depth = 0;
            this.btnOpenFolder.DrawShadows = true;
            this.btnOpenFolder.HighEmphasis = true;
            this.btnOpenFolder.Icon = null;
            this.btnOpenFolder.Location = new System.Drawing.Point(791, 105);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOpenFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(115, 50);
            this.btnOpenFolder.TabIndex = 9;
            this.btnOpenFolder.Text = "Open folder";
            this.btnOpenFolder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnOpenFolder.UseAccentColor = false;
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // chkSearchPatterns
            // 
            this.chkSearchPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchPatterns.AutoSize = true;
            this.chkSearchPatterns.Checked = true;
            this.chkSearchPatterns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSearchPatterns.Depth = 0;
            this.chkSearchPatterns.Location = new System.Drawing.Point(457, 70);
            this.chkSearchPatterns.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchPatterns.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSearchPatterns.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSearchPatterns.Name = "chkSearchPatterns";
            this.chkSearchPatterns.Ripple = true;
            this.chkSearchPatterns.Size = new System.Drawing.Size(147, 37);
            this.chkSearchPatterns.TabIndex = 10;
            this.chkSearchPatterns.Text = "Search Patterns";
            this.chkSearchPatterns.UseVisualStyleBackColor = true;
            // 
            // chkSearchFilesRecursively
            // 
            this.chkSearchFilesRecursively.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSearchFilesRecursively.AutoSize = true;
            this.chkSearchFilesRecursively.Depth = 0;
            this.chkSearchFilesRecursively.Location = new System.Drawing.Point(617, 70);
            this.chkSearchFilesRecursively.Margin = new System.Windows.Forms.Padding(0);
            this.chkSearchFilesRecursively.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkSearchFilesRecursively.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkSearchFilesRecursively.Name = "chkSearchFilesRecursively";
            this.chkSearchFilesRecursively.Ripple = true;
            this.chkSearchFilesRecursively.Size = new System.Drawing.Size(167, 37);
            this.chkSearchFilesRecursively.TabIndex = 11;
            this.chkSearchFilesRecursively.Text = "Include Subfolders";
            this.chkSearchFilesRecursively.UseVisualStyleBackColor = true;
            // 
            // txtOriginDirectory
            // 
            this.txtOriginDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOriginDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOriginDirectory.Depth = 0;
            this.txtOriginDirectory.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtOriginDirectory.Location = new System.Drawing.Point(7, 105);
            this.txtOriginDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.txtOriginDirectory.MaxLength = 50;
            this.txtOriginDirectory.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOriginDirectory.Multiline = false;
            this.txtOriginDirectory.Name = "txtOriginDirectory";
            this.txtOriginDirectory.Size = new System.Drawing.Size(778, 50);
            this.txtOriginDirectory.TabIndex = 12;
            this.txtOriginDirectory.Text = "";
            // 
            // lblOriginDirectory
            // 
            this.lblOriginDirectory.AutoSize = true;
            this.lblOriginDirectory.Depth = 0;
            this.lblOriginDirectory.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOriginDirectory.Location = new System.Drawing.Point(4, 79);
            this.lblOriginDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOriginDirectory.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblOriginDirectory.Name = "lblOriginDirectory";
            this.lblOriginDirectory.Size = new System.Drawing.Size(110, 19);
            this.lblOriginDirectory.TabIndex = 13;
            this.lblOriginDirectory.Text = "Origin Directory";
            // 
            // lblPattern
            // 
            this.lblPattern.AutoSize = true;
            this.lblPattern.Depth = 0;
            this.lblPattern.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPattern.Location = new System.Drawing.Point(2, 254);
            this.lblPattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPattern.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPattern.Name = "lblPattern";
            this.lblPattern.Size = new System.Drawing.Size(106, 19);
            this.lblPattern.TabIndex = 14;
            this.lblPattern.Text = "Patterns found";
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.AutoSize = false;
            this.btnRename.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRename.Depth = 0;
            this.btnRename.DrawShadows = true;
            this.btnRename.HighEmphasis = true;
            this.btnRename.Icon = null;
            this.btnRename.Location = new System.Drawing.Point(791, 468);
            this.btnRename.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnRename.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(282, 43);
            this.btnRename.TabIndex = 15;
            this.btnRename.Text = "Rename";
            this.btnRename.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRename.UseAccentColor = false;
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.BtnRename_Click);
            // 
            // switchViewMode
            // 
            this.switchViewMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.switchViewMode.AutoSize = true;
            this.switchViewMode.Depth = 0;
            this.switchViewMode.Location = new System.Drawing.Point(931, 64);
            this.switchViewMode.Margin = new System.Windows.Forms.Padding(0);
            this.switchViewMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.switchViewMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.switchViewMode.Name = "switchViewMode";
            this.switchViewMode.Ripple = true;
            this.switchViewMode.Size = new System.Drawing.Size(135, 37);
            this.switchViewMode.TabIndex = 16;
            this.switchViewMode.Text = "Dark Mode";
            this.switchViewMode.UseVisualStyleBackColor = true;
            this.switchViewMode.CheckedChanged += new System.EventHandler(this.SwitchViewMode_CheckedChanged);
            // 
            // txtExtensionFilter
            // 
            this.txtExtensionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtensionFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExtensionFilter.Depth = 0;
            this.txtExtensionFilter.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtExtensionFilter.Hint = "*.pdf,*.png";
            this.txtExtensionFilter.Location = new System.Drawing.Point(7, 183);
            this.txtExtensionFilter.Margin = new System.Windows.Forms.Padding(2);
            this.txtExtensionFilter.MaxLength = 50;
            this.txtExtensionFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.txtExtensionFilter.Multiline = false;
            this.txtExtensionFilter.Name = "txtExtensionFilter";
            this.txtExtensionFilter.Size = new System.Drawing.Size(413, 50);
            this.txtExtensionFilter.TabIndex = 23;
            this.txtExtensionFilter.Text = "";
            // 
            // btnApplyFileFilter
            // 
            this.btnApplyFileFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyFileFilter.AutoSize = false;
            this.btnApplyFileFilter.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApplyFileFilter.Depth = 0;
            this.btnApplyFileFilter.DrawShadows = true;
            this.btnApplyFileFilter.HighEmphasis = true;
            this.btnApplyFileFilter.Icon = null;
            this.btnApplyFileFilter.Location = new System.Drawing.Point(425, 183);
            this.btnApplyFileFilter.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnApplyFileFilter.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnApplyFileFilter.Name = "btnApplyFileFilter";
            this.btnApplyFileFilter.Size = new System.Drawing.Size(97, 50);
            this.btnApplyFileFilter.TabIndex = 22;
            this.btnApplyFileFilter.Text = "Apply";
            this.btnApplyFileFilter.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApplyFileFilter.UseAccentColor = false;
            this.btnApplyFileFilter.UseVisualStyleBackColor = true;
            this.btnApplyFileFilter.Click += new System.EventHandler(this.BtnApplyFileFilter_Click);
            // 
            // lblFileFilters
            // 
            this.lblFileFilters.AutoSize = true;
            this.lblFileFilters.Depth = 0;
            this.lblFileFilters.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFileFilters.Location = new System.Drawing.Point(4, 161);
            this.lblFileFilters.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileFilters.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblFileFilters.Name = "lblFileFilters";
            this.lblFileFilters.Size = new System.Drawing.Size(109, 19);
            this.lblFileFilters.TabIndex = 24;
            this.lblFileFilters.Text = "Extension Filter";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPgReplace);
            this.tabControl1.Controls.Add(this.tabPgIncremental);
            this.tabControl1.Location = new System.Drawing.Point(402, 275);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(383, 236);
            this.tabControl1.TabIndex = 25;
            // 
            // tabPgReplace
            // 
            this.tabPgReplace.Controls.Add(this.btnPreview);
            this.tabPgReplace.Controls.Add(this.lblReplace);
            this.tabPgReplace.Controls.Add(this.lblTextToSearch);
            this.tabPgReplace.Controls.Add(this.txtReplace);
            this.tabPgReplace.Controls.Add(this.txtToSearch);
            this.tabPgReplace.Location = new System.Drawing.Point(4, 22);
            this.tabPgReplace.Name = "tabPgReplace";
            this.tabPgReplace.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgReplace.Size = new System.Drawing.Size(375, 210);
            this.tabPgReplace.TabIndex = 0;
            this.tabPgReplace.Text = "Replace";
            this.tabPgReplace.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.AutoSize = false;
            this.btnPreview.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreview.Depth = 0;
            this.btnPreview.DrawShadows = true;
            this.btnPreview.HighEmphasis = true;
            this.btnPreview.Icon = null;
            this.btnPreview.Location = new System.Drawing.Point(270, 118);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreview.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(98, 50);
            this.btnPreview.TabIndex = 26;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreview.UseAccentColor = false;
            this.btnPreview.UseVisualStyleBackColor = true;
            // 
            // lblReplace
            // 
            this.lblReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplace.AutoSize = true;
            this.lblReplace.Depth = 0;
            this.lblReplace.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblReplace.Location = new System.Drawing.Point(16, 96);
            this.lblReplace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReplace.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(91, 19);
            this.lblReplace.TabIndex = 25;
            this.lblReplace.Text = "Replace with";
            // 
            // lblTextToSearch
            // 
            this.lblTextToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextToSearch.AutoSize = true;
            this.lblTextToSearch.Depth = 0;
            this.lblTextToSearch.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTextToSearch.Location = new System.Drawing.Point(16, 13);
            this.lblTextToSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTextToSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTextToSearch.Name = "lblTextToSearch";
            this.lblTextToSearch.Size = new System.Drawing.Size(101, 19);
            this.lblTextToSearch.TabIndex = 24;
            this.lblTextToSearch.Text = "Text to search";
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReplace.Depth = 0;
            this.txtReplace.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtReplace.Hint = "Replace with...";
            this.txtReplace.Location = new System.Drawing.Point(19, 118);
            this.txtReplace.MaxLength = 50;
            this.txtReplace.MouseState = MaterialSkin.MouseState.OUT;
            this.txtReplace.Multiline = false;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(244, 50);
            this.txtReplace.TabIndex = 23;
            this.txtReplace.Text = "";
            // 
            // txtToSearch
            // 
            this.txtToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtToSearch.Depth = 0;
            this.txtToSearch.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtToSearch.Hint = "Find...";
            this.txtToSearch.Location = new System.Drawing.Point(19, 35);
            this.txtToSearch.MaxLength = 50;
            this.txtToSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtToSearch.Multiline = false;
            this.txtToSearch.Name = "txtToSearch";
            this.txtToSearch.Size = new System.Drawing.Size(244, 50);
            this.txtToSearch.TabIndex = 22;
            this.txtToSearch.Text = "";
            // 
            // tabPgIncremental
            // 
            this.tabPgIncremental.Controls.Add(this.btnPreviewIncremental);
            this.tabPgIncremental.Controls.Add(this.lblTitleIncremental);
            this.tabPgIncremental.Controls.Add(this.txtIncremental);
            this.tabPgIncremental.Location = new System.Drawing.Point(4, 22);
            this.tabPgIncremental.Name = "tabPgIncremental";
            this.tabPgIncremental.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgIncremental.Size = new System.Drawing.Size(375, 210);
            this.tabPgIncremental.TabIndex = 1;
            this.tabPgIncremental.Text = "Incremental";
            this.tabPgIncremental.UseVisualStyleBackColor = true;
            // 
            // btnPreviewIncremental
            // 
            this.btnPreviewIncremental.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreviewIncremental.AutoSize = false;
            this.btnPreviewIncremental.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPreviewIncremental.Depth = 0;
            this.btnPreviewIncremental.DrawShadows = true;
            this.btnPreviewIncremental.HighEmphasis = true;
            this.btnPreviewIncremental.Icon = null;
            this.btnPreviewIncremental.Location = new System.Drawing.Point(270, 37);
            this.btnPreviewIncremental.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPreviewIncremental.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreviewIncremental.Name = "btnPreviewIncremental";
            this.btnPreviewIncremental.Size = new System.Drawing.Size(98, 50);
            this.btnPreviewIncremental.TabIndex = 27;
            this.btnPreviewIncremental.Text = "Preview";
            this.btnPreviewIncremental.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreviewIncremental.UseAccentColor = false;
            this.btnPreviewIncremental.UseVisualStyleBackColor = true;
            this.btnPreviewIncremental.Click += new System.EventHandler(this.BtnPreviewIncremental_Click);
            // 
            // lblTitleIncremental
            // 
            this.lblTitleIncremental.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleIncremental.AutoSize = true;
            this.lblTitleIncremental.Depth = 0;
            this.lblTitleIncremental.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleIncremental.Location = new System.Drawing.Point(17, 15);
            this.lblTitleIncremental.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitleIncremental.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitleIncremental.Name = "lblTitleIncremental";
            this.lblTitleIncremental.Size = new System.Drawing.Size(290, 19);
            this.lblTitleIncremental.TabIndex = 26;
            this.lblTitleIncremental.Text = "Title (Char * will be replaced by numeric )";
            // 
            // txtIncremental
            // 
            this.txtIncremental.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncremental.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIncremental.Depth = 0;
            this.txtIncremental.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtIncremental.Hint = "FileTitle-*";
            this.txtIncremental.Location = new System.Drawing.Point(20, 37);
            this.txtIncremental.MaxLength = 50;
            this.txtIncremental.MouseState = MaterialSkin.MouseState.OUT;
            this.txtIncremental.Multiline = false;
            this.txtIncremental.Name = "txtIncremental";
            this.txtIncremental.Size = new System.Drawing.Size(243, 50);
            this.txtIncremental.TabIndex = 25;
            this.txtIncremental.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 769);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblFileFilters);
            this.Controls.Add(this.txtExtensionFilter);
            this.Controls.Add(this.btnApplyFileFilter);
            this.Controls.Add(this.switchViewMode);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.lblPattern);
            this.Controls.Add(this.lblOriginDirectory);
            this.Controls.Add(this.txtOriginDirectory);
            this.Controls.Add(this.chkSearchFilesRecursively);
            this.Controls.Add(this.chkSearchPatterns);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.dgvPatterns);
            this.Controls.Add(this.dgvFileInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "RemNamer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPgReplace.ResumeLayout(false);
            this.tabPgReplace.PerformLayout();
            this.tabPgIncremental.ResumeLayout(false);
            this.tabPgIncremental.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFileInfo;
        private System.Windows.Forms.DataGridView dgvPatterns;
        private MaterialSkin.Controls.MaterialButton btnOpenFolder;
        private MaterialSkin.Controls.MaterialCheckbox chkSearchPatterns;
        private MaterialSkin.Controls.MaterialCheckbox chkSearchFilesRecursively;
        private MaterialSkin.Controls.MaterialTextBox txtOriginDirectory;
        private MaterialSkin.Controls.MaterialLabel lblOriginDirectory;
        private MaterialSkin.Controls.MaterialLabel lblPattern;
        private MaterialSkin.Controls.MaterialButton btnRename;
        private MaterialSkin.Controls.MaterialSwitch switchViewMode;
        private MaterialSkin.Controls.MaterialTextBox txtExtensionFilter;
        private MaterialSkin.Controls.MaterialButton btnApplyFileFilter;
        private MaterialSkin.Controls.MaterialLabel lblFileFilters;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPgReplace;
        private System.Windows.Forms.TabPage tabPgIncremental;
        private MaterialSkin.Controls.MaterialButton btnPreview;
        private MaterialSkin.Controls.MaterialLabel lblReplace;
        private MaterialSkin.Controls.MaterialLabel lblTextToSearch;
        private MaterialSkin.Controls.MaterialTextBox txtReplace;
        private MaterialSkin.Controls.MaterialTextBox txtToSearch;
        private MaterialSkin.Controls.MaterialButton btnPreviewIncremental;
        private MaterialSkin.Controls.MaterialLabel lblTitleIncremental;
        private MaterialSkin.Controls.MaterialTextBox txtIncremental;
    }
}

