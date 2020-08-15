using FunnyDation.Common;
using FunnyDation.Wpf.Ranking.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Ranking
{
    public class WebTool
    {
        /// <summary>
        /// funding list
        /// </summary>
        /// <returns></returns>
        public static FundInfo GetFundingList(IRESTService rESTService)
        {

            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "code", "007301,202015,007339" }
            };

            var res = rESTService.Get(FDConst.FundBaseUrl, dic);

            FundInfo fundInfo = JsonConvert.DeserializeObject<FundInfo>(res);
            if (fundInfo.code.Equals(200))
            {
                return fundInfo;

            }
            else
            {
                throw new Exception("Get Failed!");
            }

        }



    }
}
