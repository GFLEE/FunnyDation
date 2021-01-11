using FunnyDation.Wpf.Base.ViewModel;
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
using FunnyDation.Client.Wpf.Views;
using FunnyDation.Wpf.Web;
using FunnyDation.Common.Service;

namespace FunnyDation.Client.Wpf
{
    public class MainWindowVm : CrlVm
    {
        public MainWindowVm()
        {
            DockManager = new DockManagerVm();
            Ribbon = new RibbonVm(this);
            Ribbon.Visiable = true;
            Ribbon.Clicked += Ribbon_Clicked;

            WelCome();
            InitMenu();




        }
         
        public void WelCome()
        {
            var crl = CrlFactory.Create<Welcome>((crlvm) =>
            {

            });
            DockManager.CreataOrActiveLayoutPanel(new DockPanelParam()
            {
                Crl = crl,
                Caption = "Welcome",
                ToolTip = "Welcome",
                ProcessStyle = EuProcessStyle.CloseAndNew
            }, "DocumentHost");

        }

        public void InitMenu()
        {
            Dictionary<string, string> menus = new Dictionary<string, string>();
            menus.Add("Test1Test1", ClientUtility.GetGlyphPath("Action_Chart_Options_32x32.png"));
            menus.Add("Test2Test2", ClientUtility.GetGlyphPath("Action_AboutInfo_32x32.png"));
            menus.Add("Test3Test3", ClientUtility.GetGlyphPath("Action_ChartDataVertical_32x32.png"));
            menus.Add("Test4Test4", ClientUtility.GetGlyphPath("Action_Clear_Settings_32x32.png"));
            menus.Add("Test5Test5", ClientUtility.GetGlyphPath("AboveAverage_32x32.png"));
            menus.Add("Test6Test6", ClientUtility.GetGlyphPath("Action_ChooseSkin_32x32.png"));
            menus.Add("Test7Test7", ClientUtility.GetGlyphPath("Action_Change_State_32x32.png"));

            AddPageWithMenus("Fund Data", menus);
            AddPageWithMenus("Gold Data", menus);
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
            CheckAss();

            if (e.Node.DataKey.Equals("Test1Test1"))
            {
                Test();

            }
            if (e.Node.DataKey.Equals("Test2Test2"))
            {
                var mudule = RankingAssb.GetTypes().FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IModule)));
                var type = RankingAssb.GetType(
                    ReflectionHelper.GetPropertyValueSafely(mudule, 
                    mudule.GetProperty("RepoListPath")).ToString());
                var crl = CrlFactory.Create(type, (crlVm) =>
                {


                });
                DockManager.CreataOrActiveLayoutPanel(new DockPanelParam()
                {
                    Crl = crl as UserControl,
                    Caption = "Test",
                    ToolTip = "Test_ToolTip",
                    ProcessStyle = EuProcessStyle.CloseAndNew
                }, "DocumentHost");
            }


            //RESTService rEST = IocService.Resolve(typeof(RESTService)) as RESTService;
            //rEST.Post("http://127.0.0.1:5000/Invoke/", "bayes", "cal_bayes", new object[] { 1, 2, 3, 4 });


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

        public void CheckAss()
        {
            if (RankingAssb == null)
            {
                string mdPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FDConst.ModulePath);
                var file = Directory.GetFiles(mdPath, string.Format("{0}.dll", FDConst.ranking_client), SearchOption.AllDirectories).FirstOrDefault();
                RankingAssb = Assembly.LoadFile(file);
            }

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

      

        public Assembly RankingAssb { get; set; }
        public UserControl GetTestList()
        { 

            var mudule = RankingAssb.GetTypes().FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IModule)));
            var type = RankingAssb.GetType(ReflectionHelper.GetPropertyValueSafely(mudule, mudule.GetProperty("StartPagePath")).ToString());
            var crl = CrlFactory.Create(type, (crlVm) =>
            {


            });

            return crl as UserControl;

        }

    }
}
