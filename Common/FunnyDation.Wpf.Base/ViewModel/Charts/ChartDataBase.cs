using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Charts
{
    public class ChartDataBase
    {
        public ChartDataBase(string primaryKey)
        {
            PrimaryKey = primaryKey;
        }

        public string PrimaryKey { get; set; }


    }
}
