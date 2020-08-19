using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf.Base;
using Prism.Regions;

namespace FunnyDation.Wpf.Ranking.Views
{
    public class CrlGoldListVm : CrlVm
    {
        IRegionManager _RegionManager { get; set; }
        public CrlGoldListVm(IRegionManager regionManager)
        {
            _RegionManager = regionManager;
            regionManager.Regions.Remove("GoldContentRegion");
        }
    }
}
