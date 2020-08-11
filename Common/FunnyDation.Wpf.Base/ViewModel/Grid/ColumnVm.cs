using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grid
{
    public class ColumnVm
    {
        public string FieldName { get; set; } 
        public string Header { get; set; }
        public string Mask { get; set; }
        public EuFieldTypes FieldType { get; set; }

        public ColumnVm(string field, string header, EuFieldTypes type, string mask = null)
        {
            FieldName = field;
            Header = header;
            FieldType = type;
            Mask = mask;
        }
    }
}
