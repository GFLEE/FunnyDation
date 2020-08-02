using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common
{
    public class CrlFactory
    {
        public static object Create<T>()
        {
            //if (T == null)
            //{
            //    return null;
            //}

            return FDIoc.ServiceLocator.GetInstance<T>();
        }

        public static object Create(Type type)
        {
            if (type == null)
            {
                return null;
            }

            return FDIoc.ServiceLocator.GetInstance(type);

        }

    }
}
