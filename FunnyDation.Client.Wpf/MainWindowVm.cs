using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Client.Wpf
{
    /// <summary>
    /// MainWindowVm
    /// </summary>
    public class MainWindowVm
    {
        public readonly IEventAggregator _EA;
        public readonly IModuleManager _MM;
        public readonly IRegionManager _RegionManager;

        public MainWindowVm(IEventAggregator ea, IModuleManager moduleManager,IRegionManager regionManager)
        {
            this._EA = ea;
            this._MM = moduleManager;
            this._RegionManager = regionManager;
            //moduleManager.LoadModule();
        }

        public void LoadModules()
        {



        }



        public void Test()
        {

        }




    }
}
