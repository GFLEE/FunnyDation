using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base
{
    public class CrlVm : BindableBase
    {
        public CrlVm()
        {

        }
        public virtual void Init()
        {
            OnInitComplete();
        }
        public virtual void OnInitComplete()
        {

        }

    }
}
