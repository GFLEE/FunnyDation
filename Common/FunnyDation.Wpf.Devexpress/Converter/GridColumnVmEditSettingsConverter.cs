using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using FunnyDation.Common.Reflection;
using FunnyDation.Wpf.Base.ViewModel.Grids;
using FunnyDation.Wpf.Base.ViewModel.Grids.GridColumn;

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

            object editor = null;

            switch (column.GridColumnType)
            {
                case GridColumnType.String:
                    var editorTextEdit = new TextEditSettings();
                    editorTextEdit.TextWrapping = System.Windows.TextWrapping.WrapWithOverflow;
                    ReflectionUtils.SetProperty(editorTextEdit, "HorizontalContentAlignment", EditSettingsHorizontalAlignment.Center);
                    editor = editorTextEdit;
                    break;

                case GridColumnType.Int:
                case GridColumnType.Decimal:
                    var columnSetting = column.ColumnSetting as SpinColumnSetting;
                    var editor1 = new SpinEditSettings();
                    ReflectionUtils.SetProperty(editor1, "HorizontalContentAlignment", EditSettingsHorizontalAlignment.Right);
                    if (columnSetting != null)
                    {
                        editor1.Mask = columnSetting.Mask;
                    }
                    NumericMaskOptions.SetAlwaysShowDecimalSeparator(editor1, false);
                    editor1.MaskUseAsDisplayFormat = true;
                    editor = editor1;
                    break;

                case GridColumnType.Date:
                    break;
                case GridColumnType.DateTime:
                    var dateColumnSetting = column.ColumnSetting as DateColumnSetting;
                    var dateEditor = new DateEditSettings();
                    if (dateColumnSetting == null)
                    {
                        dateColumnSetting = new DateColumnSetting();
                        if (column.GridColumnType == GridColumnType.Date)
                        {
                            dateColumnSetting.Mask = "yyyy-MM-dd";
                        }
                        else
                        {
                            dateColumnSetting.Mask = "yyyy-MM-dd HH:mm:ss";

                        }
                    }
                    dateEditor.Mask = dateColumnSetting.Mask;
                    dateEditor.MaskUseAsDisplayFormat = true;
                    ReflectionUtils.SetProperty(dateEditor, "HorizontalContentAlignment", EditSettingsHorizontalAlignment.Left);
                    editor = dateEditor;
                    break;
                case GridColumnType.Enum:
                case GridColumnType.Combo:
                    var comboColumnSetting = column.ColumnSetting as ComboBoxColumnSetting;
                    if (comboColumnSetting == null)
                    {
                        editor = new TextEditSettings();
                        break;
                    }
                    var enumEditor = new ComboBoxEditSettings();
                    var comboBoxEditSettings = new ComboBoxEditSettings();
                    comboBoxEditSettings.ItemsSource = comboColumnSetting.ItemsSource;
                    comboBoxEditSettings.HorizontalContentAlignment = EditSettingsHorizontalAlignment.Center;
                    if (!string.IsNullOrWhiteSpace(comboBoxEditSettings.ValueMember))
                    {
                        comboBoxEditSettings.ValueMember = comboColumnSetting.ValueMember;
                    }
                    if (!string.IsNullOrWhiteSpace(comboBoxEditSettings.DisplayMember))
                    {
                        comboBoxEditSettings.DisplayMember = comboColumnSetting.DisplayMember;

                    }
                    editor = comboBoxEditSettings;
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
