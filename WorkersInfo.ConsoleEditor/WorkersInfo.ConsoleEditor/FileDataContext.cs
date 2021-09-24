using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WorkersInfo.ConsoleEditor
{
    [Serializable]
    public abstract class FileDataContext
    {

        [NonSerialized]
        private string fileName = "DataFile";
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        [NonSerialized]
        private string directory = "";


        
        public string Directory
        {
            get { return directory; }
            set
            {
                directory = value;
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }
            }
        }

        public string Path
        {
            get { return System.IO.Path.Combine(directory, FileName); }
        }
    }
}
