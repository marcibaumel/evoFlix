using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDispatcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payload"></param>
        void ProcessDispatchRequest(IPayload payload);

        /// <summary>
        /// 
        /// </summary>
        IMessageDumper MessageDumper { get; }

        IClassHelperProxy ClassHelperProxy { get; }
    }
}
