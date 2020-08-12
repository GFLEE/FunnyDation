using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class RibbonPageGroupVm : ToolBarBaseVm
    {
        internal string Caption;

        //public RibbonPageGroupVm()
        //{

        //}

        public RibbonPageGroupVm(object hostVm, string key) : base(hostVm, key)
        {
        }
    }
}
