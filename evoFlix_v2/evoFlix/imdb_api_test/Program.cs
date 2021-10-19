using imdb_api_test.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdb_api_test
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * Absolute reach
             */
            //IFileManager fileManager = new FileManager(@"D:\WORK\EGYETEM\4 FÉLÉV\Repos\CsharpBeadndó\LogicalDictionary\O09CTQ_Csharp\LogicalDictionary\Films\", @"D:\WORK\EGYETEM\4 FÉLÉV\Repos\CsharpBeadndó\LogicalDictionary\O09CTQ_Csharp\LogicalDictionary\Result.txt");


            /**
             * Relative reach
             */

            //Folder
            string path = @"imdb_api_test/Content";
            string fullPath = Path.GetFullPath(path);

            //Given File
            string resultPath = @"Result.txt";
            string fullPathResult = Path.GetFullPath(resultPath);

            IFileManager fileManager = new FileManager(fullPath, fullPathResult);

            Console.WriteLine("Founded movies on your given directory: \n");

            /// <summary>
            /// With this method the application search all items in the Films folder and then
            /// split two halfs (Key: title, Value: year) and put in to new SortedDictionary.
            /// </summary>
            ISortedDictionary sortedDictionary = new SortedDictionary(fileManager.ReadAllFiles());

            Console.WriteLine($"\nIn number:{sortedDictionary.CountMySortedDictionary()}");

            /// <summary>
            /// With this method we can manually add a new item to the SortedDictionary.
            /// </summary>
            string newKey = "Mank";
            string newValue = "2020";
            Console.WriteLine($"\nManually given movie: {newKey}\n");

            sortedDictionary.AddNewItem(newKey, newValue);
            fileManager.SaveOmdbData(sortedDictionary.getDictionary());

            /// <summary>
            /// With this method we can see there is a value wich equals with the given value. 
            /// </summary>
            Console.WriteLine("\nThere is a movie which released in 1970?");
            Console.WriteLine("The answer is: " + sortedDictionary.YearInDictionary("1970"));

            /// <summary>
            /// With this method we can see there is a key wich equals with the given value.  
            /// </summary>
            Console.WriteLine("\nThere is a movie which called Mank?");
            Console.WriteLine("The answer is: " + sortedDictionary.ExistingItem("Mank"));

            /// <summary>
            /// With this method, we can list out all of the keys wich values equals with the given value
            /// </summary>
            Console.WriteLine("\nThis movies are made in 2020:");
            sortedDictionary.GetKeyByValue("2020");

            /// <summary>
            /// With this method we can delete every item from our SortedDictionary
            /// </summary>
            Console.WriteLine("\nDelete every item from the SortedDictionary, new value in number: ");

            sortedDictionary.DeleteMySortedDictionary();
            Console.WriteLine(sortedDictionary.CountMySortedDictionary());

            /// <summary>
            /// Finish the application
            /// </summary>
            Console.WriteLine("\nPress enter (END)");
            Console.ReadLine();


        }
    }
}

