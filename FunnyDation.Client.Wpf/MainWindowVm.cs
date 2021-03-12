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
            menus.Add("Test1Test1", ClientUtility.GetGlyphPath("home.png"));
            menus.Add("Test2Test2", ClientUtility.GetGlyphPath("Preferentialrules-fill (1).png"));
            menus.Add("Test3Test3", ClientUtility.GetGlyphPath("Settings-Window.png"));
            menus.Add("Test4Test4", ClientUtility.GetGlyphPath("参数管理.png"));
            menus.Add("Test5Test5", ClientUtility.GetGlyphPath("工程.png"));
            menus.Add("Test6Test6", ClientUtility.GetGlyphPath("列表.png"));
            menus.Add("Btn7", ClientUtility.GetGlyphPath("配置.png"));
            menus.Add("Btn8", ClientUtility.GetGlyphPath("数据字典 (1).png"));
            menus.Add("Btn9", ClientUtility.GetGlyphPath("选择文件.png"));
            menus.Add("Btn10", ClientUtility.GetGlyphPath("指标.png"));
            menus.Add("Btn11", ClientUtility.GetGlyphPath("DOC图标.png"));
            menus.Add("Btn12", ClientUtility.GetGlyphPath("file-settings-line.png"));
            menus.Add("Btn13", ClientUtility.GetGlyphPath("icons8-rules 1.png"));

            AddPageWithMenus("工程：反应堆设备", menus);
            //AddPageWithMenus("Gold Data", menus);
        }

        public void AddPageWithMenus(string pageName, Dictionary<string, string> menus)
        {
            var page1 = Ribbon.DefaultPageCategoryVm.AddPage(pageName);
            var gp1 = page1.AddGroup("gp1", "首页");
            gp1.AddButtonOfLarge("home", "首页", ClientUtility.GetGlyphPath("home2.png"));

            var gp2 = page1.AddGroup("gp2", "状态总览");
            gp2.AddButtonOfLarge("home", "指标\r\n满足情况", ClientUtility.GetGlyphPath("指标.png"));
            gp2.AddButtonOfLarge("tsm", "TSM\r\n分类模型", ClientUtility.GetGlyphPath("Diagram-4 (1).png"));
            gp2.AddButtonOfLarge("tsmall", "TSM\r\n全域模型", ClientUtility.GetGlyphPath("relation.png"));
            gp2.AddButtonOfLarge("rmsdoc", "RMS\r\n文档", ClientUtility.GetGlyphPath("DOC图标.png"));
            gp2.AddButtonOfLarge("fmode", "故障\r\n模式状态", ClientUtility.GetGlyphPath("故障缺陷.png"));
            gp2.AddButtonOfLarge("rbd", "可靠性\r\n框图信息", ClientUtility.GetGlyphPath("Diagram-3.png"));
            gp2.AddButtonOfLarge("ft", "故障树\r\n信息", ClientUtility.GetGlyphPath("tree.png")); 

            var gp3 = page1.AddGroup("gp3", "工程管理");
            gp3.AddButtonOfLarge("ft", "工程信息", ClientUtility.GetGlyphPath("project_info.png"));
            gp3.AddButtonOfLarge("ft", "报告模板配置", ClientUtility.GetGlyphPath("icon-config.png"));
            gp3.AddButtonOfLarge("ft", "模板指定", ClientUtility.GetGlyphPath("order select.png"));
            gp3.AddButtonOfLarge("ft", "工程字典", ClientUtility.GetGlyphPath("data_dic.png"));
            gp3.AddButtonOfLarge("ft", "定量参数管理", ClientUtility.GetGlyphPath("Preferentialrules-fill (1).png"));
            gp3.AddButtonOfLarge("ft", "定性参数管理", ClientUtility.GetGlyphPath("参数管理.png"));
            gp3.AddButtonOfLarge("ft", "工程设计\r\n准则库存", ClientUtility.GetGlyphPath("standard.png"));
            gp3.AddButtonOfLarge("ft", "PSSA模型\r\n显示设置", ClientUtility.GetGlyphPath("file-settings-line.png"));
            gp3.AddButtonOfLarge("ft", "SSA模型\r\n显示设置", ClientUtility.GetGlyphPath("table-column-width.png"));

            var gp4 = page1.AddGroup("gp1", "产品管理");
            gp4.AddButtonOfLarge("ft", "需求模型", ClientUtility.GetGlyphPath("数据源模型.png"));
            gp4.AddButtonOfLarge("ft", "功能模型", ClientUtility.GetGlyphPath("project-diagram.png"));
            gp4.AddButtonOfLarge("ft", "逻辑模型", ClientUtility.GetGlyphPath("node-multiple.png"));
            gp4.AddButtonOfLarge("ft", "物理模型", ClientUtility.GetGlyphPath("phsics.png"));
            gp4.AddButtonOfLarge("ft", "定量要求", ClientUtility.GetGlyphPath("require.png"));
            gp4.AddButtonOfLarge("ft", "定性要求", ClientUtility.GetGlyphPath("pad.png"));
            gp4.AddButtonOfLarge("ft", "区域树", ClientUtility.GetGlyphPath("27-linked areas.png"));
            gp4.AddButtonOfLarge("ft", "故障建模", ClientUtility.GetGlyphPath("fsux_图表_关系图.png"));


            var gp5 = page1.AddGroup("gp5", "报表");
            gp5.AddButtonOfLarge("ft", "系统可靠度", ClientUtility.GetGlyphPath("稳定可靠.png"));
            gp5.AddButtonOfLarge("ft", "报表", ClientUtility.GetGlyphPath("CHART-双轴图.png"));


            var page2 = Ribbon.DefaultPageCategoryVm.AddPage("基础配置");
            var page2_gp1 = page2.AddGroup("gp1", "基础配置");
            page2_gp1.AddButtonOfLarge("ft", "字典配置", ClientUtility.GetGlyphPath("字典管理 (3).png"));
            page2_gp1.AddButtonOfLarge("ft", "报告模板管理", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "定量参数管理", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "相似产品库", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "定性参数管理", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "成品库", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "FMEA模板", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "PSSA模板维护", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "FUHA模板维护", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "SSA模板维护", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "共模检查单模板维护", ClientUtility.GetGlyphPath("pad.png"));
            page2_gp1.AddButtonOfLarge("ft", "维修性分析模板维护", ClientUtility.GetGlyphPath("pad.png"));



            var page3 = Ribbon.DefaultPageCategoryVm.AddPage("个人事务");
            var page3_gp1 = page3.AddGroup("gp1", "个人事务");
            page3_gp1.AddButtonOfLarge("ft", "我的消息", ClientUtility.GetGlyphPath("message.png"));
            page3_gp1.AddButtonOfLarge("ft", "我的报告", ClientUtility.GetGlyphPath("报告.png"));
            page3_gp1.AddButtonOfLarge("ft", "修改密码", ClientUtility.GetGlyphPath("password.png"));
            page3_gp1.AddButtonOfLarge("ft", "系统必备", ClientUtility.GetGlyphPath("tools.png"));



            var page4 = Ribbon.DefaultPageCategoryVm.AddPage("工具列表");
            var page4_gp1 = page4.AddGroup("gp1", "工具列表");
        }

        private void Ribbon_Clicked(object sender, NodeVmArgs e)
        {
            WelCome();
            CheckAss();

            if (e.Node.DataKey.Equals("Test1Test1"))
            {
               // Test();

            }
            if (e.Node.DataKey.Equals("Test2Test2"))
            {
                //var mudule = RankingAssb.GetTypes().FirstOrDefault(p => p.GetInterfaces().Contains(typeof(IModule)));
                //var type = RankingAssb.GetType(
                //    ReflectionHelper.GetPropertyValueSafely(mudule, 
                //    mudule.GetProperty("RepoListPath")).ToString());
                //var crl = CrlFactory.Create(type, (crlVm) =>
                //{


                //});
                //DockManager.CreataOrActiveLayoutPanel(new DockPanelParam()
                //{
                //    Crl = crl as UserControl,
                //    Caption = "Test",
                //    ToolTip = "Test_ToolTip",
                //    ProcessStyle = EuProcessStyle.CloseAndNew
                //}, "DocumentHost");




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
