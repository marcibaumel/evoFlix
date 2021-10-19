using System;
using StorageModel.Helpers;
using StorageModel.Products;

namespace StorageModel.Implementations
{
    /// <summary>
    /// 
    /// </summary>
    public class Dispatcher : IDispatcher
    {
        public Dispatcher()
        {
            myMessageDumper = new MessageDumper();
            ClassHelperProxy = new ClassHelperProxy();
        }

        public void ProcessDispatchRequest(IPayload payload)
        {            
            if (payload == null)
            {
                throw new ArgumentNullException("payload", "No payload to dispatch!");
            }

            var implementing = ClassHelperProxy.GetClass(payload);
            object[] args;

            if (payload is IPerishable && !(payload as IPerishable).IsExpired)
            {
                args = new object[] { implementing }; 
                MessageDumper.DumpMessage(StringResources.DISPATCHER_PERISHED, args);
                return;
            }

            args = new object[] { payload.Quantity, implementing.Name };            
            MessageDumper.DumpMessage(StringResources.DISPATCHER_DISPATCHED, args);
        }

        public IMessageDumper MessageDumper
        {
            get { return myMessageDumper; }
        }

        public IClassHelperProxy ClassHelperProxy { get; private set; }

        private readonly IMessageDumper myMessageDumper;
    }
}
