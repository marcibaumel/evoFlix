using System;
using System.Collections.Generic;
using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel
{
    public interface IStorage<T>
    {
        /// <summary>
        /// Stores the payload if there's enough capacity, and returns true, else returns false
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        bool Store(T payload);

        /// <summary>
        /// Withdraws a payload from the Product collection and removes that.
        /// Finds the first payload that matches the specified type
        /// </summary>
        /// <param name="t"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        IPayload WithDraw(Type t, uint quantity);

        /// <summary>
        /// Reports the quantity stored of the given type
        /// </summary>
        /// <param name="t"></param>
        void ReportQuery(Type t);

        /// <summary>
        /// Gets the capacity of the storeage
        /// </summary>
        uint Capacity { get; }

        /// <summary>
        /// Gets the total quantity of the stored payloads.
        /// Can not exceed the capacity.
        /// </summary>
        uint StoredQuantity { get; }

        /// <summary>
        /// Gets the message dumper.
        /// </summary>
        IMessageDumper MessageDumper { get; }

        /// <summary>
        /// Gets the list of stored payloads.
        /// </summary>
        IList<T> Products { get; }

        IClassHelperProxy ClassHelperProxy { get; }
    }
}
