using System;
using System.Collections.Generic;
using System.Text;
using FunnyDation.Common.Ioc;
//using Microsoft.Extensions.DependencyInjection;

namespace FunnyDation.Common.Service
{
    /// <summary>
    /// Interface
    /// </summary>
    public class IocService
    {
        //public static TService Resolve<TService>()
        //{
        //    if (FDIoc.ServiceProvider == null)
        //    {
        //        return default;
        //    }

        //    return FDIoc.ServiceProvider.GetService<TService>();
        //}

        public static object Resolve(Type type)
        {
            if (FDIoc.ServiceProvider == null)
            {
                return null;
            }

            return FDIoc.ServiceProvider.GetService(type);
        }


    }
}
