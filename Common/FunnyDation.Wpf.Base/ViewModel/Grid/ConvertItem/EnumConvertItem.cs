using FunnyDation.Common.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grid.ConvertItem
{
    public class EnumConvertItem : ConvertItemBase
    {

        public EnumCollection collection;

        public EnumConvertItem(Type enumType)
        {
            collection = new EnumCollection(enumType);
        }
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            var type = value.GetType();
            if (type.Equals(typeof(string)))
            {
                return collection[(string)value].Description;

            }
            if (type.Equals(typeof(int)))
            {
                return collection[(int)value].Description;

            }

            return collection[value].Description;
        }
    }
}
