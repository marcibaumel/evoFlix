using System;
using System.Reflection;

namespace MoqDemo_uTest.Helpers
{
    /// <summary>
    /// A Helper class to make simplier to use reflection in BE tests.
    /// </summary> 
    public static class ReflectionHelper
    {
        /// <summary>
        /// Sets an instance field via reflection.
        /// </summary>
        /// <param name="target_in">The object whose field is in interest.</param>
        /// <param name="field_in">Name(s) of the field(s), e.g. "myF1.myF2.myF3"</param>
        /// <param name="value_in">Value of the field.</param>
        /// <returns></returns>
        public static void SetField(object target_in, string field_in, object value_in)
        {
            string[] fields = field_in.Split('.');

            if (fields.Length > 1)
            {
                //get parent instance field
                target_in = GetField(target_in, string.Join(".", fields, 0, fields.Length - 1));
            }

            //set instance field
            target_in.GetType().InvokeMember(
                fields[fields.Length - 1],
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetField,
                null, target_in, new object[] { value_in });
        }

        /// <summary>
        /// Gets an instance field via reflection.
        /// </summary>
        /// <param name="target_in">The object whose field is in interest.</param>
        /// <param name="field_in">Name(s) of the field(s), e.g. "myF1.myF2.myF3"</param>
        /// <returns></returns>
        public static object GetField(object target_in, string field_in)
        {
            string[] fields = field_in.Split('.');

            if (fields.Length < 2)
            {
                //get instance field
                return target_in.GetType().InvokeMember(
                    fields[0],
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField,
                    null, target_in, null);
            }
            else
            {
                //get first instance field
                object o = GetField(target_in, fields[0]);
                //get its instance field
                return GetField(o, string.Join(".", fields, 1, fields.Length - 1));
            }
        }

        /// <summary>
        /// Gets a static field via reflection.
        /// </summary>
        /// <param name="class_in"></param>
        /// <param name="field_in"></param>
        /// <returns></returns>
        public static object GetStaticField(Type class_in, string field_in)
        {
            return class_in.InvokeMember(field_in,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField,
                null, null, null);
        }

        /// <summary>
        /// Sets a static field via reflection.
        /// </summary>
        /// <param name="type_in">The class whose field is in interest.</param>
        /// <param name="field_in">Name(s) of the field(s), e.g. "myF1.myF2.myF3"</param>
        /// <param name="value_in">Value of the field.</param>
        /// <returns></returns>
        public static void SetStaticField(Type type_in, string field_in, object value_in)
        {
            string[] fields = field_in.Split('.');

            if (fields.Length < 2)
            {
                //set static field
                type_in.InvokeMember(
                  field_in,
                  BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.SetField,
                  null, null, new object[] { value_in });
            }
            else
            {
                //get static field
                object o = GetField(type_in, string.Join(".", fields, 0, fields.Length - 1));
                //set instance field
                SetField(o, fields[fields.Length - 1], value_in);
            }
        }

        /// <summary>
        /// Gets a static field via reflection.
        /// </summary>
        /// <param name="type_in">The class whose field is in interest.</param>
        /// <param name="field_in">Name(s) of the field(s), e.g. "myF1.myF2.myF3"</param>
        /// <returns></returns>
        public static object GetField(Type type_in, string field_in)
        {
            string[] fields = field_in.Split('.');

            //get static field
            object o = type_in.InvokeMember(
                fields[0],
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField,
                null, null, null);

            //get optional instance field
            if (fields.Length > 1)
            {
                return GetField(o, string.Join(".", fields, 1, fields.Length - 1));
            }

            return o;
        }

        /// <summary>
        /// Sets a property via reflection.
        /// </summary>
        /// <param name="target_in">The object whose property is in interest.</param>
        /// <param name="property_in">Name of the property. Name of the property, can be the last "myF1.myF2.myF3"</param>
        /// <param name="value_in">Value of the property.</param>
        /// <returns></returns>
        public static void SetProperty(object target_in, string property_in, object value_in)
        {
            SetProperty(null, target_in, property_in, value_in);
        }

