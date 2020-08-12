using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    /// <summary>
    /// BarItemVm
    /// </summary>
    public class BarItemVm : NodeVm
    {
        public BarItemVm(string toolTip) : base()
        {
            ToolTip = toolTip;
        }

        public ToolBarVm ToolBar
        {
            get
            {
                return (ToolBarVm)this.Container;
            }
        }
        public string ToolTip { get; set; }
    }
}
