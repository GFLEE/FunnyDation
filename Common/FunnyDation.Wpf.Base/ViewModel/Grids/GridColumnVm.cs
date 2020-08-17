using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridColumnVm
    {
        public string FieldName { get; set; } 
        public string Header { get; set; }
        public string Mask { get; set; }
        public GridColumnType FieldType { get; set; }
        public int EuFieldTypes { get; set; }

        public GridColumnVm(string field, string header, GridColumnType type, string mask = null)
        {
            FieldName = field;
            Header = header;
            FieldType = type;
            Mask = mask;
        }

        /// <summary>
        /// 添加Column
        /// </summary>
        /// <param name="field"></param>
        /// <param name="header"></param>
        /// <param name="type"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static GridColumnVm Create(string field, string header, GridColumnType type, string mask = null)
        {
            return new GridColumnVm(field,  header,  type,  mask);
        }

    }
}
