using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    public class ServiceContract
    {
        /// <summary>
        /// 服务名
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 方法名
        /// </summary>
        public string MethodName { get; set; }
        /// <summary>
        /// 是否是泛型方法
        /// </summary>
        public bool IsGenericMethod { get; set; }
        /// <summary>
        /// 类型参数
        /// </summary>
        public Type[] GenericType { get; set; }
        /// <summary>
        /// 方法参数
        /// </summary>
        public Dictionary<string, string> Paras { get; set; }

    }
}
