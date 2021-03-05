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
        public IAppSettingService _AppSettingS;

        public WebApiClient(IFPContext fPContext, IAppSettingService appSettingService)
        {
            _Context = fPContext;
            _AppSettingS = appSettingService;

        }
        //此处最好注入一个appsetting service

        public T Create<T>() where T : class
        {


        }

        public object Create(Type type)
        {

        }
    }
}
