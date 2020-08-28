using FunnyDation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    public class BarCheckVm : BarItemVm
    {
        public BarCheckVm(string dataKey, string text, string toolTip) : base(toolTip)
        {
            this.TemplateName = "TemplateTextEdit";
            this.Text = text;
        }


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

        public bool isCheck;
        public bool IsCheck
        {
            get
            {
                return isCheck;
            }

            set
            {
                isCheck = value;
                OnChecked();
                SetProperty(ref isCheck, value);

            }
        }

        public event EventHandler<Param1Args<object>> OnCheckedChanged;
        private void OnChecked()
        {
            OnCheckedChanged(this, new Param1Args<object>(IsCheck));

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



    }
}
