using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class ComboBoxColumnSetting : IColumnSetting
    {

        /// <summary>
        /// ItemSource
        /// </summary>
        public object ItemSource { get; set; }
        /// <summary>
        /// ValueMember
        /// </summary>
        public string ValueMember { get; set; }
        /// <summary>
        /// DisplayMember
        /// </summary>
        public string DisplayMember { get; set; }
    }
}
