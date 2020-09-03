using FunnyDation.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.ViewModel.ToolBars
{
    /// <summary>
    /// ComboBox
    /// </summary>
    public class BarComboVm : BarItemVm
    {
        public BarComboVm(string toolTip) : base(toolTip)
        {
            this.TemplateName = "TemplateCombo";
        }

        public BarComboVm(IEnumerable list, string displayMember = null, string valueMember = null, Visibility visible = Visibility.Visible)
        : this(list, 0, "", displayMember, valueMember, visible)
        {
        }

        public BarComboVm(IEnumerable list, int width, string nullText, string displayMember = null, string valueMember = null, Visibility visible = Visibility.Visible) : this("")
        {
            ItemSource = new ObservableCollection<object>(list.Cast<object>().ToList());
            DisplayMember = displayMember;
            ValueMember = valueMember;
            Width = width;
            ToolTip = nullText;
            NullText = nullText;
            this.Visibility = visible;
            if (this.Width < 50)
            {
                this.Width = 50;
            }
        }

        /// <summary>
        /// 数据源
        /// </summary>
        public ObservableCollection<object> ItemSource { get; set; }
        /// <summary>
        /// 值member
        /// </summary>
        public string ValueMember { get; set; }
        /// <summary>
        /// 显示member
        /// </summary>
        public string DisplayMember { get; set; }

        /// <summary>
        /// 选中Item
        /// </summary>
        object selectItem = null;
        public object SelectedItem
        {
            get
            {
                return selectItem;
            }
            set
            {
                if (object.Equals(selectItem, value))
                {
                    return;
                }
                selectItem = value;
                OnSelectedItemChanged();
                SetProperty(ref selectItem, value);

            }
        }

        /// <summary>
        /// Clear事件
        /// </summary>
        public CommandInterface commandClear;
        public CommandInterface CommandClear
        {
            get
            {
                if (commandClear != null)
                {
                    return commandClear;
                }
                commandClear = new CommandInterface((x) =>
                {
                    try
                    {
                        SelectedItem = null;
                    }
                    catch (Exception ex)
                    {

                    }
                }, (x) => true);
                return commandClear;
            }
        }


        /// <summary>
        /// 选中改变事件
        /// </summary>
        public event EventHandler<Param1Args<Object>> SelectedItemChanged;
        private void OnSelectedItemChanged()
        {
            if (SelectedItemChanged != null)
            {
                SelectedItemChanged(this, new Param1Args<object>(SelectedItem));
            }

        }

        /// <summary>
        /// 控件宽度
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
        public Visibility visibility = System.Windows.Visibility.Visible;
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


    }
}
