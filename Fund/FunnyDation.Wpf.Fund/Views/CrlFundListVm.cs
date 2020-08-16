using FunnyDation.Wpf.Base;
using FunnyDation.Wpf.Base.ViewModel.Charts;
using FunnyDation.Wpf.Fund.Base;
using FunnyDation.Wpf.Ranking.Base;
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
            LineVm = new LineVm("X_Date_Value", "Y_String_Value", "TITLE", "日期", "净值涨幅");
            //LineVm.LineColor = "lightblue";

            UnitLineVm = new LineVm("X_Date_Value", "Y_String_Value", "TITLE", "日期", "单位净值");
            //UnitLineVm.LineColor = "lightblue";
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
            UnitLineVm.ChartTitle = data.name;
            List<List<string>> worth = data.netWorthData;
            List<WorthBase> datas = new List<WorthBase>();
            foreach (List<string> arr in worth)
            {
                WorthBase worthBase = new WorthBase(DateTime.Parse(arr[0]), arr[1], arr[2]);
                datas.Add(worthBase);
            }

            datas = datas.Where(p => p.Date >= DateTime.Parse("2019-01-01")).ToList();
            foreach (var dt in datas)
            {
                ChartDataBase line_data = new ChartDataBase("净值涨幅", dt.Date,
                    string.Format("{0}", dt.Rate));

                this.LineVm.DataSource.Add(line_data);
                LineVm.DataSource.Add(new ChartDataBase("单位净值", dt.Date,
               string.Format("{0}", dt.Unit_worth)));

                UnitLineVm.DataSource.Add(new ChartDataBase("单位净值", dt.Date,
                    string.Format("{0}", dt.Unit_worth)));
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

        public LineVm unitLineVm;
        public LineVm UnitLineVm
        {
            get
            {
                return unitLineVm;
            }

            set
            {
                unitLineVm = value;
                SetProperty(ref unitLineVm, value);

            }
        }


    }
}
