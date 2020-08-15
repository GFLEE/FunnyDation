using Prism.Ioc;
using Prism.Modularity;
using System;

namespace FunnyDation.Wpf.Fund
{
    public class RankingModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            StartPagePath = "FunnyDation.Wpf.Fund.Views.CrlFundList";
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        public static string StartPagePath { get; set; }

    }
}
