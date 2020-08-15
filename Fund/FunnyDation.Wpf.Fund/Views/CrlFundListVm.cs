using FunnyDation.Wpf.Base;
using FunnyDation.Wpf.Base.ViewModel.Charts;
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
using System.Windows.Threading;

namespace FunnyDation.Wpf.Fund.Views
{
    public class CrlFundListVm : CrlVm
    {
        public IRESTService _RESTService { get; set; }
        public CrlFundListVm(IRESTService rESTService) : base()
        {
            this._RESTService = rESTService;
            LineVm = new LineVm("X_String_Value", "Y_String_Value", "TITLE", "日期", "净值涨幅");
            LineVm.LineColor = "lightblue";
        }

        public override void OnInitComplete()
        {
            InitLine();

        }

        public void InitLine()
        {
            GetList();

        }

        public async void GetList()
        {
           
                //007301
                //161725
                var data = WebTool.GetFunDetail(_RESTService, "161725").data;
                LineVm.ChartTitle = data.name;
                foreach (List<string> arr in data.netWorthData)
                {
                    ChartDataBase line_data = new ChartDataBase(data.name, arr[0], arr[2]);
                 
                        this.LineVm.DataSource.Add(line_data); 

                } 
        }






        public LineVm lineVm;
        public LineVm LineVm
        {
            get
            {
                return lineVm;
            }

            set
            {
                lineVm = value;
                SetProperty(ref lineVm, value);

            }
        }



    }
}
