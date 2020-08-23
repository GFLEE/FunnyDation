using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Charts
{
    public class ChartDataBase
    {
        public string PrimaryKey { get; set; }

        public ChartDataBase(string primaryKey, string x, string y)
        {
            PrimaryKey = primaryKey;
            this.X_String_Value = x;
            this.Y_String_Value = y;
        }
        public ChartDataBase(string primaryKey, DateTime x, string y)
        {
            PrimaryKey = primaryKey;
            this.X_Date_Value = x;
            this.Y_String_Value = y;
        }
        public ChartDataBase(string primaryKey, decimal x, decimal y)
        {
            PrimaryKey = primaryKey;
            this.X_Decimal_Value = x;
            this.Y_Decimal_Value = y;
        }

        //string
        public string X_String_Value { get; set; }
        public string Y_String_Value { get; set; }

        //decimal
        public decimal X_Decimal_Value { get; set; }
        public decimal Y_Decimal_Value { get; set; }

        //Date
        public DateTime X_Date_Value { get; set; }


    }
}
