using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FunnyDation.Wpf.Base.ViewModel;
using FunnyDation.Wpf.Command;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base
{
    public class CrlVm : VmLinkVm, ICrlVm
    {
        public CrlVm()
        {

        }



        public Action<ICrlVm> ActionClose { get; set; }
        public bool isClosing = false;
        bool cancelClose = true; 

        public bool CancelClose()
        {
            PopCloseConfirm();
            return CanClose != true;
        }

        public void Close()
        {
            Close1();
        }

        public bool? CanClose { get; set; }
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
        internal void Close1()
        {
            if (CanClose != true)
            {

            }

            if (CanClose == true)
            {
                Closing();
                ActionClose?.Invoke(this);
            }


        }
        public virtual void OnControlLoaded()
        {




        }

        protected virtual void Closing()
        {


        }

        ICommand commandClose;
        public ICommand CommandClose
        {
            get
            {
                if (commandClose == null)
                {
                    commandClose = new RelayCommand(() =>
                    {
                        Close();
                    });
                }

                return commandClose;
            }
        }



        protected virtual void PopCloseConfirm()
        {
            CanClose = true;
        }

        protected void CloseConfirmCallBack(bool confirmed)
        {
            cancelClose = !confirmed;
            AsyncClose();
        }


        async void AsyncClose()
        {
            await Task.Delay(1);
            Close();
        }

        public virtual void OnInitComplete()
        {

        }


    }
}
