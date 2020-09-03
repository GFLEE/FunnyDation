using FunnyDation.Common;
using FunnyDation.Wpf.Base;
using FunnyDation.Wpf.Base.ViewModel;
using FunnyDation.Wpf.Base.ViewModel.Charts;
using FunnyDation.Wpf.Base.ViewModel.Grids;
using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using FunnyDation.Wpf.Fund.Base;
using FunnyDation.Wpf.Ranking;
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
using System.Windows.Controls;
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
            LineVm = new FdLineVm("X_Date_Value", "Y_String_Value", "TITLE", "日期", "净值涨幅");
            //LineVm.LineColor = "lightblue";
            GridVm = new GridVm(this);
            ToolBar = new ToolBarTrayVm(this);
            UnitLineVm = new FdLineVm("X_Date_Value", "Y_String_Value", "TITLE", "日期", "单位净值");
            //UnitLineVm.LineColor = "lightblue";
        }

        public override void OnInitComplete()
        { 
            // InitLine();
            InitToolBar();
            InitGrid();
        }

        private void InitToolBar()
        {
            ToolBar.DefaultToolBar.AddButton("new", "添加", MyUtility.GetGlyphPath("Action_Chart_Options_32x32.png"));
            ToolBar.DefaultToolBar.AddButton("new2", "添加2", MyUtility.GetGlyphPath("Action_Chart_Options_32x32.png"));
            ToolBar.Clicked += ToolBar_Clicked;
        }

        private void ToolBar_Clicked(object sender, NodeVmArgs e)
        {



        }

        private void InitGrid()
        {
            GridVm.Columns.Add(GridColumnVm.Create("Data.PrimaryKey", "PrimaryKey", 130));
            GridVm.Columns.Add(GridColumnVm.Create("Data.X_Date_Value", "X_Date_Value", 130));
            GridVm.Columns.Add(GridColumnVm.Create("Data.Y_String_Value", "Y_String_Value", 130));

            GridVm.LoadDataSource += LoadGrid;
            GridVm.Refresh();
        } 
        public List<object> LoadGrid()
        {
            List<ChartDataBase> datas = new List<ChartDataBase>();
            int i = 0;
            while (i < 13000)
            {
                ChartDataBase dt = new ChartDataBase("Main", DateTime.Now, i.ToString());
                datas.Add(dt);
                i++;
            }
            List<object> data = datas.Cast<object>().ToList();
            return data;
        }
        public void InitLine()
        {
            GetList();

        }

        public async void GetList()
        {

            //007301
            //161725
            var data = WebTool.GetFunDetail(_RESTService, "000001").data;
            LineVm.ChartTitle = data.name;
            UnitLineVm.ChartTitle = data.name;
            List<List<string>> worth = data.netWorthData;
            List<WorthBase> datas = new List<WorthBase>();
            foreach (List<string> arr in worth)
            {
                WorthBase worthBase = new WorthBase(DateTime.Parse(arr[0]), arr[1], arr[2]);
                datas.Add(worthBase);
            }

            datas = datas.Where(p => p.Date >= DateTime.Parse("2020-01-01")).ToList();
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

        public ToolBarTrayVm ToolBar { get; set; }

        public GridVm GridVm { get; set; }


        public FdLineVm lineVm;
        public FdLineVm LineVm
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

        public FdLineVm unitLineVm;
        public FdLineVm UnitLineVm
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
