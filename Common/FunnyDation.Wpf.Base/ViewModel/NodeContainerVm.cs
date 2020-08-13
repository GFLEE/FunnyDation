using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Mvvm;
using static FunnyDation.Wpf.Base.VmLinkVm;

namespace FunnyDation.Wpf.Base.ViewModel
{
    /// <summary>
    /// Node容器
    /// </summary>
    public abstract class NodeContainerVm : BindableBase
    {

        static NodeContainerVm()
        {
            var finder = new FakeFinder(FindOfFakeFinder, CheckOfFakeFinder);
            VmLinkVm.RegisterFindFakeSourceVm(finder);
        }
        static object FindOfFakeFinder(object sourceVm)
        {
            if (!CheckOfFakeFinder(sourceVm))
            {
                throw new Exception();
            }
            var nodeVm = sourceVm as NodeVm;
            if (nodeVm != null)
            {
                var parent = nodeVm.GetParent();

                if (parent == null) //没有父节点，则返回容器
                {
                    return nodeVm.Container;
                }
                return parent;
            }

            var containerVm = sourceVm as NodeContainerVm;
            if (containerVm != null)
            {
                return containerVm.HostVm;
            }

            throw new ArgumentException();
        }
        private static bool CheckOfFakeFinder(object sourceVm)
        {
            if (sourceVm == null)
            {
                return false;
            }
            var type = sourceVm.GetType();
            if (type.IsSubclassOf(typeof(NodeVm)) || type.IsSubclassOf(typeof(NodeContainerVm)))
            {
                return true;
            }
            return false;

        }


        public NodeContainerVm(object hostVm)
        {
            Id = Guid.NewGuid();
            AllNodes = new Dictionary<Guid, NodeVm>();
            Nodes = new ObservableCollection<NodeVm>();
            Relater = new Dictionary<Guid, Guid>();
            HostVm = hostVm;
        }

        /// <summary>
        /// 查询后代
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataKey"></param>
        /// <returns></returns>
        public T FindDescendantByDataKey<T>(string dataKey) where T : NodeVm
        {
            return GetDescendantByDataKey<T>(dataKey).FirstOrDefault();
        }

        public List<T> GetDescendantByDataKey<T>(string dataKey) where T : NodeVm
        {
            return GetDescendantByDataKey(dataKey).OfType<T>().ToList();
        }

        public List<NodeVm> GetDescendantByDataKey(string dataKey)
        {
            return AllNodes.Where(p => string.Equals(p.Value.DataKey, dataKey))
                   .Select(p => p.Value).ToList();
        }



        public void AddChild(NodeVm node)
        {
            node.OrderID = Relater.Count(p => p.Value == Id);
            Nodes.Add(node);
            InitNode(node);

            OnAfterAddChild(node);
        }



        protected virtual void OnAfterAddChild(NodeVm node)
        {


        }


        public void RemoveNode(NodeVm node)
        {
            if (node == null || node.Container == null)
            {
                return;
            }

            foreach (var n in node.Nodes)
            {
                node.RemoveChild(n);
            }
            AllNodes.Remove(node.Id);
            Relater.Remove(node.Id);
            Relater = null;

        }

        public void Clear()
        {
            foreach (var node in Nodes.ToList())
            {
                RemoveNode(node);
            }
        }


        /// <summary>
        /// 添加自对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="initVm"></param>
        /// <returns></returns>
        public T AddChild<T>(Action<T> initVm = null) where T : NodeVm
        {
            var node = Activator.CreateInstance<T>();
            if (initVm != null)
            {
                initVm(node);
            }
            AddChild(node);
            return node;
        }
        private void InitNode(NodeVm node)
        {
            node.Container = this;
            //加入总集合
            AllNodes[node.Id] = node;
            //加入父子集合
            Relater[node.Id] = Id;
            node.RefreshShortFullName();
        }

        /// <summary>
        /// 展开所有
        /// </summary>
        public void Expand()
        {
            foreach (var item in AllNodes)
            {
                item.Value.IsExpanded = true;
            }
        }

        /// <summary>
        /// 合并所有
        /// </summary>
        public void Collapse()
        {
            foreach (var item in AllNodes)
            {
                item.Value.IsExpanded = false;
            }
        }

        /// <summary>
        /// 当前
        /// </summary>
        public NodeVm currentNode = null;
        public NodeVm CurrentNode
        {
            get
            {
                return currentNode;
            }

            set
            {
                currentNode = value;
                SetProperty(ref currentNode, value);
                DoCurrentNodeChanged(value);

            }
        }
        /// <summary>
        /// 变更事件
        /// </summary>
        public event EventHandler<NodeVmArgs> CurrentNodeChanged;
        void DoCurrentNodeChanged(NodeVm vm)
        {
            OnCurrentNodeChanged(vm);
            if (CurrentNodeChanged != null && vm != null)
            {
                CurrentNodeChanged(this, new NodeVmArgs(vm));
            }

        }

        public virtual void OnCurrentNodeChanged(NodeVm vm)
        {



        }

        #region Click Handle
        public event EventHandler<NodeVmArgs> Clicked;
        internal void DoClicked(NodeVm vm)
        {
            if (vm != null)
            {
                OnClicked(vm);
            }

            if (Clicked != null && vm != null)
            {
                Clicked(this, new NodeVmArgs(vm));
            }
        }

        protected virtual void OnClicked(NodeVm vm)
        {


        }

        public event EventHandler<NodeVmArgs> DoubleClicked;
        internal void DoDoubleClicked(NodeVm vm)
        {
            if (vm != null)
            {
                OnDoubleClicked(vm);
            }

            if (DoubleClicked != null || vm != null)
            {
                DoubleClicked(this, new NodeVmArgs(vm));
            }
        }

        protected virtual void OnDoubleClicked(NodeVm vm)
        {


        }

        #endregion

        public event EventHandler<NodeVmArgs> ChildLoading;

        internal void OnChildLoading(NodeVm node)
        {

            if (ChildLoading != null)
            {
                ChildLoading(this, new NodeVmArgs(node));
            }

        }

        public Guid Id { get; set; }
        public object HostVm { get; set; }

        public Dictionary<Guid, Guid> Relater { get; internal set; }
        public Dictionary<Guid, NodeVm> AllNodes { get; internal set; }
        public ObservableCollection<NodeVm> Nodes { get; internal set; }
    }

    /// <summary>
    /// Node参数
    /// </summary>
    public class NodeVmArgs : EventArgs
    {
        public NodeVmArgs(NodeVm node)
        {
            this.Node = node;
        }

        public NodeVm Node { get; set; }
    }
}
