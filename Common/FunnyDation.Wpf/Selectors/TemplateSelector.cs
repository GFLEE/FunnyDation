using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Selectors
{
    public class TemplateSelector : DataTemplateSelector
    {
        public object Host { get; set; } 

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            var templateItem = item as ITemplateItem;
            var tName = DefaultTemplateName;
            if (templateItem != null && !string.IsNullOrEmpty(templateItem.TemplateName))
            {
                tName = templateItem.TemplateName;

            }

            if (string.IsNullOrEmpty(tName))
            {
                return null;
            }

            if (container is FrameworkElement)
            {
                DataTemplate result = (DataTemplate)((FrameworkElement)container).FindResource(tName);

                return result;
            }
            if (container is FrameworkContentElement)
            {
                DataTemplate result = (DataTemplate)((FrameworkContentElement)container).FindResource(tName);
                if (result == null)
                {
                    if (this.Host != null)
                    {
                        result = (DataTemplate)((FrameworkElement)Host).FindResource(tName);

                    }
                }
                return result;
            }

            return base.SelectTemplate(item, container);
        }


        public string DefaultTemplateName { get; set; }

    }
}
