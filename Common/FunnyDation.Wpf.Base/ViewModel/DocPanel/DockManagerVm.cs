using Prism.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public class DockManagerVm
    {
        public DockManagerVm()
        {
            Panels = new ObservableCollection<DockPanelVm>();

            DmvService.Instance.AddDockManagerVm(this);
        }
        public ObservableCollection<DockPanelVm> Panels
        {
            get; set;
        }

        internal void ClosePanel(DockPanelVm dockPanelVm)
        {





        }
    }
}
