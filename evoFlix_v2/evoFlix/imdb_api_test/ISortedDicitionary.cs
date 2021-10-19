using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    public interface ISortedDictionary
    {
        SortedDictionary<string, string> getDictionary();
        void AddNewItem(string Title, string Year);

        void DeleteMySortedDictionary();

        void GetKeyByValue(string Title);

        bool ExistingItem(string Title);

        int CountMySortedDictionary();

        bool YearInDictionary(string Year);
    }
}
