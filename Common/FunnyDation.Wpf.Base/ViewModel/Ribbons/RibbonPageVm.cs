using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class RibbonPageVm : BindableBase
    {
        public RibbonPageVm(RibbonVm ribbonVm)
        {

        }

        public string Caption { get; internal set; }
    }
}
