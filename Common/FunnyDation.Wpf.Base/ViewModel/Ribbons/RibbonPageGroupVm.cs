using FunnyDation.Wpf.Base.ViewModel;
using FunnyDation.Wpf.Base.ViewModel.Ribbons;
using FunnyDation.Wpf.Base.ViewModel.ToolBars;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class RibbonPageGroupVm : ToolBarBaseVm
    {
        public RibbonPageGroupVm(RibbonPageVm ribbonPage, string key) : base(ribbonPage.Ribbon.HostVm, key)
        {
            RibbonPage = ribbonPage;
            Items = new ObservableCollection<object>();
        }

        public ObservableCollection<object> Items { get; set; }

        public RibbonPageVm ribbonPage;
        public RibbonPageVm RibbonPage
        {
            get
            {
                return ribbonPage;
            }

            set
            {
                ribbonPage = value;
                SetProperty(ref ribbonPage, value);

            }
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

        protected override void OnClicked(NodeVm vm)
        {
            this.RibbonPage.Ribbon.DoClicked(vm);

        }


        /// <summary>
        /// Add Button Base
        /// </summary>
        /// <param name="dataKey"></param>
        /// <param name="name"></param>
        /// <param name="glyphName"></param>
        /// <param name="largeGlyphName"></param>
        /// <param name="toolTip"></param>
        /// <param name="visibility"></param>
        /// <returns></returns>
        public BarButtonVm AddButton1(string dataKey, string name, string glyphName, string largeGlyphName
            , string toolTip = null, Visibility visibility = Visibility.Visible)
        {
            BarButtonVm barButtonVm = new BarButtonVm(toolTip, glyphName, visibility)
            {
                DataKey = dataKey,
                Name = name,
                LargeGlyphName = largeGlyphName,
            };
            //Items.Add(barButtonVm);
            AddChild(barButtonVm);
            return barButtonVm;
        }
        /// <summary>
        /// Large Button
        /// </summary>
        /// <param name="dataKey"></param>
        /// <param name="name"></param>
        /// <param name="glyphName"></param>
        /// <param name="toolTip"></param>
        /// <returns></returns>
        public BarButtonVm AddButtonOfLarge(string dataKey, string name, string glyphName, string toolTip = null)
        {
            return AddButton1(dataKey, name, null, glyphName, toolTip);
        }
        /// <summary>
        /// Small Button
        /// </summary>
        /// <param name="dataKey"></param>
        /// <param name="name"></param>
        /// <param name="glyphName"></param>
        /// <param name="toolTip"></param>
        /// <returns></returns>
        public BarButtonVm AddButtonOfSmall(string dataKey, string name, string glyphName, string toolTip = null)
        {
            return AddButton1(dataKey, name, glyphName, null, toolTip);
        }
        /// <summary>
        /// 添加按钮组
        /// </summary>
        /// <returns></returns>
        public BarButtonGroupVm AddButtonGroup()
        {
            BarButtonGroupVm item = new BarButtonGroupVm(this);
            Items.Add(item);
            return item;
        }

        protected override void OnAfterAddChild(NodeVm node)
        {
            Items.Add(node);
        }


        internal void RemoveFromItems(NodeVm node)
        {
            Items.Remove(node);
        }
    }
}
