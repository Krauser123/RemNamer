using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace remNamer
{
    internal class FileToRename
    {
        [Browsable(false)]
        public string Location { get; set; }
        [Browsable(false)]
        public string NameWithoutExtension { get; set; }
        [Browsable(false)]
        public FileInfo ExtendedInfo { get; set; }
        [Browsable(false)]
        public string LocationAfterChanges { get; set; }

        public string Name { get; set; }        
        public string NameAfterChanges { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public string FileSize { get; set; }

        public FileToRename(string path)
        {
            this.Location = this.LocationAfterChanges = path;

            //Get name
            this.Name = this.NameAfterChanges = Path.GetFileName(path);
            this.NameWithoutExtension = Path.GetFileNameWithoutExtension(path);

            LoadFileInfo();
        }

        public void LoadFileInfo()
        {
            //Only load if is null
            if (ExtendedInfo == null)
            {
                ExtendedInfo = new FileInfo(this.Location);
                Created = ExtendedInfo.CreationTime.ToShortDateString();
                Modified = ExtendedInfo.LastWriteTime.ToShortDateString();
                FileSize = GetFileSize();
            }
        }

        private string GetFileSize()
        {
            long length = ExtendedInfo.Length;

            if (length < Math.Pow(1024, 1)) { return length + " B"; }
            if (length < Math.Pow(1024, 2)) { return DivideSize(length, 1) + " KB"; }
            if (length < Math.Pow(1024, 3)) { return DivideSize(length, 2) + " MB"; }
            if (length < Math.Pow(1024, 4)) { return DivideSize(length, 3) + " GB"; }

            return length + " TB";
        }

        private double DivideSize(double length, int unitsToDivide = 0)
        {
            for (int i = 0; i < unitsToDivide; i++)
            {
                length = length / 1024.0;
            }

            return Math.Round(Convert.ToDouble(length), 2);
        }

        public void RenameFile()
        {
            try
            {
                this.LocationAfterChanges = this.LocationAfterChanges.Replace(this.Name, this.NameAfterChanges);
                File.Move(this.Location, this.LocationAfterChanges);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
