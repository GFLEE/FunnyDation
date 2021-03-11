using FunnyDation.Common.Service;
using FunnyDation.Common.Service.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyDation.WebApi.Service
{
    /// <summary>
    /// 调用api
    /// </summary>
    public interface IFDServiceHelper
    {
        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        ApiResult InvokeApi(ServiceContract contract);
    }
}
