using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class ToolBarVm : ToolBarBaseVm
    {

        public ToolBarVm(object hostVm, ToolBarTrayVm toolBarTray, string key) : base(hostVm, key)
        {
            ToolBarTray = toolBarTray;
        }

        public ToolBarTrayVm ToolBarTray { get; set; }

        protected override void OnClicked(NodeVm vm)
        {
            ToolBarTray.DoClicked(vm);
        }
    }
}
