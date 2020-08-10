using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Base.ViewModel
{
    public class FDDocPanelVm : CrlVm
    {
        public FDDocPanelVm()
        {

        }

        public FDDocPanelVm(object host)
        {
            this.HostVm = host;
        }
       
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PanelItem AddPanel(int id, string name, UserControl obj)
        {
            if (Panels == null)
            {
                Panels = new ObservableCollection<PanelItem>();
            }

            PanelItem panel = new PanelItem(id, name, obj);
            Panels.Add(panel);

            return panel;
        }


        public int Clear()
        {
            int count = Panels.Count();
            Panels.Clear();
            return count;
        }








        public object HostVm { get; set; }

        public ObservableCollection<PanelItem> panels;
        public ObservableCollection<PanelItem> Panels
        {
            get
            {
                return panels;
            }

            set
            {
                panels = value;
                SetProperty(ref panels, value);
            }
        }


    }

}
