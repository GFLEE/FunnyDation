using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public enum EuProcessStyle
    {
        /// <summary>
        /// 激活
        /// </summary>
        Active=0,
        /// <summary>
        /// 更新Vm
        /// </summary>
        UpdateVm,
        /// <summary>
        /// 更新VmData
        /// </summary>
        UpdateVmData,
        /// <summary>
        /// 关闭并更新
        /// </summary>
        CloseAndNew,
        /// <summary>
        /// 新窗口
        /// </summary>
        New,
        /// <summary>
        /// 打开或新建
        /// </summary>
        Open


    }
}
