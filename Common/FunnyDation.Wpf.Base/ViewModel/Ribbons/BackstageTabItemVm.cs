using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using FunnyDation.Wpf.Selectors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace FunnyDation.Wpf.Base.Ribbons
{

    public class BackstageTabItemVm : ITemplateItem
    {
        public BackstageTabItemVm(RibbonPageGroupVm ribbonPageGroupVm)
        {
            RibbonPageGroup = ribbonPageGroupVm;
            Items = new ObservableCollection<BarItemVm>();
        }



        public RibbonPageGroupVm RibbonPageGroup { get; set; }
        public string Caption { get; set; }
        public ObservableCollection<BarItemVm> Items { get; set; }
        public string TemplateName { get { return "TemplateButtonGroup"; } set { } }
    }
}
