using System;

namespace FunnyDation.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class FDConst
    {
        #region Client
        public const string ModulePath = "Modules";
        public const string ranking_client = "FunnyDation.Wpf.Ranking";

        public const string IS_Client = "WPFClient";

        public const string IS_ClientSecret = "WPFClientSecret";

        #endregion

        #region RESTService
        public const string Encoding_UTF8 = "UTF-8";
        public const string HTTPContent_Json = "application/json";

        #endregion

        #region proxy

        public const string IS_AuthenticationToken = "AuthenticationToken";
        public const string IS_AuthenticationRefreshToken = "AuthenticationRefreshToken";
        public const string ServiceAddressEx = "/Api/ApiService/InvokeApi";
        public const string NotAuthorizeServiceAddressEx = "/Api/ApiService/InvokeApiNotAuthorize";
        public const string AppSettings_ServiceAddress = "ServiceAddress";
        public const string AppSettings_AuthAddress = "AuthAddress";


        #endregion


        #region fund
        public const string FundBaseUrl = @"https://api.doctorxiong.club/v1/fund";
        public const string FundDetailUrl = @"https://api.doctorxiong.club/v1/fund/detail";

        #region server
        public const string IS_Scope = "FDAPI";

        public const string IS_Mvc_Client = "MvcClient";

        public const string IS_Mvc_ClientSecret = "MvcClientSecret ";

        public static string IS_Wpf_ClientSecret = "WpfClientSecret ";

        #endregion







        #endregion
    }
}
