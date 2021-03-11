using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service
{
    public class ApiResult
    {
        /// <summary>
        /// 结果
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

    }
}
