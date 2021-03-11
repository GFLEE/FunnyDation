using FunnyDation.Common.Context;
using FunnyDation.Common.Service.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    /// <summary>
    /// 代理生成器
    /// </summary>
    public class ProxyGenerator : DispatchProxy
    {

        private IInterceptor interceptor { get; set; }

        /// <summary>
        /// 创建代理
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="interceptor"></param>
        /// <returns></returns>
        public static object Create(Type targetType, IInterceptor interceptor)
        {
            object proxy = GetProxy(targetType);
            ((ProxyGenerator)proxy).CreateInstance(interceptor);

            return proxy;
        }

        /// <summary>
        /// 获取Proxy
        /// </summary>
        /// <param name="targetType"></param>
        /// <returns></returns>
        private static object GetProxy(Type targetType)
        {
            var callExp = Expression.Call(typeof(DispatchProxy), nameof(DispatchProxy.Create), new[] {
                targetType,typeof(ProxyGenerator)
            });

            return Expression.Lambda<Func<object>>(callExp).Compile();
        }

        private void CreateInstance(IInterceptor intercr)
        {
            interceptor = intercr;
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="targetMethod"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {

            return this.interceptor.InterceptAsync(targetMethod, args);
        }

    }









}

