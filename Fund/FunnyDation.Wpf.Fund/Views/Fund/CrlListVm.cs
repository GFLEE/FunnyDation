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
using FunnyDation.IService.Fund;
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
using FunnyDation.Service.Fund;

namespace FunnyDation.Wpf.Ranking.Views.Fund
{
    public class CrlListVm : CrlVm
    {
        public CrlListVm()
        {
            GridVm = new GridVm(this);


        }

        public override void OnInitComplete()
        {
            IUserInfoRepository repository = new UserInfoRepository();

            repository.ValidateUser("Lee");

        }

        private void InitGrid()
        {
            GridVm.Columns.Add(GridColumnVm.Create("Data.C1", "PrimaryKey", 130));
            GridVm.Columns.Add(GridColumnVm.Create("Data.C2", "X_Date_Value", 130));
            GridVm.Columns.Add(GridColumnVm.Create("Data.C3", "Y_String_Value", 130));

            GridVm.LoadDataSource += LoadGrid;
            GridVm.Refresh();
        }

        private List<object> LoadGrid()
        {

            return new List<object>();
        }

        public GridVm GridVm { get; set; }

    }
}
