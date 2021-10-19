using System;

namespace StorageModel.Products
{
    /// <summary>
    /// Represents perishable product payloads
    /// </summary>
    public interface IPerishable : IPayload
    {
        bool IsExpired { get; set; }

        DateTime StoreTime { get; }

        event EventHandler Expired;
    }
}
