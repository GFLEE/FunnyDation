using FunnyDation.Common.Context;
using FunnyDation.Common.Service;
using FunnyDation.Common.Service.Proxy;
using FunnyDation.WebApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyDation.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [DisableRequestSizeLimit]
    public class FDApiServices : Controller
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();
        private IFDServiceHelper _ServiceHelper;

        public FDApiServices(IFDServiceHelper serviceHelper, IFPContext fdContext)
        {
            _ServiceHelper = serviceHelper;
        }

        [Authorize]
        public ApiResult InvokeApi([FromBody] ServiceContract contract)
        {
            Stopwatch _sw = new Stopwatch();
            _sw.Start();
            var _rel = _ServiceHelper.InvokeApi(contract);
            _sw.Stop();
            if ((_sw.ElapsedMilliseconds / 1000) > 5)
            {
                logger.Error(string.Format("服务{0}：方法：{1}，调用时间超长：{2}，请检查！"
                    , contract.ServiceName, contract.MethodName, _sw.ElapsedMilliseconds));

            }
            return _rel;
        }

         
        public ApiResult InvokeApiNotAuthorize([FromBody] ServiceContract contract)
        { 
            return _ServiceHelper.InvokeApi(contract);
        } 

    }
}
