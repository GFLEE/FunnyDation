using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Events;
using DevExpress.Xpf.Editors.Internal;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public class GridDataRow : BindableBase
    {
        /// <summary>
        /// Grid
        /// </summary>
        public GridVm Grid { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// 是否焦点
        /// </summary>
        public bool IsFocus { get; set; }
        /// <summary>
        /// 行数据
        /// </summary>
        public object Data { get; set; }


        public void Refresh(object data)
        {
            if (!object.Equals(Data, data))
            {
                Data = data;
            }
            RaisePropertyChanged("Data");
        }







    }
}
