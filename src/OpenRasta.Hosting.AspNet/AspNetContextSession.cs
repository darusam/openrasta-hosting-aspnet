using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using OpenRasta.Web;

namespace OpenRasta.Hosting.AspNet
{
    public class AspNetContextSession : IContextSession
    {
        public int Timeout
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Session.Timeout;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session.Timeout = value;
                }
                else
                {
                    //do nothing
                    return;
                }
            }
        }

        public object this[string key]
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Session[key];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Session[key] = value;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
