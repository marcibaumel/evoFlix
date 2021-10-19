using StorageModel.Products;

namespace StorageModel.Implementations
{
    /// <summary>
    /// Implementation of IRequest interface
    /// </summary>
    public class Request : IRequest
    {
        public Request(RequestType type, IPayload payload)
        {
            Type = type;
            Payload = payload;
        }

        public RequestType Type
        {
            get; 
            private set; 
        }

        public IPayload Payload
        {
            get;
            private set; 
        }
    }
}
