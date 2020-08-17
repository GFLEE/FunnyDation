using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Base
{
    public class EnumItem
    {
        public EnumItem(object value, string name, string description)
        {
            Value = value;
            Name = name;
            Description = description;
            IntValue = Convert.ToInt32(value);
        }

        public int IntValue { get; internal set; }
        public object Value { get; internal set; }
        public string Name { get; internal set; }
        public string Description { get; internal set; }
    }
}
