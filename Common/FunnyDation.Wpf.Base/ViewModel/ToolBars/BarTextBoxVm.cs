using FunnyDation.Wpf.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class BarTextBoxVm : BarItemVm
    {
        public BarTextBoxVm(string text, string toolTip, int width, string visibility = "Visible") : base(toolTip)
        {
            this.Text = text;
            this.NullText = toolTip;
            this.Width = width;
            this.TemplateName = "TemplateTextBox";
            this.Visibility = visibility;

        }

        /// <summary>
        /// 内容
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
        /// NullText
        /// </summary>
        public string nullText;
        public string NullText
        {
            get
            {
                return nullText;
            }

            set
            {
                nullText = value;
                SetProperty(ref nullText, value);

            }
        }
        /// <summary>
        /// Width
        /// </summary>
        public int width;
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
                SetProperty(ref width, value);

            }
        }
        /// <summary>
        /// Visibility
        /// </summary>
        public string visibility = "Visible";
        public string Visibility
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

        ICommand commandEditValueChanged;
        public ICommand CommandEditValueChanged
        {
            get
            {
                if (commandEditValueChanged == null)
                {
                    commandEditValueChanged = new RelayCommand((e) =>
                    {
                        if (TextValueChanged != null)
                        {
                            TextValueChanged(e);
                        }
                    });
                }

                return commandEditValueChanged;
            }
        }

        public Action<object> TextValueChanged { get; set; }
    }
}
