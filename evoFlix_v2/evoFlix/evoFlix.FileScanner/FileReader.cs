using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.FileScanner
{
    public class FileReader
    {
        private string Folder { get; set; }
        

        public FileReader()
        {
            string path = @"imdb_api_test/Content";
            string fullPath = Path.GetFullPath(path);

            Folder = fullPath;
        }

        public SortedDictionary<string, string> ReadAllFiles()
        {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            string[] stringSeperators = new string[] { "bin" };
            string[] folderName = Folder.Split(stringSeperators, StringSplitOptions.None);
            string convertFolder = folderName[0] + "\\Content";
            Folder = convertFolder;

            string[] files = Directory.GetFiles(Folder);

            foreach (string file in files)
            {
                string contents = Path.GetFileNameWithoutExtension(file);
                Console.WriteLine(contents);

                string[] items = contents.Split(' ');
                foreach (string item in items)
                {
                    string[] keyValue = item.Split('-');
                    sortedDictionary.Add(keyValue[0], keyValue[1]);
                }

            }
            return sortedDictionary;

        }
    }
}
