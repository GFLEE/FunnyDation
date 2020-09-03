using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;


namespace FunnyDation.Wpf.Devexpress.Controls.Converter
{
    public class EventConvert : EventArgsConverterBase<CustomColumnDisplayTextEventArgs>
    {
        protected override object Convert(object sender, CustomColumnDisplayTextEventArgs args)
        {
            return args; 

        }
         
    }

    public class LoadEventConvert : EventArgsConverterBase<RoutedEventArgs>
    {
        protected override object Convert(object sender, RoutedEventArgs args)
        {
            return args;
        }
    }

    public class ButtonEventConvert : EventArgsConverterBase<MouseButtonEventArgs>
    {  
        protected override object Convert(object sender, MouseButtonEventArgs args)
        {
            return args;
        }
    }
}
