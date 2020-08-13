using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class RibbonPageCategoryVm : BindableBase
    {
        public RibbonPageCategoryVm(RibbonVm ribbonVm)
        {
            Ribbon = ribbonVm;
            Pages = new ObservableCollection<RibbonPageVm>();
            IsEnabled = ribbonVm.IsEnabledOfPageCategory;
        }

        public bool isEnabled;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                isEnabled = value;
                SetProperty(ref isEnabled, value);

            }
        }
        public RibbonVm Ribbon { get; set; }

        public string caption;
        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
                SetProperty(ref caption, value);

            }
        }


        public ObservableCollection<RibbonPageVm> Pages { get; set; }

        public RibbonPageVm AddPage(string cap)
        {
            var page = new RibbonPageVm(this.Ribbon) { Caption = cap };

            Pages.Add(page);

            return page;
        }


    }
}
