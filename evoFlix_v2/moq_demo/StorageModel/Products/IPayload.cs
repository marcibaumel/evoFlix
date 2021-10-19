using System;

namespace StorageModel.Products
{
    public interface IPayload 
    {
        TimeSpan ExpireDuration { get; set; }

        uint Quantity { get; }
    }
}
