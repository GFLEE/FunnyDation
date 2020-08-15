using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.Editors.Settings;
using FunnyDation.Wpf.Base.ViewModel.Grid;

namespace FunnyDation.Wpf.Devexpress.Converter
{
    public class GridColumnVmEditSettingsConverter : MarkupExtension, IValueConverter
    { 
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            var column = (GridColumnVm)value;

            object editor;

            switch (column.FieldType)
            {
                case GridColumnType.String:
                    editor = new TextEditSettings();
                    break;

                case GridColumnType.Int:
                case GridColumnType.Decimal:
                    editor = new SpinEditSettings { Mask = column.Mask, MaskUseAsDisplayFormat = true };
                    break;

                case GridColumnType.Date:
                    editor = new DateEditSettings { Mask = column.Mask, MaskUseAsDisplayFormat = true };
                    break;

                case GridColumnType.Bool:
                    editor = new CheckEditSettings { IsThreeState = false, NullValue = false };
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            return editor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
