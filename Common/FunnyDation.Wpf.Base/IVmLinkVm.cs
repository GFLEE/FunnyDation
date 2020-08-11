using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base
{
    public interface IVmLinkVm
    {
        object VmData { get; set; }

        object SourceVm { get; set; }
    }
}
