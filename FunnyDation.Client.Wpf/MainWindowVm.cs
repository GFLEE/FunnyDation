using FunnyDation.Wpf.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf;
using FunnyDation.Wpf.Base;


namespace FunnyDation.Client.Wpf
{
    public class MainWindowVm : CrlVm
    {
        public MainWindowVm()
        {
            DocPanelVm = new FDDocPanelVm(this);
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
                docPanelVm = value;
                NotifyPropertyChanged("DocPanelVm");
            }
        }

    }
}
