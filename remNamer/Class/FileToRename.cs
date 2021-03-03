using System.IO;

namespace remNamer
{
    internal class FileToRename
    {
        public string Location { get; set; }
        public string Name { get; set; }
        public string NameWithoutExtension { get; set; }
        public string NameChanged { get; set; }
        public string Created { get; set; }
        public string Modified { get; set; }
        public FileInfo ExtendedInfo { get; set; }

        public FileToRename(string path)
        {
            this.Location = path;

            //Get name
            this.Name = this.NameChanged = Path.GetFileName(path);
            this.NameWithoutExtension = Path.GetFileNameWithoutExtension(path);
        }

        public void LoadFileInfo()
        {
            //Only load if is null
            if (ExtendedInfo == null)
            {
                ExtendedInfo = new FileInfo(this.Location);
            }
        }
    }
}
