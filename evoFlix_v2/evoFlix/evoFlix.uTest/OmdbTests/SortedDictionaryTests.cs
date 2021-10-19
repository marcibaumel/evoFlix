using imdb_api_test.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.uTest.OmdbTests
{
    [TestFixture]
    public class SortedDictionaryTests
    {
        [SetUp]
        public void TestCaseSetup()
        {
          sortedDictionary = new SortedDictionary<string, string>();
          SortedDictionary mySortedDictionary = new SortedDictionary(sortedDictionary);
        }

        [Test]
        public void getDictionaryTest_GetMySortedDictionary_ReturnSortedDictionary()
        {    
            SortedDictionary mySortedDictionary = new SortedDictionary(sortedDictionary);
            Assert.IsTrue(mySortedDictionary.getDictionary().Equals(sortedDictionary)); 
        }

        [TestCase("Minari","2020")]
        public void addNewItem_GiveNewItemToSortedDictionary_ReturnThatItem(string Title, string Year)
        {
            SortedDictionary mySortedDictionary = new SortedDictionary(sortedDictionary);
           
            mySortedDictionary.DeleteMySortedDictionary();
            Assert.IsFalse(mySortedDictionary.CountMySortedDictionary() != 0);

            mySortedDictionary.AddNewItem(Title, Year);
            Assert.IsTrue(mySortedDictionary.CountMySortedDictionary() == 1);
            Assert.IsTrue(mySortedDictionary.ExistingItem(Title));
            Assert.IsTrue(mySortedDictionary.YearInDictionary(Year));

        }

        private SortedDictionary<string, string> sortedDictionary;
        private SortedDictionary mySortedDictionary;
    }
}
