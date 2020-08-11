using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Devexpress.Selector
{
    public class DockPanelSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var vm = item as DockPanelVm;
            if (vm == null || string.IsNullOrEmpty(vm.TemplateName))
            {
                return null;
            }

            var result = (DataTemplate)((Control)container).FindResource((vm.TemplateName));

            return result; 
        } 

    }
}
