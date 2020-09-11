using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Fund
{
    public class MyUtility
    {


        public static string GetGlyphPath(string name)
        {
            var path = string.Format(@"/FunnyDation.Client.Wpf;component/Images/{0}", name);
            return path;
        }


    }
}
