using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{

    /// <summary>
    /// 不要求授权
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class NotAuthorizeAttribute : Attribute
    { 
        public NotAuthorizeAttribute()
        { 
        
        }


    }
}
