using imdb_api_test.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    public class CallAbleOmdbAPI
    {
        public CallAbleOmdbAPI()
        {
            string path = @"imdb_api_test/Content";
            string fullPath = Path.GetFullPath(path);

            //Given File
            string resultPath = @"Result.txt";
            string fullPathResult = Path.GetFullPath(resultPath);

            IFileManager fileManager = new FileManager(fullPath, fullPathResult);
            ISortedDictionary sortedDictionary = new SortedDictionary(fileManager.ReadAllFiles());

            sortedDictionary.DeleteMySortedDictionary();
        }
    }
}
