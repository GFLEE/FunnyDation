using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace FunnyDation.Wpf.Base.ViewModel
{
    /// <summary>
    /// Node容器
    /// </summary>
    public abstract class NodeContainerVm : BindableBase
    {

        public NodeContainerVm()
        {




        }





        public Guid Id { get; set; }

        public Dictionary<Guid,Guid> Relater { get; internal set; }
        public Dictionary<Guid, NodeVm> AllNodes { get; internal set; }
        public NodeVm CurrentNode { get; internal set; }

        internal void OnChildLoading(NodeVm nodeVm)
        {
            throw new NotImplementedException();
        }
    }
}
