using System;

namespace StorageModel.Products.Product
{
    public class Banana : IPerishable
    {
        public Banana()
        {
            myStoreTime = DateTime.Now;
        }

        public uint Quantity { get; set; }

        public bool IsExpired
        {
            get { return isExpired; }
            set
            {
                isExpired = value;
                if (IsExpired)
                {
                    Expired.Invoke(this, new EventArgs());
                }
            }
        }

        public TimeSpan ExpireDuration { get; set; }

        public DateTime StoreTime
        {
            get
            {               
                return myStoreTime;
            }
        }

        readonly DateTime myStoreTime;

        public event EventHandler Expired;

        private bool isExpired;
    }
}
