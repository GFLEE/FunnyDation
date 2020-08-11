using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public class DockPanelParam : BindableBase
    {
        public DockPanelParam()
        {

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
        public FrameworkElement Crl { get; set; }
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

        public bool IsActive
        {
            get; set;
        }


        public ICrlVm VmData { get; set; }

        public object SourceVm { get; set; }

        public string TargetName { get; set; }
        public string TemplateName { get; set; }

        public bool IsReBindData { get; set; }
        public EuProcessStyle ProcessStyle { get; set; }

    }
}
