using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Client.Wpf
{
    public class ClientUtility
    {

        /// <summary>
        /// Retrun gly path
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetGlyphPath(string name)
        {
            return string.Format(@"/FunnyDation.Client.Wpf;component/Images/", name);
        }
    }
}
