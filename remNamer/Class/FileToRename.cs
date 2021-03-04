using System.ComponentModel;
using System.IO;

namespace remNamer
{
    internal class FileToRename
    {
        [Browsable(false)]
        public string Location { get; set; }
        public string Name { get; set; }

        [Browsable(false)]
        public string NameWithoutExtension { get; set; }
        public string NameAfterChanges { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }

        [Browsable(false)]
        public FileInfo ExtendedInfo { get; set; }

        public FileToRename(string path)
        {
            this.Location = path;

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
            }
        }
    }
}
