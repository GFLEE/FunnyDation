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

        #region fund
        public const string FundBaseUrl = @"https://api.doctorxiong.club/v1/fund";
        public const string FundDetailUrl = @"https://api.doctorxiong.club/v1/fund/detail";



        #endregion
    }
}
