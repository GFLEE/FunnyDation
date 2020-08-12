using DevExpress.Xpf.Bars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using DevExpress.Xpf.Core.Utils;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class ToolBarTrayVm : BindableBase
    {
        public ToolBarTrayVm()
        {

        }
        public ToolBarTrayVm(object hostVm) : this(hostVm, "default")
        {

        }
        public ToolBarTrayVm(object hostVm, string key)
        {
            HostVm = hostVm;
            this.Key = key;
            this.Bars = new ObservableCollection<ToolBarVm>();
            DefaultToolBar = this.AddChild("default");
            IsEnableToolBar = true;
        }

        private ToolBarVm AddChild(string key)
        {
            var barVm = new ToolBarVm(HostVm, this, Key);
            Bars.Add(barVm);
            return barVm;
        }

        /// <summary>
        /// 使能ToolBar
        /// </summary>
        public bool isEnableToolBar;
        public bool IsEnableToolBar
        {
            get
            {
                ToolBarOpacity = isEnableToolBar ? 1 : 0.4;
                return isEnableToolBar;
            }

            set
            {
                isEnableToolBar = value;
                SetProperty(ref isEnableToolBar, value);

            }
        }

        /// <summary>
        /// ToolBar 透明度
        /// </summary>
        public double toolBarOpacity;
        public double ToolBarOpacity
        {
            get
            {

                return toolBarOpacity;
            }

            set
            {
                toolBarOpacity = value;
                SetProperty(ref toolBarOpacity, value);

            }
        }
        public bool IsDefault
        {
            get
            {
                return Key == "default";
            }
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        public event EventHandler<NodeVmArgs> Clicked;
        internal void DoClicked(NodeVm vm)
        {
            if (Clicked != null && vm != null)
            {
                Clicked(this, new NodeVmArgs(vm));
            }


        } 
        public object HostVm { get; set; }
        public string Key { get; set; }
        public ObservableCollection<ToolBarVm> Bars { get; set; }
        public ToolBarVm DefaultToolBar { get; set; }


    }
}
