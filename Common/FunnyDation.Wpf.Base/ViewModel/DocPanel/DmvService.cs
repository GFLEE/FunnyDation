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








    }
}
