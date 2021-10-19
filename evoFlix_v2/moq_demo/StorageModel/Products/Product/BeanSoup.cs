using System;

namespace StorageModel.Products.Product
{
    public class BeanSoup : ICanned
    {
        public TimeSpan ExpireDuration { get; set; }

        public uint Quantity { get; set; }
    }
}
