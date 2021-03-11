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
        #endregion

        #region RESTService
        public const string Encoding_UTF8 = "UTF-8";
        public const string HTTPContent_Json = "application/json";

        #endregion

        #region 

        public const string IS_Authentication = "AuthenticationToken";
        public const string ServiceAddressEx = "/Api/ApiService/InvokeApi";
        public const string NotAuthorizeServiceAddressEx = "/Api/ApiService/InvokeApiNotAuthorize";


        #endregion


        #region fund
        public const string FundBaseUrl = @"https://api.doctorxiong.club/v1/fund";
        public const string FundDetailUrl = @"https://api.doctorxiong.club/v1/fund/detail";



        #endregion
    }
}
