using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.ViewModel.Grid
{
    public class GridVm : BindableBase
    {

        public GridVm()
        {
            DataSource = new ObservableCollection<ExpandoObject>();
            Columns = new ObservableCollection<ColumnVm>();
        }







        public virtual ObservableCollection<ExpandoObject> DataSource { get; set; }
        public virtual ObservableCollection<ColumnVm> Columns { get; set; }





    }
}
