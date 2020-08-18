using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridDataSourceOption
    {
        public GridDataSourceOption()
        {
            Condition = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Condition { get; set; }

        /// <summary>
        /// Not Need
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, string> GetCondition()
        {

            return null;
        }

    }
}
