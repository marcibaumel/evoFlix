using System;
using System.Threading;
using StorageModel;
using StorageModel.Helpers;
using StorageModel.Implementations;
using StorageModel.Products.Product;
using System.Timers;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageDumper messageDumper = new MessageDumper();
            IClassHelperProxy classHelperProxy = new ClassHelperProxy();
            IStoreManager sm = new StoreManager(
                new CannedStoreage(50, messageDumper, classHelperProxy),
                new PerishableStorage(40, messageDumper, classHelperProxy),
                new Dispatcher(),
                classHelperProxy);
            var banana = new Banana { Quantity = 10 , IsExpired = false };
            var soup = new BeanSoup { ExpireDuration = new TimeSpan(10, 0, 0, 0), Quantity = 10 };

            sm.RequestReceived(new Request(RequestType.Store, soup));
            sm.RequestReceived(new Request(RequestType.Dispatch, banana));
            sm.RequestReceived(new Request(RequestType.Store, banana));
            sm.RequestReceived(new Request(RequestType.Query, banana));

            Thread.Sleep(1000);
            banana.IsExpired = true;

            Console.ReadKey();
        }
    }
}
