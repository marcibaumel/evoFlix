using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel.Implementations
{
    /// <summary>
    /// Manager for the storeage.
    /// </summary>
    public class StoreManager : IStoreManager
    {
        /// <summary>
        /// Initializes a new instance of StoreManager
        /// </summary>
        public StoreManager(IStorage<ICanned> cStorage, IStorage<IPerishable> pStorage, IDispatcher dispatcher, IClassHelperProxy classHelperProxy)
        {
            CannedStorage = cStorage;
            PerishableStorage = pStorage;
            Dispatcher = dispatcher;
            ClassHelperProxy = classHelperProxy;
        }

        /// <summary>
        /// Processes a dispatch or store request 
        /// </summary>
        /// <param name="request"></param>
        public void RequestReceived(IRequest request)
        {
            switch (request.Type)
            {
                case RequestType.Dispatch :
                    ProcessDispatchRequest(request);
                    break;
                case RequestType.Store :
                    StorePayload(request);
                    break;
                case RequestType.Query:
                    QueryProduct(request);
                    break;
                default :
                    break;
            }
        }

        /// <summary>
        /// Gets the IDispatcher to dispatch payloads 
        /// </summary>
        public IDispatcher Dispatcher { get; private set; }   
  
        /// <summary>
        /// Gets the storeage for Canned payloads
        /// </summary>
        public IStorage<ICanned> CannedStorage { get; private set; }

        /// <summary>
        /// Gets the storeage for Perishable payloads
        /// </summary>
        public IStorage<IPerishable> PerishableStorage { get; private set; }

        public IClassHelperProxy ClassHelperProxy { get; private set; }

        private void ProcessDispatchRequest(IRequest request)
        {
            var payload = request.Payload;
            var implementing = ClassHelperProxy.GetClass(payload);

            if (payload is IPerishable)
            {
                var result = PerishableStorage.WithDraw(implementing, payload.Quantity);
                if (result != null)
                {
                    Dispatcher.ProcessDispatchRequest(result);
                }
                else
                {
                    Dispatcher.MessageDumper.DumpMessage(StringResources.DISPATCHER_ERROR_NOTONSTOCK, new []{ implementing.Name });
                }
                return;
            }
            if (payload is ICanned)
            {
                var result = PerishableStorage.WithDraw(implementing, payload.Quantity);
                if (result != null)
                {
                    Dispatcher.ProcessDispatchRequest(result);
                }
                else
                {
                    Dispatcher.MessageDumper.DumpMessage(StringResources.DISPATCHER_ERROR_NOTONSTOCK, new []{ implementing.Name });
                }
            }
        }

        private void StorePayload(IRequest request)
        {
            var payload = request.Payload;

            if (payload is IPerishable)
            {
                PerishableStorage.Store(payload as IPerishable);
                return;
            }
            if (payload is ICanned)
            {
                CannedStorage.Store(payload as ICanned);
            }
        }

        private void QueryProduct(IRequest request)
        {
            var payload = request.Payload;
            var implementing = ClassHelperProxy.GetClass(payload);

            if (payload is IPerishable)
            {
                PerishableStorage.ReportQuery(implementing);
                return;
            }
            if (payload is ICanned)
            {
                CannedStorage.ReportQuery(implementing);
            }
        }
    }
}
