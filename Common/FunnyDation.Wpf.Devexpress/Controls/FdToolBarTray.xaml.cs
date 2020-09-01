using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FunnyDation.Wpf.Devexpress.Controls
{
    /// <summary>
    /// FdToolBarTray.xaml 的交互逻辑
    /// </summary>
    public partial class FdToolBarTray : UserControl
    {
        public FdToolBarTray()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetBars
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static ObservableCollection<ToolBarVm> GetBars(DependencyObject obj)
        {
            return (ObservableCollection<ToolBarVm>)obj.GetValue(BarsProperty);
        }
        /// <summary>
        /// SetBars
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetBars(DependencyObject obj, ObservableCollection<ToolBarVm> value)
        {
            obj.SetValue(BarsProperty, value);
        }
        public static readonly DependencyProperty BarsProperty =
            DependencyProperty.RegisterAttached("Bars", typeof(ObservableCollection<ToolBarVm>)
                , typeof(FdToolBarTray), new PropertyMetadata(OnBarsPropertyChanged));

        /// <summary>
        /// Add Bar
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void OnBarsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var toolBarTray = (ToolBarTray)d;
            var barVms = e.NewValue as ObservableCollection<ToolBarVm>;
            if (barVms == null)
            {
                return;
            }
            foreach (var barVm in barVms)
            {
                var tb = new ToolBar();
                tb.Loaded += Tb_Loaded;
                tb.DataContext = barVm;
                toolBarTray.ToolBars.Add(tb);
            }
        }

        /// <summary>
        /// Hidden ToolBar's  Overflow Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void Tb_Loaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) ;
            if (overflowGrid != null)
            {
              (overflowGrid as FrameworkElement).Visibility = Visibility.Collapsed;
            }
            //var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            //if (mainPanelBorder != null)
            //{
            //    mainPanelBorder.Margin = new Thickness();
            //}

        }
    }
}
