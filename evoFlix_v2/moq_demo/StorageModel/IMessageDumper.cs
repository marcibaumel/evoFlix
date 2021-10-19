
namespace StorageModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageDumper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void DumpMessage(string message, object[] args);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void DumpMessage(string message);
    }
}
