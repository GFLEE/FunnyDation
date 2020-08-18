using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Editors.Native;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridOption : BindableBase
    {
        public GridOption()
        {
            Columns = new ObservableCollection<GridColumnVm>();
        }


        public ObservableCollection<GridColumnVm> Columns { get; private set; }
    }
}
