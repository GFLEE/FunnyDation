using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base
{
    public interface IVmLinkVm
    {
        VmViewIdentity ViewIdentity { get; set; }
        object VmData { get; set; }
        object SourceVm { get; set; }
    }
}
