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

namespace FunnyDation.Wpf.Fund.Views
{
    public class CrlFundListVm : CrlVm
    {
        public IRESTService _RESTService { get; set; }
        public CrlFundListVm(IRESTService rESTService) : base()
        {
            this._RESTService = rESTService;
            LineVm = new LineVm("X_Decimal_Value", "Y_Decimal_Value", "TITLE", "X", "Y");
            LineVm.LineColor = "lightblue";
        }

        public override void OnInitComplete()
        {
            GetList();
            InitLine();

        }

        public void InitLine()
        {
            //for (int i = 0; i < 20; i++)
            //{
            //    ChartDataBase data = new ChartDataBase("line_key", i, i + 2);
            //    this.LineVm.DataSource.Add(data);
            //}

            //for (int i = 0; i < 20; i++)
            //{
            //    ChartDataBase data = new ChartDataBase("line_key2", i, i + 4);
            //    this.LineVm.DataSource.Add(data);
            //}

            var data = WebTool.GetFunDetail(_RESTService, "007301").data;



        }

        public async void GetList()
        {
            await Task.Run(() =>
            {
                //List<FundBase> datas = new List<FundBase>();
                //datas = WebTool.GetFundingList(_RESTService).data;
                //MessageBox.Show(string.Join(",", datas.Select(P => P.name)));

                //return datas;

            });

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
