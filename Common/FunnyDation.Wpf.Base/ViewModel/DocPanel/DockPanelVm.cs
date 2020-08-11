using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;
using System.Windows.Input;
using FunnyDation.Wpf.Command;
using System.ComponentModel;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public class DockPanelVm : VmLinkVm, IMVVMDockingProperties
    {
        public DockPanelVm(string targetName)
        {
            this.TargetName = targetName;
            IsClosed = false;
            ID = Guid.NewGuid();
        }
        public string TemplateName { get; set; }
        public string TargetName { get; set; }
        public Guid ID { get; set; }
        public DockManagerVm DockManager { get; set; }
        public string Key
        {
            get
            {
                return CrlVm.ViewIdentity.Key;
            }
        }
         
        public FrameworkElement crl;
        public FrameworkElement Crl
        {
            get
            {
                return crl;
            }

            set
            {
                crl = value;
                SetProperty(ref crl, value);

            }
        }

        public CrlVm CrlVm
        {
            get
            {
                if (Crl != null && Crl.DataContext != null && Crl.DataContext is CrlVm)
                {
                    return (Crl.DataContext) as CrlVm;
                }
                return null;
            }
        }

        public string toolTip;
        public string ToolTip
        {
            get
            {
                return toolTip;
            }

            set
            {
                toolTip = value;
                SetProperty(ref toolTip, value);

            }
        }
        public string caption;
        public string Caption
        {
            get
            {
                return caption;
            }

            set
            {
                caption = value;
                SetProperty(ref caption, value);

            }
        }


        public bool isActive;
        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
                SetProperty(ref isActive, value);

            }
        }




        public bool isClosed;
        public bool IsClosed
        {
            get
            {
                return isClosed;
            }

            set
            {
                isClosed = value;
                SetProperty(ref isClosed, value);

            }
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

        public void Close()
        {
            if (CrlVm.CanClose != null)
            {
                CrlVm.Close1();
                return;
            }

            DockManager.ClosePanel(this);
        }



        public event EventHandler<CancelEventArgs> Closing;

        void OnClosing(CancelEventArgs arg)
        {
            if (Closing != null)
            {
                Closing(this, arg);
            }
        }


        public bool RemoveOnclose { get; set; }
    }
}
