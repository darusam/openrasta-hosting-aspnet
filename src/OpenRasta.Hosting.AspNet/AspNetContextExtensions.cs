using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OpenRasta.Hosting.AspNet
{
    public static class AspNetContextExtensions
    {
        public static object GetSessionVariable(this AspNetCommunicationContext context, int index)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
            if (context.NativeContext == null)
            {
                throw new MemberAccessException();
            }
            if (context.NativeContext.Session == null)
            {
                throw new NullReferenceException();
            }
            return context.NativeContext.Session[index];
        }
        public static T GetSessionVariable<T>(this AspNetCommunicationContext context, int index)
        {
            object toConvert = context.GetSessionVariable(index);
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
                catch (InvalidCastException ice)
                {
                    throw ice;
                }
                catch (Exception e)
                {
                    return default(T);
                }

            }
        }
        public static object GetSessionVariable(this AspNetCommunicationContext context, string name)
        {
            if (context == null || string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (context.NativeContext == null)
            {
                throw new MemberAccessException();
            }
            if (context.NativeContext.Session == null)
            {
                throw new NullReferenceException();
            }

            object toReturn = null;
            for (int i = 0; i < context.NativeContext.Session.Count; i++)
            {
                if (context.NativeContext.Session.Keys[i] == name)
                {
                    toReturn = context.NativeContext.Session[i];
                    break;
                }
            }
            return toReturn;
        }
        public static T GetSessionVariable<T>(this AspNetCommunicationContext context, string name)
        {
            object toConvert = context.GetSessionVariable(name);
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
                catch(InvalidCastException ice)
                {
                    throw ice;
                }
                catch(Exception e)
                {
                    return default(T);
                }

            }
        }

        public static void SetSessionVariable(this AspNetCommunicationContext context, int index, object value)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
            if (context.NativeContext == null)
            {
                throw new MemberAccessException();
            }
            if (context.NativeContext.Session == null)
            {
                throw new NullReferenceException();
            }
            context.NativeContext.Session[index] = value;
        }
        public static void SetSessionVariable(this AspNetCommunicationContext context, string name, object value)
        {
            if (context == null || string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (context.NativeContext == null)
            {
                throw new MemberAccessException();
            }
            if (context.NativeContext.Session == null)
            {
                throw new NullReferenceException();
            }
            context.NativeContext.Session[name] = value;
        }

        public static void AddSessionVariable(this AspNetCommunicationContext context, string name, object value)
        {
            if (context == null || string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (context.NativeContext == null)
            {
                throw new MemberAccessException();
            }
            if (context.NativeContext.Session == null)
            {
                throw new NullReferenceException();
            }
            context.NativeContext.Session.Add(name, value);
        }
    }
}
