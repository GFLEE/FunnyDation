﻿using FunnyDation.Wpf.Base.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyDation.Wpf;
using FunnyDation.Wpf.Base;
using Prism.Mvvm;
using System.IO;
using FunnyDation.Common;
using System.Reflection;
using Prism.Commands;
using FunnyDation.Wpf.Base.ViewModel.DocPanel;
using System.Collections.ObjectModel;
using Prism.Modularity;
using FunnyDation.Common.Helper;
using Prism.Events;
using FunnyDation.Wpf.Devexpress.Prisms;
using CommonServiceLocator;
using System.Windows.Controls;
using FunnyDation.Wpf.Base.Ribbons;

namespace FunnyDation.Client.Wpf
{
    public class MainWindowVm : CrlVm
    {
        public MainWindowVm()
        {
            EventAggregator = ServiceLocator.Current.TryResolve<IEventAggregator>();
            DockManager = new DockManagerVm();
            Ribbon = new RibbonVm(this);
            Ribbon.Visiable = true;
            Ribbon.Clicked += Ribbon_Clicked; 
            Dictionary<string, string> menus = new Dictionary<string, string>();
            menus.Add("Test1Test1", ClientUtility.GetGlyphPath("CustomersKPI_32x32.png"));
            menus.Add("Test2Test2", ClientUtility.GetGlyphPath("Demo_ListEditors_Chart_Line_32x32.png"));
            menus.Add("Test3Test3", ClientUtility.GetGlyphPath("Demo_ListEditors_Chart_Bar_32x32.png"));
            menus.Add("Test4Test4", ClientUtility.GetGlyphPath("MoviesKPI_32x32.png"));
            menus.Add("Test5Test5", ClientUtility.GetGlyphPath("Wizard_32x32.png"));
            menus.Add("Test6Test6", ClientUtility.GetGlyphPath("Effects_32x32.png"));
            menus.Add("Test7Test7", ClientUtility.GetGlyphPath("rdio.png"));

            AddPageWithMenus("Test1Test1", menus);
            AddPageWithMenus("Test2Test2", menus);
            AddPageWithMenus("Test3Test3", menus);
          
     
        }


        public void AddPageWithMenus(string pageName, Dictionary<string, string> menus)
        {
            var page = Ribbon.DefaultPageCategoryVm.AddPage(pageName);
            var gp = page.AddGroup("gp", "Test");
            foreach (string key in menus.Keys)
            {

                gp.AddButtonOfLarge(key, key, menus[key]);
            }
        }

        private void Ribbon_Clicked(object sender, NodeVmArgs e)
        {
            Test();

        }

        private void Test()
        {
            var crl = GetTestList();
            DockManager.CreataOrActiveLayoutPanel(new DockPanelParam()
            {
                Crl = crl,
                Caption = "Test",
                ToolTip = "Test_ToolTip",
                ProcessStyle = EuProcessStyle.CloseAndNew
            }, "DocumentHost");

        }

        public DockManagerVm DockManager { get; set; }

        public RibbonVm ribbon;
        public RibbonVm Ribbon
        {
            get
            {
                return ribbon;
            }

            set
            {
                ribbon = value;
                SetProperty(ref ribbon, value);

            }
        }


        public IEventAggregator eventAggregator;
        public IEventAggregator EventAggregator
        {
            get
            {
                return eventAggregator;
            }

            set
            {
                eventAggregator = value;
                if (eventAggregator == null)
                {
                    return;
                }
                
            }
        }

        public Assembly RankingAssb { get; set; }
        public UserControl GetTestList()
        {
            if (RankingAssb == null)
            {
                string mdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FDConst.ModulePath);
                var file = Directory.GetFiles(mdPath, string.Format("{0}.dll", FDConst.ranking_client), SearchOption.AllDirectories).FirstOrDefault();
                RankingAssb = Assembly.LoadFile(file);
            }

            var mudule = RankingAssb.GetTypes().FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IModule)));
            var type = RankingAssb.GetType(ReflectionHelper.GetPropertyValueSafely(mudule, mudule.GetProperty("StartPagePath")).ToString());
            var crl = CrlFactory.Create(type, (crlVm) =>
            {


            });

            return crl as UserControl;

        }

    }
}
