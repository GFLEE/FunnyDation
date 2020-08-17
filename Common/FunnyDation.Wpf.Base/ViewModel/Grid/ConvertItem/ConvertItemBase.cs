using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FunnyDation.Wpf.Base.ViewModel.Grid.ConvertItem
{
    public abstract class ConvertItemBase : IValueConverter
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { get; set; }


        public abstract  object Convert(object value, Type targetType, object parameter, CultureInfo culture);
       
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
