using FunnyDation.Common.Context;
using FunnyDation.Common.Service.AppSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace FunnyDation.Common.Service.Proxy
{
    public class ServiceProxy : IInterceptor
    {
        public IFPContext _Context;
        public IAppSettingService _AppSettings;

        private string _Token { get; set; }

        public ServiceProxy(IFPContext fPContext, IAppSettingService appSettingService)
        {
            _Context = fPContext;
            _AppSettings = appSettingService;
            _Token = _Context.GetValue(FDConst.IS_Authentication);
        }

        /// <summary>
        /// 实现拦截器
        /// </summary>
        /// <param name="targetMethod"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object InterceptAsync(MethodInfo targetMethod, object[] parameters)
        {
            ServiceContract _contract = new ServiceContract
            {
                ServiceName = targetMethod.DeclaringType.FullName,
                MethodName = targetMethod.Name,
                IsGenericMethod = targetMethod.IsGenericMethod
            };
            if (_contract.IsGenericMethod)
            {
                _contract.GenericType = targetMethod.GetGenericArguments();
            }
            _contract.Paras = new Dictionary<string, string>();
            int i = 0;
            var _paras = targetMethod.GetParameters();
            foreach (var p in _paras)
            {
                _contract.Paras.Add(p.Name, JsonHelper.Serialize(_paras[i]));
                i++;
            }
            HttpClient _client = new HttpClient();
            string _ServiceAddressEx = targetMethod.CustomAttributes.FirstOrDefault(p =>
                                        p.AttributeType == typeof(NotAuthorizeAttribute)) == null
                                        ? FDConst.ServiceAddressEx : FDConst.NotAuthorizeServiceAddressEx;


            return null;
        }

        private bool RefreshToken(string _RefreshToken, string address)
        {

            return true;
        }


    }
}
