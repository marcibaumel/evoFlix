using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    public interface IFileManager
    {
        void SetMainDirectory(string RelativePath);
        DateTime LastModified();
        void SaveOmdbData(SortedDictionary<string, string> Dictionary);
        SortedDictionary<string, string> ReadAllFiles();
    }
}
