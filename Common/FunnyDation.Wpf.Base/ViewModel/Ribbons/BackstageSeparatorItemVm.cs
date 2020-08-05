using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class BackstageSeparatorItemVm
    {
        public string Content { get; set; }
        public object PanelVm { get; set; }
        public ICommand Cmd { get; set; }

        public BackstageSeparatorItemVm()
        {

        }
    }
}
