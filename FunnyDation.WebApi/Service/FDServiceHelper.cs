using Autofac;
using FunnyDation.Common;
using FunnyDation.Common.Service;
using FunnyDation.Common.Service.Proxy;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace FunnyDation.WebApi.Service
{
    /// <summary>
    /// API 调用
    /// </summary>
    public class FDServiceHelper : IFDServiceHelper
    {
        private static ConcurrentDictionary<string, Type> _ServiceInfo = new ConcurrentDictionary<string, Type>();
        private ILifetimeScope _ApplicationContainer;
        private ILogger<FDServiceHelper> _Logger;

        public FDServiceHelper(ILifetimeScope lifetimeScope, ILogger<FDServiceHelper> logger)
        {
            _ApplicationContainer = lifetimeScope;
            _Logger = logger;
        }
        /// <summary>
        /// API 调用
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public ApiResult InvokeApi(ServiceContract contract)
        {
            ApiResult result = new ApiResult();
            if (contract == null)
            {
                return InvokeError(result, "请求的信息为空，请检查！");
            }
            if (string.IsNullOrEmpty(contract.ServiceName))
            {
                return InvokeError(result, "请请求的服务信息为空，请检查！");
            }
            if (string.IsNullOrEmpty(contract.MethodName))
            {
                return InvokeError(result, "请求的服务方法信息为空，请检查！");
            }
            try
            {
                Type _sType;
                if (_ServiceInfo.ContainsKey(contract.ServiceName))
                {
                    _sType = _ServiceInfo[contract.ServiceName];
                }
                else
                {
                    var _iIndex = contract.ServiceName.LastIndexOf('.');
                    var _asmName = contract.ServiceName.Substring(0, _iIndex);
                    if (_asmName.Contains("IRQueryService")
                        || _asmName.Contains("IRDefaultService"))
                    {
                        _asmName = "FunnyDation.Common";
                    }

                    var _asm = Assembly.Load(_asmName);
                    _sType = _asm.GetType(contract.ServiceName);
                    _ServiceInfo.AddOrUpdate(contract.ServiceName, _sType, (key, oldValue) => _sType);

                }
                var _service = _ApplicationContainer.Resolve(_sType);
                if (_service == null)
                {
                    return InvokeError(result, string.Format("找不到请求的服务信息: {0}，请检查！", contract.ServiceName));

                }
                return Invoke(_service, contract, contract.Paras);

            }
            catch (Exception ex)
            {
                return InvokeError(result, ex.Message);
            }

        }

        /// <summary>
        /// 调用服务
        /// </summary>
        /// <param name="service"></param>
        /// <param name="contract"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        private ApiResult Invoke(object service, ServiceContract contract, Dictionary<string, string> paras)
        {
            ApiResult result = new ApiResult();
            try
            {
                MethodInfo _method = service.GetType().GetMethod(contract.MethodName);
                if (_method.IsGenericMethod)
                {
                    _method.MakeGenericMethod(contract.GenericType);

                }
                var _params = _method.GetParameters();
                var _t = _method.ReturnType;
                string _rel = string.Empty;
                if (_params.Length > 0)
                {
                    if (!_params.Length.Equals(paras.Count))
                    {
                        string err = string.Format("传入的参数不匹配{0}，请检查！", service.GetType().FullName);
                        return InvokeError(result, err);
                    }
                    object[] _parameters = new object[_params.Length];
                    int i = 0;
                    foreach (var p in _params)
                    {
                        if (paras.ContainsKey(p.Name))
                        {
                            var _p = JsonHelper.Deserialize(paras[p.Name], p.ParameterType);
                            _parameters[i] = _p;
                            i++;
                        }
                        else
                        {
                            return this.InvokeError(result, String.Format("传入的参数找不到需要的参数：{0}，请检查", p.Name));
                        }
                    }

                    object _o = _method.Invoke(service, _parameters);
                    JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                    _rel = JsonHelper.SerializeWithSetting(_o, _jsonSettings);

                }
                else
                {
                    object _o = _method.Invoke(service, null);
                    _rel = JsonHelper.Serialize(_o);

                }

                result.Message = _rel;
                result.IsSuccess = true;
                _Logger.LogInformation(string.Format("{0}：{1}/{2}调用成功", DateTime.Now, service.GetType().FullName, contract.MethodName));
                return result;
            }
            catch (Exception ex)
            {
                string msg = ex.InnerException is null ? ex.Message : ex.InnerException.Message;
                return this.InvokeError(result, msg);

            }

        }


        public ApiResult InvokeError(ApiResult result, string message)
        {
            result.Message = message;
            _Logger.LogError(result.Message);
            result.IsSuccess = false;
            return result;

        }
    }
}
