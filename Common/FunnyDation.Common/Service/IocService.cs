using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service
{
    /// <summary>
    /// Interface
    /// </summary>
    public class IocService
    {
        public static TService Create<TService>()
        {
            
            return FDIoc.ServiceLocator.GetInstance<TService>();
        }




    }
}
