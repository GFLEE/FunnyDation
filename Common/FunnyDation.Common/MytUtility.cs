using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Common
{
    public class MytUtility
    {

        /// <summary>
        /// Retrun gly path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetGlyphPath(string name)
        {
            return string.Format("/FunnyDation.Client.Wpf;component/Images/{0}", name);
        }
    }
}
