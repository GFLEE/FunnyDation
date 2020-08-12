using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base
{
    public class VmLinkVm : BindableBase, IVmLinkVm
    {

        public VmViewIdentity viewIdentity;
        public VmViewIdentity ViewIdentity
        {
            get
            {
                if (viewIdentity == null)
                {
                    viewIdentity = new VmViewIdentity();
                }
                return viewIdentity;
            }

            set
            {
                viewIdentity = value;
                SetProperty(ref viewIdentity, value);

            }
        }


        public object vmData;
        public object VmData
        {
            get
            {
                return vmData;
            }

            set
            {
                if (!object.Equals(VmData, value))
                {

                    vmData = value;
                    OnVmDataChanged();
                    SetProperty(ref vmData, value);
                }

            }
        }

        public virtual void OnVmDataChanged()
        {


        }


        public string GetVmDataKeyString()
        {
            var result = GetVmDataKey();
            if (result == null)
            {
                return null;
            }

            return result.ToString();

        }

        public object GetVmDataKey()
        {
            if (VmData == null)
            {
                return null;
            }

            return GetVmDataKeyImpl();
        }

        public object GetVmDataKeyImpl()
        {
            throw new NotImplementedException();
        }

        public object sourceVm;
        public object SourceVm
        {
            get
            {
                return sourceVm;
            }

            set
            {
                if (!object.Equals(sourceVm, value))
                {
                    sourceVm = value;
                    OnSourceVmChanged();
                    SetProperty(ref sourceVm, value);
                }


            }
        }
        /// <summary>
        /// OnSourceVmChanged
        /// </summary>
        public virtual void OnSourceVmChanged()
        {

        }

        /// <summary>
        /// Rela Object Invoke
        /// </summary>
        /// <param name="name"></param>
        /// <param name="param"></param>
        public virtual void CallBack(string name, object param)
        {

        }

        /// <summary>
        /// 查找SourceVm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T FindSourceVm<T>() where T : class
        {
            var parent = SourceVm;
            while (parent != null)
            {
                if (parent is T)
                {
                    return (T)parent;
                }
                if (parent is VmLinkVm)
                {
                    continue;
                }
                parent = FakeFind(parent);
                if (parent == null)
                {
                    return null;
                }
            }

            return null;
        }

        static object FakeFind(object sourceVm)
        {
            foreach (var finder in finders)
            {
                if (finder.Check(sourceVm))
                {
                    var linkVm = finder.Find(sourceVm);
                    return linkVm;
                }
            }

            return null;

        }
        static List<FakeFinder> finders = new List<FakeFinder>();

        /// <summary>
        /// 注册可以类似SourceVm查找的委托
        /// </summary>
        /// <param name="finder"></param>
        internal static void RegisterFindFakeSourceVm(FakeFinder finder)
        {
            finders.Add(finder);
        }
        public virtual string VmDataKey { get; set; }
        internal class FakeFinder
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="find">查找的委托</param>
            /// <param name="check">是否应用“查找的委托”</param>
            public FakeFinder(Func<object, object> find, Func<object, bool> check)
            {
                this.Find = find;
                this.Check = check;
            }

            public Func<object, object> Find { get; set; }
            public Func<object, bool> Check { get; set; }
        }

    }
}
