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
            RepoListPath = "FunnyDation.Wpf.Ranking.Views.Fund.CrlList";
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        public static string StartPagePath { get; set; }
        public static string RepoListPath { get; set; }

    }
}
