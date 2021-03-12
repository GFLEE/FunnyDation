using Autofac;
using FunnyDation.Common.Service.AppSetting;
using FunnyDation.WebApi.IDF4;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using NLog;
using FunnyDation.Common;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Autofac.Extras.DynamicProxy;
using FunnyDation.Common.Ioc;
using Autofac.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace FunnyDation.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FunnyDation.WebApi", Version = "v1" });
            //});
            AppSettingService _setting = new AppSettingService(Configuration);

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddResourceOwnerValidator<FDUserValidator>()
                .AddProfileService<FDProfileService>();

            services.AddMvcCore().AddAuthorization();
            services.AddMvc();
            //services.AddNewtonsoftJson(options =>
            //    {
            //        //忽略循环引用
            //        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //        //使用驼峰 首字母小写
            //        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        //设置时间格式
            //        options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";

            //    }); ;

            services.AddAuthentication("Bearer")
                //.AddCookie("cookies")
                .AddJwtBearer("Bearer", option =>
                {
                    option.Authority = _setting.GetAppSetting(FDConst.AppSettings_AuthAddress);
                    option.RequireHttpsMetadata = false;
                    option.Audience = FDConst.IS_Scope;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromSeconds(30),
                        RequireExpirationTime = true
                    };

                });



        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            
            #region AutoFac IOC容器
            try
            {
                #region SingleInstance
                //无接口注入单例
                //var assemblyCore = Assembly.Load("FunnyDation.WebApi");
                //var assemblyCommon = Assembly.Load("FunnyDation.Common");
                //builder.RegisterAssemblyTypes(assemblyCore, assemblyCommon)
                //.Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                //.SingleInstance();

                //有接口注入单例
                //builder.RegisterAssemblyTypes(assemblyCore, assemblyCommon)
                //.Where(t => t.GetCustomAttribute<SingleInstanceAttribute>() != null)
                //.AsImplementedInterfaces()
                //.SingleInstance();
                #endregion

                #region Aop

                #endregion

                #region Repository
                var assemblyRepository = Assembly.Load("FunnyDation.Repository.Fund");
                builder.RegisterAssemblyTypes(assemblyRepository)
                .AsImplementedInterfaces()
                .InstancePerDependency();
                #endregion

                #region Service
                var assemblyServices = Assembly.Load("FunnyDation.Service.Fund");
                builder.RegisterAssemblyTypes(assemblyServices)
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .EnableInterfaceInterceptors()
               /* .InterceptedBy(interceptorServiceTypes.ToArray())*/; //使用特性的方式管理事务

                builder.RegisterBuildCallback((container) =>
                {
                    FDIoc.ServiceProvider = new AutofacServiceProvider(container);
                });
                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
            #endregion
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggingBuilder loggerFactory)
        {
            loggerFactory.AddNLog();
            loggerFactory.AddConsole();
            LogManager.LoadConfiguration("NLog.config");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }
            app.UseIdentityServer();

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseMvc((routes =>
            //{

            //}));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