        /// <summary>
        /// Sets a property via reflection.
        /// </summary>
        /// <param name="targettype_in">Optional: base class of the target object for private property</param>
        /// <param name="target_in">The object whose property is in interest.</param>
        /// <param name="property_in">Name of the property. It can countain a path of field names like "myF1.myF2.myF3.MyProp"</param>
        /// <param name="value_in">Value of the property.</param>
        /// <returns></returns>
        public static void SetProperty(Type targettype_in, object target_in, string property_in, object value_in)
        {
            if (property_in.Contains("."))
            {
                //Call SetProperty with one field less
                string[] fields = property_in.Split('.');
                //get first instance field
                object o = GetField(target_in, fields[0]);
                //get its instance field
                SetProperty(targettype_in, o, string.Join(".", fields, 1, fields.Length - 1), value_in);
            }
            else
            {
                (targettype_in ?? target_in.GetType()).InvokeMember(
                    property_in,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null, target_in, new object[] { value_in });
            }
        }

        /// <summary>
        /// Gets a property via reflection.
        /// </summary>
        /// <param name="target_in">The object whose property is in interest.</param>
        /// <param name="property_in">Name of the property. Name of the property, can be the last "myF1.myF2.myF3"</param>
        /// <returns></returns>
        public static object GetProperty(object target_in, string property_in)
        {
            if (property_in.Contains("."))
            {
                string[] fields = property_in.Split('.');
                //get first instance field
                object o = GetField(target_in, fields[0]);
                //get its instance field
                return GetProperty(o, string.Join(".", fields, 1, fields.Length - 1));

            }
            else
            {
                return target_in.GetType().InvokeMember(
                    property_in,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty,
                    null, target_in, null);
            }
        }

        /// <summary>
        /// Gets a static property via reflection.
        /// </summary>
        /// <param name="class_in">The cloass whose property is in interest.</param>
        /// <param name="property_in">Name of the property</param>
        /// <returns></returns>
        public static object GetStaticProperty(Type class_in, string property_in)
        {
            return class_in.InvokeMember(
                    property_in,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty,
                    null, null, null);
        }

        /// <summary>
        /// Invokes a method via reflection.
        /// </summary>
        /// <param name="target_in">The object whose method is to be called.</param>
        /// <param name="method_in">Name of the method</param>
        /// <param name="params_in">The arguments of the method</param>
        /// <returns>Return value of the called method.</returns>
        public static object InvokeMethod(object target_in, string method_in, params object[] params_in)
        {
            try
            {
                return target_in.GetType().InvokeMember(method_in,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
                null, target_in, params_in);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Invokes a generic method via reflection.
        /// </summary>
        /// <param name="target_in">The object whose method is to be called.</param>
        /// <param name="method_in">Name of the method</param>
        /// <param name="genericType_in">Type of the generic method</param>
        /// <param name="params_in">The arguments of the method</param>
        /// <returns>Return value of the called method.</returns>
        public static object InvokeGenericMethod(object target_in, string method_in, Type genericType_in, params object[] params_in)
        {
            try
            {
                return target_in.GetType().GetMethod(method_in,
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod).
                MakeGenericMethod(genericType_in).Invoke(target_in, params_in);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        /// <summary>
        /// Invokes a static method via reflection.
        /// </summary>
        /// <param name="class_in">The type of the class whose method is to be called.</param>
        /// <param name="method_in">Name of the method</param>
        /// <param name="params_in">The arguments of the method</param>        
        /// <returns>Return value of the called method.</returns>
        public static object InvokeStaticMethod(Type class_in, string method_in, params object[] params_in)
        {
            object[] pout;
            return InvokeStaticMethod(class_in, method_in, out pout, params_in);
        }

        /// <summary>
        /// Invokes a static method via reflection.
        /// </summary>
        /// <param name="class_in">The type of the class whose method is to be called.</param>
        /// <param name="method_in">Name of the method</param>
        /// <param name="params_in">The arguments of the method</param>
        /// <param name="params_out">The arguments of the method to support out/ref arguments</param>
        /// <returns>Return value of the called method.</returns>
        public static object InvokeStaticMethod(Type class_in, string method_in, out object[] params_out, params object[] params_in)
        {
            try
            {
                params_out = params_in;
                return class_in.InvokeMember(
                    method_in,
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                    null, null, params_in);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }
    }
}