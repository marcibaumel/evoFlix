using System;
using System.Collections.Generic;
using System.Linq;
using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class PerishableStorage : IStorage<IPerishable>
    {
        /// <summary>
        /// Creates a new instance of IStorage for ICanned
        /// </summary>
        /// <param name="capacity">The capacity of the storeage</param>
        /// <param name="messageDumper"></param>
        /// <param name="classHelperProxy"></param>
        public PerishableStorage(uint capacity, IMessageDumper messageDumper, IClassHelperProxy classHelperProxy)
        {
            myCapacity = capacity;
            StoredQuantity = 0;
            Products = new List<IPerishable>();

            myMessageDumper = messageDumper;
            ClassHelperProxy = classHelperProxy;
        }

        /// <summary>
        /// Stores the payload if there's enough capacity, and returns true, else returns false
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Store(IPerishable product)
        {
            uint left = Capacity - StoredQuantity;
            object[] args;
            var implementingClass = ClassHelperProxy.GetClass(product);

            if (left < product.Quantity)
            {
                args = new object[] { StringResources.PERISHABLE_STOREAGE, product.Quantity, implementingClass.Name };
                myMessageDumper.DumpMessage(StringResources.STOREAGE_STORED, args);
                return false;
            }

            StoredQuantity += product.Quantity;
            left = Capacity - StoredQuantity;
            args = new object[] { StringResources.PERISHABLE_STOREAGE, product.Quantity, implementingClass.Name, left };
            myMessageDumper.DumpMessage(StringResources.STOREAGE_STORED, args);
            Products.Add(product);

            product.Expired += ProductOnExpired;

            return true;                    
        }

        private void ProductOnExpired(object sender, EventArgs eventArgs)
        {
            var product = sender as IPerishable;
            if (product == null || product.IsExpired.Equals(true))
            {
                return;
            }

            if (Products.Contains(product))
            {
                Products.Remove(product);
                var args = new object[] { product.Quantity, product.GetType().Name };
                myMessageDumper.DumpMessage(StringResources.PERISHABLE_STOREAGE_EXPIRED, args );
            }
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
            if (result !=null && result.StoreTime + result.ExpireDuration > DateTime.Now)
            {
                result.IsExpired = true;
            }

            Products.Remove(result);
            result.Expired -= ProductOnExpired;
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
            uint left = Capacity - StoredQuantity;

            matchingProducts.ForEach(x => sum += (int)x.Quantity);

            var args = new object[] { StringResources.PERISHABLE_STOREAGE, sum, t.Name, left };
            MessageDumper.DumpMessage(StringResources.STORE_REPORT_QUANTITY, args);
        }

        /// <summary>
        /// Gets the list of stored payloads.
        /// </summary>
        public IList<IPerishable> Products { get; private set; }

        /// <summary>
        /// Gets the storage capacity 
        /// </summary>
        public uint Capacity
        {
            get { return myCapacity; }
        }

        /// <summary>
        /// Gets the total quantity of the stored payloads.
        /// Can not exceed the capacity.
        /// </summary>
        public uint StoredQuantity { get; private set; }

        /// <summary>
        /// gets the message dumper
        /// </summary>
        public IMessageDumper MessageDumper
        {
            get { return myMessageDumper; }
        }

        public IClassHelperProxy ClassHelperProxy { get; private set; }

        private readonly uint myCapacity;
        private readonly IMessageDumper myMessageDumper;
    }
}
