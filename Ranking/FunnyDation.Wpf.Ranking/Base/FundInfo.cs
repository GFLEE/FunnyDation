using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Ranking.Base
{
    public class FundInfo
    {
        public FundInfo()
        {

        }
        public int code { get; set; }

        public List<FundBase> data { get; set; }

        public string message { get; set; }

        public string meta { get; set; }


    }
}
