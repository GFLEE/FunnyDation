using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf.Selectors;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridVm : BindableBase, ITemplateItem
    {

        public GridVm()
        {
            DataSource = new ObservableCollection<ExpandoObject>();
            Columns = new ObservableCollection<GridColumnVm>();
        }




     


        public virtual ObservableCollection<ExpandoObject> DataSource { get; set; }
        public virtual ObservableCollection<GridColumnVm> Columns { get; set; }
        public string TemplateName { get; set; }
    }
}
