using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using FunnyDation.Common;
using FunnyDation.Common.Ioc;
using FunnyDation.Wpf;
using FunnyDation.Wpf.Web;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace FunnyDation.Client.Wpf
{
    /// <summary>
    /// App
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
            containerRegistry.Register<IRESTService, RESTService>();


            FDIoc.ServiceProvider = new UnityServiceLocatorAdapter(containerRegistry.GetContainer());
        }

        /// <summary>
        /// init Module
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            string mdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FDConst.ModulePath);
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

        /// <summary>
        /// OnStartup
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        /// <summary>
        /// Initialize
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }


        /// <summary>
        /// ViewModel  Locator
        /// </summary>
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
