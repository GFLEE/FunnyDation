using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace FunnyDation.WebApi.IDF4
{
    public class FDUserValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            if (false)  //验证成功
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "invalid grant");
                return Task.FromResult(0);

            }

            var _rel = new GrantValidationResult(new Dictionary<string, object>()
            {
                //需要返回的Claim ,GetUserClaim(context);
            });
            context.Result = _rel;
            //认证成功
            return Task.FromResult(1);
        }

        private Claim[] GetUserClaim(ResourceOwnerPasswordValidationContext context)
        {
            var claims = new Claim[9];

            claims[0] = new Claim(JwtClaimTypes.Id, context.UserName);
            claims[1] = new Claim(JwtClaimTypes.Name, context.UserName);
            claims[2] = new Claim(JwtClaimTypes.NickName, context.UserName);
            claims[3] = new Claim("Passwd", context.Password);

            return claims;

        }
    }
}
