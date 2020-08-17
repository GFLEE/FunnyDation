using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Base
{
    public class EnumItem<T> : EnumItem where T : struct
    {

        public EnumItem(T value, string name, string description) : base(value, name, description) { }


        public new T Value { get { return (T)base.Value; } }
    }
}
