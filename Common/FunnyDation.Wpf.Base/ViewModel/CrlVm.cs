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
    public class CrlVm : VmLinkVm, ICrlVm
    {
        public CrlVm()
        {

        }

        public object CanClose { get; internal set; }
        public VmViewIdentity ViewIdentity { get; set; }
        public object VmData { get; set; }
        public object SourceVm { get; set; }

        public Action<ICrlVm> ActionClose()
        {
            throw new NotImplementedException();
        }

        public bool CancelClose()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
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

        internal void Close1()
        {
            throw new NotImplementedException();
        }
    }
}
