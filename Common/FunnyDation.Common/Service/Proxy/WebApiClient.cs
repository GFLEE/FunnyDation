using FunnyDation.Common.Context;
using FunnyDation.Common.Service.AppSetting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    public class WebApiClient : IServiceProxy
    {

        public IFPContext _Context;
        public IAppSettingService _AppSettings;


        /// <summary>
        /// WebApiClient（此处最好注入一个appsetting service）
        /// </summary>
        /// <param name="fPContext"></param>
        /// <param name="appSettingService"></param>
        public WebApiClient(IFPContext fPContext, IAppSettingService appSettingService)
        {
            _Context = fPContext;
            _AppSettings = appSettingService;

        }

        public T Create<T>() where T : class
        {
            return (T)ProxyGenerator.Create(typeof(T), new ServiceProxy(_Context, _AppSettings));

        }

        public object Create(Type type)
        {
            return ProxyGenerator.Create(type, new ServiceProxy(_Context, _AppSettings));
        }
    }
}
