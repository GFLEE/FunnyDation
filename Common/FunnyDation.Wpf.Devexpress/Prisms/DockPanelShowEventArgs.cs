using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Devexpress.Prisms
{
    public class DockPanelShowEventArgs
    {
        public DockPanelShowEventArgs(FrameworkElement crl, string caption, string toolTip)
        {
            this.Crl = crl;
            this.Caption = caption;
            this.ToolTip = toolTip;
            if (string.IsNullOrEmpty(toolTip))
            {
                ToolTip = caption;
            }


        }


        public FrameworkElement Crl { get; set; }
        public string Caption { get; set; }
        public string ToolTip { get; set; }
        public string TargetName { get; set; }
        public string TemplateName { get; set; }
        public EuProcessStyle ProcessStyle { get; set; }


    }
}
