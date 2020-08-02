using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

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
            var crl = FDIoc.ServiceLocator.GetInstance(type);
            return crl;

        }

        public static object Create(Type type, Action<object> action)
        {
            if (type == null)
            {
                return null;
            }
            var crl = FDIoc.ServiceLocator.GetInstance(type) as FrameworkElement;
            action?.Invoke(crl.DataContext);
            return crl;

        }

    }
}
