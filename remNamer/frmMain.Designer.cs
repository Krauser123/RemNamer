
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
            this.txtToSearch = new MaterialSkin.Controls.MaterialTextBox();
            this.txtReplace = new MaterialSkin.Controls.MaterialTextBox();
            this.lblTextToSearch = new MaterialSkin.Controls.MaterialLabel();
            this.lblReplace = new MaterialSkin.Controls.MaterialLabel();
            this.btnPreview = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).BeginInit();
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
            this.dgvFileInfo.Location = new System.Drawing.Point(5, 571);
            this.dgvFileInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvFileInfo.Name = "dgvFileInfo";
            this.dgvFileInfo.ReadOnly = true;
            this.dgvFileInfo.RowHeadersWidth = 51;
            this.dgvFileInfo.RowTemplate.Height = 24;
            this.dgvFileInfo.Size = new System.Drawing.Size(1249, 286);
            this.dgvFileInfo.TabIndex = 2;
            // 
            // dgvPatterns
            // 
            this.dgvPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatterns.Location = new System.Drawing.Point(5, 233);
            this.dgvPatterns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPatterns.Name = "dgvPatterns";
            this.dgvPatterns.RowHeadersWidth = 51;
            this.dgvPatterns.RowTemplate.Height = 24;
            this.dgvPatterns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatterns.Size = new System.Drawing.Size(345, 318);
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
            this.btnOpenFolder.Location = new System.Drawing.Point(877, 129);
            this.btnOpenFolder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpenFolder.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(193, 50);
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
            this.chkSearchPatterns.Location = new System.Drawing.Point(481, 86);
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
            this.chkSearchFilesRecursively.Location = new System.Drawing.Point(701, 86);
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
            this.txtOriginDirectory.Location = new System.Drawing.Point(9, 129);
            this.txtOriginDirectory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginDirectory.MaxLength = 50;
            this.txtOriginDirectory.MouseState = MaterialSkin.MouseState.OUT;
            this.txtOriginDirectory.Multiline = false;
            this.txtOriginDirectory.Name = "txtOriginDirectory";
            this.txtOriginDirectory.Size = new System.Drawing.Size(859, 50);
            this.txtOriginDirectory.TabIndex = 12;
            this.txtOriginDirectory.Text = "";
            // 
            // lblOriginDirectory
            // 
            this.lblOriginDirectory.AutoSize = true;
            this.lblOriginDirectory.Depth = 0;
            this.lblOriginDirectory.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOriginDirectory.Location = new System.Drawing.Point(5, 97);
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
            this.lblPattern.Location = new System.Drawing.Point(3, 207);
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
            this.btnRename.Location = new System.Drawing.Point(877, 514);
            this.btnRename.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRename.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(376, 53);
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
            this.switchViewMode.Location = new System.Drawing.Point(1108, 79);
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
            // txtToSearch
            // 
            this.txtToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtToSearch.Depth = 0;
            this.txtToSearch.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtToSearch.Location = new System.Drawing.Point(369, 260);
            this.txtToSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtToSearch.MaxLength = 50;
            this.txtToSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.txtToSearch.Multiline = false;
            this.txtToSearch.Name = "txtToSearch";
            this.txtToSearch.Size = new System.Drawing.Size(499, 50);
            this.txtToSearch.TabIndex = 17;
            this.txtToSearch.Text = "";
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReplace.Depth = 0;
            this.txtReplace.Font = new System.Drawing.Font("Roboto", 12F);
            this.txtReplace.Location = new System.Drawing.Point(369, 363);
            this.txtReplace.Margin = new System.Windows.Forms.Padding(4);
            this.txtReplace.MaxLength = 50;
            this.txtReplace.MouseState = MaterialSkin.MouseState.OUT;
            this.txtReplace.Multiline = false;
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(499, 50);
            this.txtReplace.TabIndex = 18;
            this.txtReplace.Text = "";
            // 
            // lblTextToSearch
            // 
            this.lblTextToSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTextToSearch.AutoSize = true;
            this.lblTextToSearch.Depth = 0;
            this.lblTextToSearch.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTextToSearch.Location = new System.Drawing.Point(365, 233);
            this.lblTextToSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTextToSearch.Name = "lblTextToSearch";
            this.lblTextToSearch.Size = new System.Drawing.Size(101, 19);
            this.lblTextToSearch.TabIndex = 19;
            this.lblTextToSearch.Text = "Text to search";
            // 
            // lblReplace
            // 
            this.lblReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReplace.AutoSize = true;
            this.lblReplace.Depth = 0;
            this.lblReplace.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblReplace.Location = new System.Drawing.Point(365, 336);
            this.lblReplace.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(57, 19);
            this.lblReplace.TabIndex = 20;
            this.lblReplace.Text = "Replace";
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
            this.btnPreview.Location = new System.Drawing.Point(877, 363);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnPreview.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(200, 50);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnPreview.UseAccentColor = false;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 862);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.lblReplace);
            this.Controls.Add(this.lblTextToSearch);
            this.Controls.Add(this.txtReplace);
            this.Controls.Add(this.txtToSearch);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1200, 862);
            this.Name = "FrmMain";
            this.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Text = "RemNamer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatterns)).EndInit();
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
        private MaterialSkin.Controls.MaterialTextBox txtToSearch;
        private MaterialSkin.Controls.MaterialTextBox txtReplace;
        private MaterialSkin.Controls.MaterialLabel lblTextToSearch;
        private MaterialSkin.Controls.MaterialLabel lblReplace;
        private MaterialSkin.Controls.MaterialButton btnPreview;
    }
}

