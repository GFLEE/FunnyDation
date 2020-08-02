using FunnyDation.Wpf.Base;
using FunnyDation.Wpf.Ranking.Base;
using FunnyDation.Wpf.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Ranking.Views
{
    public class CrlFundListVm : CrlVm
    {
        public IRESTService _RESTService { get; set; }
        public CrlFundListVm(IRESTService rESTService)
        {
            this._RESTService = rESTService;
            GetList();
        }

        public override void OnInitComplete()
        {
            GetList();
        }

        public List<FundBase> GetList()
        {
            List<FundBase> datas = new List<FundBase>();
            WebTool.GetFundingList(_RESTService);


            return datas;
        }


        public FundBase Datas { get; set; }

    }
}
