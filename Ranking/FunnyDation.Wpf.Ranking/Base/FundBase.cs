using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Ranking.Base
{
    public class FundBase
    {
        public FundBase()
        {

        }

        public string code { get; set; }
        public string name { get; set; }
        public decimal netWorth { get; set; }
        public decimal expectWorth { get; set; }
        public string expectGrowth { get; set; }
        public string dayGrowth { get; set; }
        public string lastWeekGrowth { get; set; }
        public string lastMonthGrowth { get; set; }
        public string lastThreeMonthsGrowth { get; set; }
        public string lastSixMonthsGrowth { get; set; }
        public string lastYearGrowth { get; set; } 
        public string netWorthDate { get; set; }
        public string expectWorthDate { get; set; }
    }
}
