using FunnyDation.Wpf.Selectors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Controls;

namespace FunnyDation.Wpf.Base.ViewModel
{
    public class NodeVm : BindableBase, ITemplateItem
    {
        public NodeVm()
        {
            Id = Guid.NewGuid();
            Nodes = new ObservableCollection<NodeVm>();
        }

        /// <summary>
        /// Add a child node
        /// </summary>
        /// <param name="node"></param>
        public void AddChild(NodeVm node)
        {
            if (this.Container == null)
            {
                throw new ArgumentException("NULL Container!");
            }
            if (node.Nodes.Count > 0)
            {
                throw new ArgumentException("node.Nodes.Count>0");
            }

            node.OrderID = Container.Relater.Count(p => p.Value == Id);
            Nodes.Add(node);
            InitNode(node);
        }



        /// <summary>
        /// 移除节点及其关系
        /// </summary>
        /// <param name="node"></param>
        public void RemoveChild(NodeVm node)
        {
            if (this.Container == null)
            {
                throw new ArgumentException("NULL Container!");
            }
            foreach (var n in node.Nodes)
            {
                node.RemoveChild(n);
            }
            Container.AllNodes.Remove(node.Id);
            Container.Relater.Remove(node.Id);
            Container.Relater = null;

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

        public NodeVm BuildChild(Action<NodeVm> buildVm)
        {
            buildVm(this);
            return this;
        }

        /// <summary>
        /// 获取父节点
        /// </summary>
        /// <returns></returns>
        public NodeVm GetParent()
        {
            var parentID = Container.Relater[Id];
            if (parentID == Container.Id)
            {
                return null;
            }
            return Container.AllNodes[parentID];
        }




        private void InitNode(NodeVm node)
        {
            node.Container = this.Container;
            //加入总集合
            Container.AllNodes[node.Id] = node;
            //加入父子集合
            Container.Relater[node.Id] = Id;
        }

        /// <summary>
        /// 附着数据
        /// </summary>
        public Object Data { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                SetProperty(ref name, value);

            }
        }

        /// <summary>
        /// 短名称
        /// </summary>
        public string shortName;
        public string ShortName
        {
            get
            {
                return shortName;
            }

            set
            {
                shortName = value;
                RefreshShortFullName();
                SetProperty(ref shortName, value);

            }
        }


        /// <summary>
        /// 短名称全路径
        /// </summary>
        public string shortFullName;
        public string ShortFullName
        {
            get
            {
                return shortFullName;
            }

            protected set
            {
                shortFullName = value;
                SetProperty(ref shortFullName, value);

            }
        }
        /// <summary>
        /// RefreshShortFullName
        /// </summary>
        private void RefreshShortFullName()
        {
            if (this.Container == null)
            {
                return;
            }

            var parent = GetParent();
            if (parent == null)
            {
                ShortFullName = ShortName;
                return;
            }
            if (string.IsNullOrEmpty(ShortName)) //使用父节点的全名称
            {
                ShortFullName = parent.ShortFullName;
                return;
            }

            if (string.IsNullOrEmpty(parent.ShortFullName))
            {
                ShortFullName = ShortName;
            }
            else
            {
                ShortFullName = parent.ShortFullName + "\\" + ShortName;

            }

            foreach (var node in Nodes)
            {
                node.RefreshShortFullName();
            }


        }

        public bool isExpanded;
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }

            set
            {
                if (isExpanded.Equals(value))
                {
                    return;
                }
                isExpanded = true;
                OnIsExpanded();
                if (isExpanded && !IsLazyLoaded)
                {
                    Container.OnChildLoading(this);
                    IsLazyLoaded = true;
                }
                isExpanded = value;
                SetProperty(ref isExpanded, value);

            }
        }

        public virtual void OnIsExpanded()
        {


        }
        /// <summary>
        /// IsLazyLoaded
        /// </summary>
        public bool isLazyLoaded;
        public bool IsLazyLoaded
        {
            get
            {
                return isLazyLoaded;
            }

            set
            {
                isLazyLoaded = value;
                SetProperty(ref isLazyLoaded, value);

            }
        }


        /// <summary>
        /// 选中
        /// </summary>
        public bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                SetProperty(ref isSelected, value);
                Container.CurrentNode = isSelected ? this : null;

            }
        }

        /// <summary>
        /// 类型关键字
        /// </summary>
        public int typeKey;
        public int TypeKey
        {
            get
            {
                return typeKey;
            }

            set
            {
                typeKey = value;
                SetProperty(ref typeKey, value);

            }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string glyphName;
        public string GlyphName
        {
            get
            {
                return glyphName;
            }

            set
            {
                glyphName = value;
                SetProperty(ref glyphName, value);

            }
        }



        public string DataKey { get; set; }

        /// <summary>
        /// TemplateName
        /// </summary>
        public string templateName;
        public string TemplateName
        {
            get
            {
                return templateName;
            }

            set
            {
                templateName = value;
                SetProperty(ref templateName, value);

            }
        }
        public Guid Id { get; set; }
        public NodeContainerVm Container { get; set; }
        public ObservableCollection<NodeVm> Nodes { get; set; }


        /// <summary>
        /// orderID
        /// </summary>
        public int orderID;
        public int OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
                SetProperty(ref orderID, value);

            }
        }
    }
}
