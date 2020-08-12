using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using FunnyDation.Wpf.Selectors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace FunnyDation.Wpf.Base.Ribbons
{

    public class BackstageTabItemVm 
    {
        public string Content { get; set; }
        public object PanelVm { get; set; }
        public ICommand TabClick { get; set; }
         

      
    }
}
