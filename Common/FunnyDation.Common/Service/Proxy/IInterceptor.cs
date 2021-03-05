using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    /// <summary>
    /// 拦截器接口
    /// </summary>
    public interface IInterceptor
    {

        object InterceptAsync(MethodInfo targetMethod, object[] parameters);

    }
}
