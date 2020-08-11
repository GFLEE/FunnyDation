using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel
{
    public interface ICrlVm : IVmLinkVm
    {
        /// <summary>
        /// Control Loaded
        /// </summary>
        void OnControlLoaded();
        /// <summary>
        /// 注册关闭时间
        /// </summary>
        /// <returns></returns>
        Action<ICrlVm> ActionClose { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool CancelClose();

        /// <summary>
        /// 关闭容器
        /// </summary>
        void Close();

    }
}
