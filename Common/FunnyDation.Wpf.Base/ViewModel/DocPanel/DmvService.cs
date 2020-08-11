using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base.ViewModel.DocPanel
{
    public class DmvService
    {
        static DmvService()
        {
            Instance = new DmvService();
        }

        List<DockManagerVm> dmList = new List<DockManagerVm>();
        public static DmvService Instance { get; set; }

        public DmvService()
        {

        }

        internal void AddDockManagerVm(DockManagerVm dockManagerVm)
        {
            dmList.Add(dockManagerVm);
        }


        internal void RemoveDockManagerVm(DockManagerVm dockManagerVm)
        {
            dmList.Remove(dockManagerVm);
        }


        public DockPanelVm GetPanel(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            return dmList.SelectMany(p => p.Panels).FirstOrDefault(p => string.Equals(p.Key, key));
        }


        public string DefaultLevelCode()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public bool ContainsKey(string key)
        {
            var panel = GetPanel(key);
            return panel != null;
        }

    }
}
