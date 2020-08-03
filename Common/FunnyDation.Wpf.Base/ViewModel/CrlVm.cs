using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FunnyDation.Wpf.Base.ViewModel;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base
{
    public class CrlVm : BindableBase, ICrlVm
    {
        public CrlVm()
        {

        }
        public void Init()
        {
           
            OnInitComplete();
        }
        public void Init(Action<CrlVm> preInit)
        {
            if (preInit != null)
            {
                preInit(this);
            }
            OnInitComplete();
        }

        public virtual void OnControlLoaded()
        {




        }

        public virtual void OnInitComplete()
        {

        }

    }
}
