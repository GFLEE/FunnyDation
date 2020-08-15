using FunnyDation.Wpf.Base;
using FunnyDation.Wpf.Fund.Base;
using FunnyDation.Wpf.Web;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace FunnyDation.Wpf.Fund.Views
{
    public class CrlFundListVm : CrlVm
    {
        public IRESTService _RESTService { get; set; }
        public CrlFundListVm(IRESTService rESTService)
        {
            this._RESTService = rESTService;
        }

        public override void OnInitComplete()
        {
            GetList();
        }

        public async void GetList()
        {
            await Task.Run(() =>
            {
                //List<FundBase> datas = new List<FundBase>();
                //datas = WebTool.GetFundingList(_RESTService).data;
                //Datas = datas;
                //MessageBox.Show(string.Join(",", datas.Select(P => P.name)));

                //return datas;

            });

        }


        public List<FundBase> Datas { get; set; }

    }
}
