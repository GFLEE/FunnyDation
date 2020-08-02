using FunnyDation.Wpf.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf;
using FunnyDation.Wpf.Base;
using Prism.Mvvm;

namespace FunnyDation.Client.Wpf
{
    public class MainWindowVm : CrlVm
    {
        public MainWindowVm()
        {
            DocPanelVm = new FDDocPanelVm(this);
        }















        public string text;
        public string Text
        {
            get
            {
                return text;
            }

            set
            {

                text = value;
                SetProperty(ref text, value);
            }
        }


        public FDDocPanelVm docPanelVm;
        public FDDocPanelVm DocPanelVm
        {
            get
            {
                return docPanelVm;
            }

            set
            {
                if (docPanelVm == value)
                {
                    return;
                }
                docPanelVm = value;
                SetProperty(ref docPanelVm, value);

            }
        }

    }
}
