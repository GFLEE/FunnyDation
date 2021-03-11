using FunnyDation.Common.Context;
using FunnyDation.Common.Service.AppSetting;
using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            _Token = _Context.GetValue(FDConst.IS_AuthenticationToken);
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
            string _url = _AppSettings.GetAppSetting(FDConst.AppSettings_ServiceAddress);
            if (_url.EndsWith("/"))
            {
                _url += _ServiceAddressEx;
            }
            else
            {
                _url += "/" + _ServiceAddressEx;

            }
            var _returnType = targetMethod.ReturnType;
            if (this._Token != null)
            {
                _client.SetBearerToken(_Token);
            }
            else
            {
                return Activator.CreateInstance(_returnType);
            }
            try
            {
                HttpContent _content = new StringContent(JsonHelper.Serialize(_contract));
                _content.Headers.ContentType = new MediaTypeHeaderValue(FDConst.HTTPContent_Json)
                {
                    CharSet = FDConst.Encoding_UTF8
                };
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(FDConst.HTTPContent_Json));
                HttpResponseMessage httpResponse = _client.PostAsync(_url, _content).Result;  //Post

                if (httpResponse.StatusCode.Equals(HttpStatusCode.Unauthorized))  //Token Expirded
                {
                    var _refreshToken = _Context.GetValue("");  //get refresh token 
                    var address = _AppSettings.GetAppSetting(FDConst.AppSettings_ServiceAddress);
                    if (!string.IsNullOrEmpty(_refreshToken) && !string.IsNullOrEmpty(address))
                    {
                        var isError = RefreshToken(_refreshToken, address);
                        if (!isError)
                        {
                            _Token = this._Context.GetValue(FDConst.IS_AuthenticationToken).ToString();
                            return this.InterceptAsync(targetMethod, parameters);

                        }
                    }
                }

                httpResponse.EnsureSuccessStatusCode();
                if (httpResponse.IsSuccessStatusCode)
                {
                    String _sResult = httpResponse.Content.ReadAsStringAsync().Result;
                    ApiResult _result = JsonHelper.Deserialize<ApiResult>(_sResult);

                    if (_result.IsSuccess)
                    {

                        var _t = targetMethod.ReturnType;
                        if (_t.FullName == typeof(void).FullName)
                        {

                            return null;
                        }

                        var _r = JsonHelper.Deserialize(_result.Message, _t);
                        return _r;
                    }
                    else
                    {
                        throw new Exception(_result.Message);
                    }
                }
                else
                {
                    throw new Exception(string.Format("连接服务器失败，错误代码：{0}", httpResponse.StatusCode));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {

                _client.Dispose();
            }
        }

        /// <summary>
        /// 刷新 Access Token
        /// </summary>
        /// <param name="_RefreshToken"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool RefreshToken(string _RefreshToken, string address)
        {
            HttpClient _client = new HttpClient();
            DiscoveryPolicy policy = new DiscoveryPolicy
            {
                RequireHttps = false
            };
            DiscoveryDocumentRequest request = new DiscoveryDocumentRequest();
            request.Address = address;
            request.Policy = policy;
            var _discover = _client.GetDiscoveryDocumentAsync(request).Result;
            if (!_discover.IsError)
            {
                var rcct = new RefreshTokenRequest();
                rcct.Address = _discover.TokenEndpoint;
                rcct.ClientId = FDConst.IS_Client;
                rcct.ClientSecret = FDConst.IS_ClientSecret;
                rcct.RefreshToken = _RefreshToken;
                var token = _client.RequestRefreshTokenAsync(rcct).Result;
                if (!token.IsError)
                {
                    //Set new Access token
                    //Commonutility.GetContext().SetValue(FDConst.IS_AuthenticationToken, token.AccessToken);
                    //set new refresh token
                    //Commonutility.GetContext().SetValue(FDConst.IS_AuthenticationRefreshToken, token.RefreshToken);

                }

                return token.IsError;

            }

            return _discover.IsError;
        }


    }
}
