using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyDation.WebApi.IDF4
{
    /// <summary>
    /// 将用户所需的所有可能声明放入cookie中是不切实际的，
    /// 因此IdentityServer定义了一个可扩展点，允许根据用户需要动态加载声明。
    /// 这个可扩展点是IProfileService开发人员通常可以实现此接口来访问包含用户身份数据的自定义数据库或API。
    /// </summary>
    public class FDProfileService : IProfileService
    {
        /// <summary>
        /// 期望为用户加载声明的API
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var _sub = context.Subject.Claims.Where(p => p.Type == "sub").FirstOrDefault();

            //判断是否有请求Claim信息
            if (context.RequestedClaimTypes.Any())
            {
                //var user = userService.GetByCode(context.Subject.Identity.Name);
                //if (user != null)
                //{
                //    //set issued claim to return 

                //}
            }
            else
            {

                var claims = context.Subject.Claims.ToList();
                context.IssuedClaims = claims;
            }

            return Task.CompletedTask;


        }
        /// <summary>
        /// 预期用于指示当前是否允许用户获取令牌的API。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task IsActiveAsync(IsActiveContext context)
        {

            context.IsActive = true;

            return Task.CompletedTask;
        }
    }
}
