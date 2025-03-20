using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace remNamer
{
    internal class FileToRename
    {
        //These properties do not appears in DataGrids
        [Browsable(false)]
        public string NameWithoutExtension { get; }
        [Browsable(false)]
        private string Location { get; set; }        
        [Browsable(false)]
        private FileInfo ExtendedInfo { get; set; }
        [Browsable(false)]
        private string LocationAfterChanges { get; set; }
        [Browsable(false)]
        private string _nameAfterChanges { get; set; }
        [Browsable(false)]
        private string FileExtension { get; set; }

        //Public Properties
        public string Name { get; }
        public string NameAfterChanges { get { return this._nameAfterChanges; } }
        public string Created { get; }
        public string Modified { get; }
        public string FileSize { get; }

        public FileToRename(string path)
        {
            //Set location
            this.Location = this.LocationAfterChanges = path;

            //Get name
            this.Name = _nameAfterChanges = Path.GetFileName(path);            
            this.NameWithoutExtension = GetFileNameWithoutExtension(path);
            
            //Get extension
            this.FileExtension = GetFileExtension(path);

            //Load extended properties
            ExtendedInfo = new FileInfo(this.Location);
            Created = ExtendedInfo.CreationTime.ToShortDateString();
            Modified = ExtendedInfo.LastWriteTime.ToShortDateString();
            FileSize = GetFormattedFileSize();
        }

        public void RenameFile()
        {
            try
            {
                this.LocationAfterChanges = this.LocationAfterChanges.Replace(this.Name, this.NameAfterChanges);

                if (this.Location != this.LocationAfterChanges)
                {
                    File.Move(this.Location, this.LocationAfterChanges);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void SetNameAfterChanges(string nameToSet)
        {
            //If the name doesn't have an extension we need to append it, also if the extension is too long
            if (!Path.HasExtension(nameToSet) || Path.GetExtension(nameToSet).Length > 5)
            {
                nameToSet += this.FileExtension;
            }

            _nameAfterChanges = nameToSet;
        }

        private string GetFormattedFileSize()
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
                length /= 1024;
            }

            return Math.Round(Convert.ToDouble(length), 2);
        }

        private string GetFileNameWithoutExtension(string path)
        {
            string fileName = Path.GetFileName(path);
            int lastDotIndex = fileName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                return fileName;
            }
            return fileName.Substring(0, lastDotIndex);
        }

        private string GetFileExtension(string path)
        {
            string fileName = Path.GetFileName(path);
            int lastDotIndex = fileName.LastIndexOf('.');
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }
            return fileName.Substring(lastDotIndex);
        }

    }
}
