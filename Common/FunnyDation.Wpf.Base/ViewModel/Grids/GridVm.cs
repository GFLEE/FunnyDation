using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using FunnyDation.Wpf.Command;
using FunnyDation.Wpf.Selectors;
using Prism.Mvvm;
using static FunnyDation.Wpf.Base.VmLinkVm;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridVm : GridBaseVm
    {

        public GridVm()
        {

        }

        static GridVm()
        {
            var finder = new FakeFinder(FindOfFakeFinder, CheckOfFakeFinder);
            VmLinkVm.RegisterFindFakeSourceVm(finder);
        }

        static object FindOfFakeFinder(object sourceVm)
        {
            if (!CheckOfFakeFinder(sourceVm))
            {
                throw new Exception();
            }
            var rowVm = sourceVm as GridDataRow;
            if (rowVm != null)
            {
                return rowVm.Grid;
            }
            var gridVm = sourceVm as GridVm;
            if (gridVm != null)
            {
                return gridVm.HostVm;
            }
            throw new ArgumentException();
        }

        static bool CheckOfFakeFinder(object sourceVm)
        {
            if (sourceVm == null)
            {
                return false;
            }
            var type = sourceVm.GetType();
            if (sourceVm is GridDataRow || sourceVm is GridVm)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 数据源
        /// </summary>
        List<GridDataRow> dataSource { get; set; }

        public GridVm(object hostVm)
        {
            this.HostVm = hostVm;
            Option = new GridOption();
            dataSource = null;
            Columns = new ObservableCollection<GridColumnVm>();
            SelectedItems = new ObservableCollection<GridDataRow>();
        }





        public GridOption Option { get; set; }
        public ObservableCollection<GridColumnVm> Columns { get; set; }
        public ObservableCollection<GridDataRow> SelectedItems { get; set; }
        /// <summary>
        /// 是否包含在视图中的方法
        /// </summary>
        public Predicate<GridDataRow> Filter { get; set; }

        /// <summary>
        /// 获取或设置用于数据集合排序的属性表达式
        /// </summary>
        public string Sort { get; set; }


        /// <summary>
        /// 表选中
        /// </summary>
        public GridDataRow selectedItem;
        public GridDataRow SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                selectedItem = value;
                SetProperty(ref selectedItem, value);
                SelectedItemChanged?.Invoke(selectedItem);

            }
        }
        /// <summary>
        /// 显示CheckBox列
        /// </summary>
        public bool isShowCheckBox = false;
        public bool IsShowCheckBox
        {
            get
            {
                return isShowCheckBox;
            }

            set
            {
                isShowCheckBox = value;
                SetProperty(ref isShowCheckBox, value);

            }
        }

        /// <summary>
        /// 自动宽度（表格）
        /// </summary>
        public bool autoWidth = true;
        public bool AutoWidth
        {
            get
            {
                return autoWidth;
            }

            set
            {
                autoWidth = value;
                SetProperty(ref autoWidth, value);

            }
        }

        /// <summary>
        /// 表可见
        /// </summary>
        public bool isVisiable = true;
        public bool IsVisiable
        {
            get
            {
                return isVisiable;
            }

            set
            {
                isVisiable = value;
                SetProperty(ref isVisiable, value);

            }
        }

        /// <summary>
        /// 获取或设置数据源加载的委托
        /// </summary>
        public Func<List<object>> LoadDataSource { get; set; }

        /// <summary>
        /// 界面数据源
        /// </summary>
        public ObservableCollection<GridDataRow> datas = null;
        public ObservableCollection<GridDataRow> Datas
        {
            get
            {
                if (datas == null)
                {
                    datas = new ObservableCollection<GridDataRow>();
                }
                return datas;
            }

            set
            {
                datas = value;
                SetProperty(ref datas, value);

            }
        }

        public void RemoveGridDatas()
        {
            this.Datas.Clear();
        }

        /// <summary>
        /// 刷新数据，不加载数据
        /// </summary>
        public void Refresh()
        {
            Reload();
            Datas.Clear();
            if (dataSource == null)
            {
                return;
            }
            dataSource.ForEach(row =>
            {
                if (Filter == null || Filter(row))
                {
                    Datas.Add(row);
                }
            });
        }

        /// <summary>
        /// 重载数据源
        /// </summary>
        public virtual void Reload()
        {
            if (LoadDataSource == null)
            {
                dataSource = null;
                return;
            }
            dataSource = LoadDataSource().Select(p => new GridDataRow()
            {
                Grid = this,
                Data = p
            }).ToList();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridDataRow AddData(object data)
        {
            if (data == null)
            {
                throw new ArgumentException("data");
            }
            if (dataSource == null)
            {
                throw new ArgumentException("dataSource");

            }
            var row = new GridDataRow()
            {
                Grid = this,
                Data = data
            };
            dataSource.Add(row);
            Datas.Add(row);
            if (SelectedItem == null)
            {
                SelectedItem = row;
            }
            else
            {
                var index = Datas.IndexOf(SelectedItem);
                if (index.Equals(-1))
                {
                    SelectedItem = row;
                }
                else
                {
                    SelectedItem = row;
                }
            }

            return row;
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="row"></param>
        public void Remove(GridDataRow row)
        {
            if (dataSource != null)
            {
                dataSource.Remove(row);
            }
            Datas.Remove(row);
            if (object.Equals(SelectedItem, row))
            {
                selectedItem = null;
            }
        }

        ICommand commandDoubleClick;
        public ICommand CommandDoubleClick
        {
            get
            {
                if (commandDoubleClick == null)
                {
                    commandDoubleClick = new RelayCommand(() =>
                    {
                        var item = this.SelectedItem;
                        if (DoubleClick != null)
                        {
                            DoubleClick(item);
                        }
                    });
                }
                return commandDoubleClick;
            }
        }



        /// <summary> 
        /// 宿主
        /// </summary>
        public object HostVm { get; set; }
        public Action<GridDataRow> DoubleClick { get; set; }
        public Action<object> SelectedItemChanged { get; set; }
    }
}
