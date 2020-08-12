using DevExpress.Mvvm.UI;
using FunnyDation.Wpf.Base.ViewModel;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace FunnyDation.Wpf.Base.Ribbons
{
    public class RibbonVm : BindableBase
    {
        public RibbonVm() : this(null)
        {

        }

        public RibbonVm(object hostVm)
        {
            this.HostVm = hostVm;
            this.DefaultPageCategoryVm = new RibbonDefaultPageCategoryVm(this) { Caption = "开始" };
            PageCategories = new ObservableCollection<RibbonPageCategoryVm>();
            PageCategories.Add(DefaultPageCategoryVm);
            BackstageItems = new ObservableCollection<object>();
            IsEnabledOfPageCategory = true;
            IsShowTabMenu = true;
        }

        public bool isEnabledOfPageCategory;
        public bool IsEnabledOfPageCategory
        {
            get
            {
                return isEnabledOfPageCategory;
            }

            set
            {
                if (isEnabledOfPageCategory == value)
                {
                    return;
                }
                isEnabledOfPageCategory = value;
                SetProperty(ref isEnabledOfPageCategory, value);
                DefaultPageCategoryVm.IsEnabled = isEnabledOfPageCategory;
                foreach (var item in PageCategories)
                {
                    item.isEnabled = true;
                }
            }
        }

        public RibbonPageCategoryVm AddPageCategory(string caption)
        {
            RibbonPageCategoryVm categoryVm = new RibbonPageCategoryVm(this) { Caption = caption };
            PageCategories.Add(categoryVm);
            return categoryVm;
        }

        public event EventHandler<NodeVmArgs> Clicked;
        internal void DoClicked(NodeVm vm)
        {
            if (Clicked != null && vm != null)
            {
                Clicked(this, new NodeVmArgs(vm));
            }
        }


        /// <summary>
        /// 整体导航页面
        /// </summary>
        public object ApplicationBtnPanelVm { get; set; }

        public ObservableCollection<object> BackstageItems { get; set; }
        public ObservableCollection<RibbonPageCategoryVm> PageCategories { get; set; }
        public RibbonDefaultPageCategoryVm DefaultPageCategoryVm { get; private set; }
        public object HostVm { get; private set; }

        /// <summary>
        /// 显示Back Tab
        /// </summary>
        public bool isShowTabMenu;
        public bool IsShowTabMenu
        {
            get
            {
                return isShowTabMenu;
            }

            set
            {
                isShowTabMenu = value;
                SetProperty(ref isShowTabMenu, value);

            }
        }

        /// <summary>
        /// 隐藏
        /// </summary>
        public bool visiable;
        public bool Visiable
        {
            get
            {
                return visiable;
            }

            set
            {
                visiable = value;
                SetProperty(ref visiable, value);

            }
        }
    }
}
