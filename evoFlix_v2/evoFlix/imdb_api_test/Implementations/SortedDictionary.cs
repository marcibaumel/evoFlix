using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test.Implementations
{
    public class SortedDictionary : ISortedDictionary
    {
        private SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();

        public SortedDictionary(SortedDictionary<string, string> sortedDictionary)
        {
            this.sortedDictionary = sortedDictionary;
        }

        public SortedDictionary<string, string> getDictionary()
        {
            return sortedDictionary;
        }

        public void AddNewItem(string Title, string Year)
        {
            try
            {
                sortedDictionary.Add(Title, Year);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with this Key already exists.");
            }
        }

        public void DeleteMySortedDictionary()
        {
            sortedDictionary.Clear();
        }

        public int CountMySortedDictionary()
        {
            return sortedDictionary.Count();
        }

        public bool ExistingItem(string Title)
        {
            return sortedDictionary.ContainsKey(Title);
        }

        public void GetKeyByValue(string Year)
        {

            foreach (KeyValuePair<string, string> kvp in sortedDictionary)
            {
                if (kvp.Value == Year)
                {
                    Console.WriteLine(kvp.Key);
                }
            }
        }

        public bool YearInDictionary(string Year)
        {
            bool ExistingItem = sortedDictionary.ContainsValue(Year);
            if (!ExistingItem)
            {
                return false;
            }
            return true;
        }

    }
}