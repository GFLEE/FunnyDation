using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Ribbon = ribbonVm;
            Groups = new ObservableCollection<RibbonPageGroupVm>();
        }
        public RibbonVm Ribbon { get; set; }
        public ObservableCollection<RibbonPageGroupVm> Groups { get; set; }

        public RibbonPageGroupVm AddGroup(string key, string caption)
        {
            RibbonPageGroupVm group = new RibbonPageGroupVm(this, key)
            {
                Caption = caption
            };
            Groups.Add(group);
            return group;
        }


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
    }
}
