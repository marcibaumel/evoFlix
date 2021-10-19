using evoFlix.Models.Content;
using evoFlix.Services.FilmService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test.Implementations
{
    public class FileManager : IFileManager
    {
        private string Folder { get; set; }
        private string GivenFile { get; set; }
        private IOmdbAPI omdbAPI;
        private IFilmSerializable filmSerializable;
        

        public FileManager(string folder, string givenFile)
        {
            Folder = folder;
            GivenFile = givenFile;
        }

        public FileManager(string folder, string givenFile, IOmdbAPI omdbAPIGiven, IFilmSerializable filmSerializableGiven)
        {
            Folder = folder;
            GivenFile = givenFile;
            omdbAPI = omdbAPIGiven;
            filmSerializable = filmSerializableGiven;
        }

        public DateTime LastModified()
        {
            DateTime dt = File.GetLastWriteTime(GivenFile);
            return dt;
        }

        public SortedDictionary<string, string> ReadAllFiles()
        {
            SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
            string[] stringSeperators = new string[] { "bin" };
            string[] folderName = Folder.Split(stringSeperators, StringSplitOptions.None);
            string convertFolder = folderName[0]+ "\\Content";
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

        public void SetMainDirectory(string RelativePath)
        {
            this.GivenFile = RelativePath;
        }
        
        public void SaveOmdbData(SortedDictionary<string, string> Dictionary)
        {
            StreamWriter sw = new StreamWriter(GivenFile);
            
            foreach (KeyValuePair<string, string> pair in Dictionary)
            {
                Console.WriteLine("Title: {0} and Year: {1} has been found", pair.Key, pair.Value);
               
                omdbAPI = new OmdbAPI(pair.Key, pair.Value);
                FilmModel result = omdbAPI.JsonConvertByResult(omdbAPI.GetOmdbData());
                
                filmSerializable = new FilmSerializable(result);
                FilmTableModel filmTableModel = filmSerializable.ConvertFilmToDB();

               

                try
                {
                    sw.Write(result.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            sw.Close();
        }

       
    }
}
