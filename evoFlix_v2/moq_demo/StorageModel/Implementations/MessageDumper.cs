using System;

namespace StorageModel.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageDumper : IMessageDumper
    {
        public void DumpMessage(string message, object[] args)
        {           
            Console.WriteLine(string.Format(message, args));
        }

        public void DumpMessage(string message)
        {
            Console.WriteLine(string.Format(message));
        }
    }
}
