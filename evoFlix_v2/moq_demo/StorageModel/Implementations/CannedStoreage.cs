using System;
using System.Collections.Generic;
using System.Linq;
using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel.Implementations
{
    /// <summary>
    /// Implementation of IStoreage for Canned payloads
    /// </summary>
    public class CannedStoreage : IStorage<ICanned>
    {
        /// <summary>
        /// Creates a new instance of IStorage for ICanned
        /// </summary>
        /// <param name="capacity">The capacity of the storeage</param>
        /// <param name="messageDumper"></param>
        /// <param name="classHelperProxy"></param>
        public CannedStoreage(uint capacity, IMessageDumper messageDumper, IClassHelperProxy classHelperProxy)
        {
            myCapacity = capacity;
            StoredQuantity = 0;
            Products = new List<ICanned>();

            ClassHelperProxy = classHelperProxy;
            MessageDumper = messageDumper; 
        }

        /// <summary>
        /// Stores the payload if there's enough capacity, and returns true, else returns false
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Store(ICanned product)
        {
            uint left = Capacity - StoredQuantity;
            object[] args;
            var implementingClass = ClassHelperProxy.GetClass(product);

            if (left < product.Quantity)
            {
                args = new object[] { StringResources.CANNED_STOREAGE, product.Quantity, implementingClass.Name };
                MessageDumper.DumpMessage(StringResources.STOREAGE_ERROR_CANNOT_STORE, args);
                return false;
            }

            Products.Add(product);
            StoredQuantity += product.Quantity;

            left = Capacity - StoredQuantity;
            args = new object[] { StringResources.CANNED_STOREAGE, product.Quantity, implementingClass.Name, left };
            MessageDumper.DumpMessage(StringResources.STOREAGE_STORED, args);
            return true;                    
        }

        /// <summary>
        /// Withdraws a payload from the Product collection and removes that.
        /// Finds the first payload that matches the specified type
        /// </summary>
        /// <param name="t"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public IPayload WithDraw(Type t, uint quantity) 
        {
            var matchingProducts = Products.Where(t.IsInstanceOfType).ToList();

            if (!matchingProducts.Any(x => x.Quantity >= quantity))
            {
                return null;
            }

            var result = matchingProducts.FirstOrDefault(x => x.Quantity >= quantity);
            Products.Remove(result);
            return result;
        }

        /// <summary>
        /// Reports the quantity stored of the given type
        /// </summary>
        /// <param name="t"></param>
        public void ReportQuery(Type t)
        {
            var matchingProducts = Products.Where(t.IsInstanceOfType).ToList();
            int sum = 0;

            matchingProducts.ForEach(x => sum += (int)x.Quantity);

            var args = new object[] { StringResources.CANNED_STOREAGE, sum, t.Name };
            MessageDumper.DumpMessage(StringResources.STORE_REPORT_QUANTITY, args);
        }



        /// <summary>
        /// Gets the storage capacity 
        /// </summary>
        public uint Capacity
        {
            get { return myCapacity; }
        }

        public IClassHelperProxy ClassHelperProxy { get; private set; }

        /// <summary>
        /// Gets the total quantity of the stored payloads.
        /// Can not exceed the capacity.
        /// </summary>
        public uint StoredQuantity { get; private set; }

        /// <summary>
        /// gets the message dumper
        /// </summary>
        public IMessageDumper MessageDumper { get; private set; }

        /// <summary>
        /// Gets the list of stored payloads.
        /// </summary>
        public IList<ICanned> Products { get; private set; }

        private readonly uint myCapacity;
    }
}
