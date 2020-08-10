using FunnyDation.Wpf.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf;
using FunnyDation.Wpf.Base;
using Prism.Mvvm;
using System.IO;
using FunnyDation.Common;
using System.Reflection;
using Prism.Commands;
using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System.Collections.ObjectModel;
using Prism.Modularity;
using FunnyDation.Common.Helper;

namespace FunnyDation.Client.Wpf
{
    public class MainWindowVm : CrlVm
    {
        public MainWindowVm()
        {
            DocPanelVm = new FDDocPanelVm(this);
            DocPanelVm.Panels = new ObservableCollection<PanelItem>();
             CommandFundBase = new DelegateCommand(GetFundsInfo);
        }

        private void GetFundsInfo()
        {
            DocPanelVm.AddPanel(2, "sdadsa", new System.Windows.Controls.UserControl());

           
            if (RankingAssb == null)
            {
                string mdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FDConst.ModulePath);
                var file = Directory.GetFiles(mdPath, string.Format("{0}.dll", FDConst.ranking_client), SearchOption.AllDirectories).FirstOrDefault();
                RankingAssb = Assembly.LoadFile(file);
            }

            var mudule = RankingAssb.GetTypes().FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IModule)));
            var type = RankingAssb.GetType(ReflectionHelper.GetPropertyValueSafely(mudule, mudule.GetProperty("StartPagePath")).ToString());
            var crl = CrlFactory.Create(type, (crlVm) =>
             {


             });



        }







        public Assembly RankingAssb { get; set; }
        public DelegateCommand CommandFundBase { get; set; }

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
