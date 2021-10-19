using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageModel.Products.Product
{
    public class CannedMeat : ICanned
    {
        public TimeSpan ExpireDuration { get ; set ; }
        public uint Quantity { get; set; }
    }
}
