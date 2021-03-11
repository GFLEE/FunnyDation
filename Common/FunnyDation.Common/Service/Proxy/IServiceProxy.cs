using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    /// <summary>
    /// 代理生成接口
    /// </summary>
    public interface IServiceProxy
    {
        T Create<T>() where T : class, new();

        object Create(Type type);
    }
}
