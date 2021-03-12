using FunnyDation.Common;
using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyDation.WebApi.IDF4
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource()
                {
                    Name = FDConst.IS_Scope,
                    DisplayName = FDConst.IS_Scope,

                    Scopes = {
                        FDConst.IS_Scope
                    }


                }

            };

        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {

            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),

            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = FDConst.IS_Mvc_Client,
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = false, //权限确认页面
                    ClientSecrets =
                    {
                        new Secret(FDConst.IS_Mvc_ClientSecret.Sha256())
                    },
                    RedirectUris           = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" }, //注销后的去往地址
                    
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        FDConst.IS_Scope
                    },
                    AllowOfflineAccess = true   //如果要获取refresh_tokens ,必须把AllowOfflineAccess设置为true
                },
                new Client
                {
                      ClientId = FDConst.IS_Client,
                    //ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AccessTokenLifetime = 86400,

                    ClientSecrets =
                    {
                         new Secret(FDConst.IS_Wpf_ClientSecret.Sha256())
                    },

                    AllowOfflineAccess = true,   //如果要获取refresh_tokens ,必须把AllowOfflineAccess设置为true
                    //AbsoluteRefreshTokenLifetime = 32592000,
                    RefreshTokenExpiration = TokenExpiration.Sliding,  //刷新 access token时,将重新刷新refreshtoken的生命周期
                    SlidingRefreshTokenLifetime = 86400,  //refreshtoken的生命周期 

                   // RefreshTokenUsage = TokenUsage.ReUse,


                    AllowedScopes =
                    {
                        FDConst.IS_Scope,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                    },
                    //AlwaysSendClientClaims = true,
                    UpdateAccessTokenClaimsOnRefresh = true,
                }

    };
        }


    }
}
