using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prism.Regions;

namespace FunnyDation.Wpf.Ranking.Views
{
    /// <summary>
    /// CrlGoldList.xaml 的交互逻辑
    /// </summary>
    public partial class CrlGoldList : UserControl
    {
        public CrlGoldList(IRegionManager regionManager)
        {
            InitializeComponent();
            RegionManager.SetRegionName(GoldContent, "GoldContentRegion");
            RegionManager.SetRegionManager(GoldContent, regionManager);
        }
    }
}
