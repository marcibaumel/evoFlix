using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel
{
    public interface IStoreManager
    {
        /// <summary>
        /// Processes a dispatch or store request 
        /// </summary>
        /// <param name="request"></param>
        void RequestReceived(IRequest request);

        /// <summary>
        /// Gets the IDispatcher to dispatch payloads 
        /// </summary>
        IDispatcher Dispatcher { get; }

        /// <summary>
        /// Gets the storeage for Canned payloads
        /// </summary>
        IStorage<ICanned> CannedStorage { get;  }

        /// <summary>
        /// Gets the storeage for Perishable payloads
        /// </summary>
        IStorage<IPerishable> PerishableStorage { get;  }

        /// <summary>
        /// 
        /// </summary>
        IClassHelperProxy ClassHelperProxy { get; }
    }
}
