using StorageModel.Products;

namespace StorageModel
{
    /// <summary>
    /// Interface for storeage management requests
    /// </summary>
    public interface IRequest
    {
        RequestType Type { get; }

        IPayload Payload { get; }
    }

    /// <summary>
    /// Types of storeage management request
    /// </summary>
    public enum RequestType
    {
        Dispatch,
        Store,
        Query
    }
}
