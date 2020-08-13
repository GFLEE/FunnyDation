using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public abstract class ToolBarBaseVm : NodeContainerVm
    {
        public ToolBarBaseVm(object hostVm, string key) : base(hostVm)
        {
            this.Key = key;

        }

        public ToolBarBaseVm AddButton(string toolTip, string glyphName, Visibility visibility = Visibility.Visible, bool IsShowBtnText = true)
        {
            var item = new BarButtonVm(toolTip, glyphName, visibility);
            if (!IsShowBtnText)
            {
                item.BtnText = null;
            }
            AddChild(item);
            return this;
        }









        public string Key { get; set; }
        protected abstract override void OnClicked(NodeVm vm);
    }
}
