using CommonServiceLocator;
using FunnyDation.Common;
using FunnyDation.Wpf.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace FunnyDation.Wpf.Base
{
    public class CrlFactory
    {
        public static T Create<T>() where T : class
        {
            var res = ServiceLocator.Current.GetInstance<T>();

            var crl = res as FrameworkElement;
            var crlVm = crl.DataContext as CrlVm;
            if (crlVm != null)
            {
                crl.Loaded += Crl_Loaded;

            }
            return res;
        }
        public static object Create(Type type)
        {
            if (type == null)
            {
                return null;
            }
            var crl = ServiceLocator.Current.GetInstance(type);
            return crl;

        }

        public static object Create(Type type, Action<object> init)
        {
            if (type == null)
            {
                return null;
            }
            var crl = ServiceLocator.Current.GetInstance(type) as FrameworkElement;

            var crlVm = crl.DataContext as CrlVm;
            if (crlVm != null)
            {
                if (init != null)
                {
                    crlVm.Init(init);
                }
                else
                {
                    crlVm.Init();
                }
            }



            crl.Loaded += Crl_Loaded;

            return crl;

        }

        private static void Crl_Loaded(object sender, RoutedEventArgs e)
        {
            var crl = sender as FrameworkElement;
            crl.Loaded -= Crl_Loaded;
            var crlVm = crl.DataContext as ICrlVm;
            if (crlVm != null)
            {
                crlVm.OnControlLoaded();
            }

        }
    }
}
