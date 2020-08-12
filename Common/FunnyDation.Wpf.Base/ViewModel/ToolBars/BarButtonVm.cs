using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class BarButtonVm : BarItemVm
    { 
        public BarButtonVm(string toolTip, string glyphName) : base(toolTip)
        {
            this.TemplateName = "TemplateButton";
            this.GlyphName = glyphName;
        }

        public BarButtonVm(string toolTip, string glyphName, Visibility visibility) : base(toolTip)
        {
            this.TemplateName = "TemplateButton";
            this.GlyphName = glyphName;
            this.Visibility = visibility;
            this.BtnText = toolTip;
            if (ToolTip != null)
            {
                ToolTip = ToolTip.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
            }
        }


        /// <summary>
        /// 图片路径
        /// </summary>
        public string largeGlyphName;
        public string LargeGlyphName
        {
            get
            {
                return largeGlyphName;
            }

            set
            {
                largeGlyphName = value;
                SetProperty(ref largeGlyphName, value);

            }
        }

        /// <summary>
        /// 显示隐藏
        /// </summary>
        public Visibility visibility = Visibility.Visible;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }

            set
            {
                visibility = value;
                SetProperty(ref visibility, value);

            }
        }

        /// <summary>
        /// 显示与否
        /// </summary>
        public bool isEnableBtn;
        public bool IsEnableBtn
        {
            get
            {
                return isEnableBtn;
            }

            set
            {
                isEnableBtn = value;
                SetProperty(ref isEnableBtn, value);

            }
        }

        /// <summary>
        /// Button Text
        /// </summary>
        public string btnText;
        public string BtnText
        {
            get
            {
                return btnText;
            }

            set
            {
                btnText = value;
                SetProperty(ref btnText, value);

            }
        }
     
    }
}
