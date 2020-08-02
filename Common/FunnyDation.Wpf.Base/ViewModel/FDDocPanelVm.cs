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
        public object HostVm { get; set; }

        public const string ListOfCollagesPropertyName = "Panels";

        public ObservableCollection<PanelItem> panel = null;
        public ObservableCollection<PanelItem> Panels
        {
            get
            {
                return panel;
            }

            set
            {
                if (panel == value)
                {
                    return;
                }

                panel = value;
                NotifyPropertyChanged("Panels");
            }
        }


        /// <summary>
        /// Add
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public PanelItem AddPanel(UserControl obj)
        {
            if (Panels == null)
            {
                Panels = new ObservableCollection<PanelItem>();
            }

            PanelItem panel = new PanelItem(1, "666", new UserControl());
            Panels.Add(panel);

            return panel;
        }

        public void DocVM()
        {



            Panels.Clear();

            //ListOfCollages.Add(new PanelItem() { WindowID = 1, WindowName = "Doc A", WindowContent = "Text a" });
            //ListOfCollages.Add(new PanelItem() { WindowID = 2, WindowName = "Doc B", WindowContent = "Text b" });
            //ListOfCollages.Add(new PanelItem() { WindowID = 3, WindowName = "Doc C", WindowContent = "Text c" });

        }


    }

}
