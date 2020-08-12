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
            CommandFundBase = new DelegateCommand(Test);
            EventAggregator = ServiceLocator.Current.TryResolve<IEventAggregator>();
            EventAggregator.GetEvent<DockPanelShowEvent>().Subscribe(DockPanelShow);
            DockManager = new DockManagerVm();
            Ribbon = new RibbonVm(this);
            Ribbon.Visiable = true;
            Ribbon.Clicked += Ribbon_Clicked;
        }

        private void Ribbon_Clicked(object sender, NodeVmArgs e)
        {


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
                eventAggregator.GetEvent<DockPanelShowEvent>().Subscribe(DockPanelShow);
            }
        }

        private void DockPanelShow(DockPanelShowEventArgs args)
        {
            DockPanelParam dockPanelParam = new DockPanelParam()
            {
                Caption = args.Caption,
                ToolTip = args.ToolTip,
                Crl = args.Crl,
                TemplateName = args.TemplateName,
                ProcessStyle = args.ProcessStyle,
                TargetName = args.TargetName,
            };

            if (!string.IsNullOrWhiteSpace(dockPanelParam.TargetName))
            {
                DockManager.CreataOrActivePanel(dockPanelParam);
                return;
            }
            DockManager.CreataOrActiveDocumentPanel(dockPanelParam);
        }

        public Assembly RankingAssb { get; set; }
        public DelegateCommand CommandFundBase { get; set; }


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
