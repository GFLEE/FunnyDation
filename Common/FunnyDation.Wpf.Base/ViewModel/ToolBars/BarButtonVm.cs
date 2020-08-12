using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class BarButtonVm
    {
        private string toolTip;
        private string glyphName;
        private Visibility visibility;

        public BarButtonVm()
        {

        }

        public BarButtonVm(string toolTip, string glyphName, Visibility visibility)
        {
            this.toolTip = toolTip;
            this.glyphName = glyphName;
            this.visibility = visibility;
        }

        public string DataKey { get; internal set; }
        public string Name { get; internal set; }
        public string LargeGlyphName { get; internal set; }
    }
}
