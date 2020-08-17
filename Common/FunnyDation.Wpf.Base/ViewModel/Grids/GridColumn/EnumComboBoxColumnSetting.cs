using DevExpress.Xpf.Editors;
using FunnyDation.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class EnumComboBoxColumnSetting : ComboBoxColumnSetting
    {
        EnumCollection collectiion;

        public Type EnumType { get; set; }

        public EnumComboBoxColumnSetting(Type type)
        {
            EnumType = type;
            collectiion = new EnumCollection(type);
            ItemsSource = collectiion;
            ValueMember = "Value";
            DisplayMember = "Description";

        }
    }
}
