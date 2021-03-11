using CommonServiceLocator;
using FunnyDation.Common.Service.Proxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Wpf.Base.Proxy
{
    public class FDProxyFactory
    {

        public static T Create<T>() where T : class,new()
        {
            var _Proxy = ServiceLocator.Current.TryResolve<IServiceProxy>();
            if (_Proxy == null)
            {
                throw new Exception("Proxy Create Error!");
            }
            return _Proxy.Create<T>();
        }


        public static object Create(Type type)
        {
            var _Proxy = ServiceLocator.Current.TryResolve<IServiceProxy>();
            if (_Proxy == null)
            {
                throw new Exception("Proxy Create Error!");
            }
            return _Proxy.Create(type);
        }



    }
}
