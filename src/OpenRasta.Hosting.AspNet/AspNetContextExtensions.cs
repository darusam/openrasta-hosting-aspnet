using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRasta.Hosting.AspNet
{
    public static class AspNetContextExtensions
    {
        public static object GetSessionVariable(this AspNetCommunicationContext context, int index)
        {
            return context.NativeContext.Session[index];
        }
        public static T GetSessionVariable<T>(this AspNetCommunicationContext context, int index)
        {
            object toConvert = context.NativeContext.Session[index];
            if (toConvert == null)
            {
                return default(T);
            }
            else
            {
                try
                {
                    T toReturn = (T)toConvert;
                    return toReturn;
                }
                catch (Exception e)
                {
                    return default(T);
                }

            }
        }
        public static object GetSessionVariable(this AspNetCommunicationContext context, string name)
        {
            return context.NativeContext.Session[name];
        }
        public static T GetSessionVariable<T>(this AspNetCommunicationContext context, string name)
        {
            object toConvert = context.NativeContext.Session[name];
            if(toConvert == null)
            {
                return default(T);
            }
            else
            {
                try
                {
                    T toReturn = (T)toConvert;
                    return toReturn;
                }
                catch(Exception e)
                {
                    return default(T);
                }

            }
        }

        public static void SetSessionVariable(this AspNetCommunicationContext context, int index, object value)
        {
            context.NativeContext.Session[index] = value;
        }
        public static void SetSessionVariable(this AspNetCommunicationContext context, string name, object value)
        {
            context.NativeContext.Session[name] = value;
        }
    }
}
