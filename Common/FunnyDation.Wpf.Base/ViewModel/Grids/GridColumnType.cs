using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.Grids
{
    public enum GridColumnType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        String = 0,
        /// <summary>
        /// 整数
        /// </summary>
        Int,
        /// <summary>
        /// 浮点
        /// </summary>
        Decimal,
        /// <summary>
        /// 日期
        /// </summary>
        Date,
        /// <summary>
        /// 日期
        /// </summary>
        DateTime,
        /// <summary>
        /// 布尔
        /// </summary>
        Bool,
        /// <summary>
        /// 枚举
        /// </summary>
        Enum,
        /// <summary>
        /// 下拉
        /// </summary>
        Combo,

    }
}
