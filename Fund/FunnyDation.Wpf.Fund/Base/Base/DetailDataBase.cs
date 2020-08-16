using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Ranking.Base
{
    public class WorthBase
    {
        public WorthBase(DateTime date, string unit_worth, string rate)
        {
            this.Date = date;
            this.Unit_worth = unit_worth;
            this.Rate = rate;
        }
        public DateTime Date { get; set; }
        public string Unit_worth { get; set; }
        public string Rate { get; set; }

    }
    public class DetailDataBase
    {
        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public decimal netWorth { get; set; }
        public decimal expectWorth { get; set; }
        public decimal totalWorth { get; set; }
        public string expectGrowth { get; set; }
        public string dayGrowth { get; set; }
        public string lastWeekGrowth { get; set; }
        public string lastMonthGrowth { get; set; }
        public string lastThreeMonthsGrowth { get; set; }
        public string lastSixMonthsGrowth { get; set; }
        public string lastYearGrowth { get; set; }
        public decimal buyMin { get; set; }
        public decimal buySourceRate { get; set; }
        public decimal buyRate { get; set; }
        public string manager { get; set; }
        public string fundScale { get; set; }
        public string worthDate { get; set; }
        public string expectWorthDate { get; set; }
        public List<List<string>> netWorthData { get; set; }
        public decimal millionCopiesIncome { get; set; }
        public List<List<string>> millionCopiesIncomeData { get; set; }
        public string millionCopiesIncomeDate { get; set; }
        public decimal sevenDaysYearIncome { get; set; }
        public List<List<string>> sevenDaysYearIncomeData { get; set; }


    }
}
