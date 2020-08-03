using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Ioc
{
    /// <summary>
    /// Global Service Provider
    /// </summary>
    public class FDIoc
    {
        public static IServiceProvider ServiceProvider { get; set; }
        //public static IServiceLocator ServiceLocator { get; set; }

    } 
}
