using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class BarTextBlockVm : BarItemVm
    {
        public BarTextBlockVm(string text, string fontColor) : base(null)
        {
            this.Text = text;
            this.FontColor = ColorConvert(fontColor);
            this.TemplateName = "TemplateTextBlock";

        }

        /// <summary>
        /// ColorConvert
        /// </summary>
        /// <param name="strColor"></param>
        /// <returns></returns>
        public string ColorConvert(string strColor)
        {
            Color color = new Color();
            try
            {
                color = (Color)ColorConverter.ConvertFromString(strColor);
            }
            catch
            {
                return ColorConvert("Black");
            }

            return color.ToString();
        }

        /// <summary>
        /// 文字
        /// </summary>
        public string text;
        public string Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
                SetProperty(ref text, value);

            }
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public string fontColor;
        public string FontColor
        {
            get
            {
                return fontColor;
            }

            set
            {
                fontColor = value;
                SetProperty(ref fontColor, value);

            }
        }

    }
}
