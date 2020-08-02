﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using FunnyDation.Common;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace FunnyDation.Client.Wpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var win = Container.Resolve<MainWindow>();
            win.WindowState = WindowState.Maximized;
            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.Show();
            return win;
        }
        /// <summary>
        /// IOC
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {



           FDIoc.ServiceProvider = new UnityServiceLocatorAdapter(containerRegistry.GetContainer());
        }

        /// <summary>
        /// init Module
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            string mdPath = Path.Combine(@"C:\Users\Ricov\source\repos\FunnyDation\Assembly\", FDConst.ModulePath);
            var files = Directory.GetFiles(mdPath, "FunnyDation.Wpf.*.dll", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var dll = Assembly.LoadFile(file);
                var types = dll.GetTypes();
                var modules = types.Where(p => p.GetInterfaces().Contains(typeof(IModule)));

                foreach (var module in modules)
                {
                    moduleCatalog.AddModule(new ModuleInfo()
                    {
                        ModuleName = module.FullName,
                        ModuleType = module.AssemblyQualifiedName,
                        Ref = new Uri(file, UriKind.RelativeOrAbsolute).AbsoluteUri

                    });
                }
            }

            base.ConfigureModuleCatalog(moduleCatalog);

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void ConfigureViewModelLocator()
        {
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
            {
                var viewName = viewType.FullName;
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = $"{viewName}Vm, {viewAssemblyName}";
                return Type.GetType(viewModelName);
            });

            base.ConfigureViewModelLocator();

        }
    }
}