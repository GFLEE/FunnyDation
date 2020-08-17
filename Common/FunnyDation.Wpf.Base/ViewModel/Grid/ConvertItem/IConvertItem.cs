using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FunnyDation.Wpf.Base.ViewModel.Grid.ConvertItem
{
    /// <summary>
    /// IConvertItem
    /// </summary>
    public interface IConvertItem : IValueConverter
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        object Convert(object value);

    }
}
