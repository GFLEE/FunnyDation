using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public const string ListOfCollagesPropertyName = "ListOfCollages";

        private ObservableCollection<MDIitem> _ListOfCollages = null;
        public ObservableCollection<MDIitem> ListOfCollages
        {
            get
            {
                return _ListOfCollages;
            }

            set
            {
                if (_ListOfCollages == value)
                {
                    return;
                }

                _ListOfCollages = value;
                NotifyPropertyChanged("ListOfCollages");
            }
        }



        public void DocVM()
        {

            if (ListOfCollages == null)
                ListOfCollages = new ObservableCollection<MDIitem>();

            ListOfCollages.Clear();

            ListOfCollages.Add(new MDIitem() { WindowID = 1, WindowName = "Doc A", WindowContent = "Text a" });
            ListOfCollages.Add(new MDIitem() { WindowID = 2, WindowName = "Doc B", WindowContent = "Text b" });
            ListOfCollages.Add(new MDIitem() { WindowID = 3, WindowName = "Doc C", WindowContent = "Text c" });

        }


    }

}
