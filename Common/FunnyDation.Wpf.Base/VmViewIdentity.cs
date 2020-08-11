using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyDation.Wpf.Base
{
    public class VmViewIdentity
    {
        public VmViewIdentity() : this("default", null)
        {

        }
        public VmViewIdentity(string key, Object obj)
        {
            this.Key = key;
            this.Obj = obj;

        }
        public VmViewIdentity(string key) : this(key, null)
        {

        }
        public override bool Equals(object obj)
        {
            var ins = obj as VmViewIdentity;
            if (ins == null)
            {
                return false;
            }
            return string.Equals(this.Key, Key, StringComparison.CurrentCultureIgnoreCase);
        }
        private bool Check(string v)
        {
            return string.Equals(this.Key, Key, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool IsDefault()
        {
            return Check("default");
        }


        static VmViewIdentity()
        {
            Default = new VmViewIdentity();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public string Key { get; set; }
        public Object Obj { get; set; }


        internal void ReKey()
        {
            this.Key = Guid.NewGuid().ToString();
        }

        public static VmViewIdentity Default { get; set; }
    }
}
