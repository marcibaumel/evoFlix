using System;
using System.Linq;
using System.Reflection;
using StorageModel.Products;

namespace StorageModel.Helpers
{
    public interface IClassHelperProxy
    {
        Type GetClass(IPayload payload);
    }

    public class ClassHelperProxy : IClassHelperProxy
    {

        public Type GetClass(IPayload payload)
        {
            return GetClassStatic(payload);
        }

        private static Type GetClassStatic(IPayload payload)
        {
            if (payload is IPerishable)
            {
                var results = from type in Assembly.GetExecutingAssembly().GetTypes()
                                where typeof(IPerishable).IsAssignableFrom(type)
                                select type;
                return results.FirstOrDefault(t => t.IsClass && t.IsInstanceOfType(payload));
            }
            if (payload is ICanned)
            {
                var results = from type in Assembly.GetExecutingAssembly().GetTypes()
                                where typeof(ICanned).IsAssignableFrom(type)
                                select type;
                return results.FirstOrDefault(t => t.IsClass && t.IsInstanceOfType(payload));
            }
            return null;
        }
        
    }
}
