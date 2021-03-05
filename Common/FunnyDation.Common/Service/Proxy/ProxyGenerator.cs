using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    /// <summary>
    /// 代理生成器
    /// </summary>
    public class ProxyGenerator : DispatchProxy
    {
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            throw new NotImplementedException();
        }
    }





}
