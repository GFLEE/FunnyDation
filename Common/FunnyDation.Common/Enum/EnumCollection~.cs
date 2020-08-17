using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FunnyDation.Common.Base
{
    public class EnumCollection<T> : EnumCollection where T : struct
    {
        public EnumCollection() : base(typeof(T)) { }

        public void Add(EnumItem<T> item)
        {
            coll.Add(item);
        }

        public void Remove(Enum item)
        {
            var v = this[item];
            coll.Remove(v);
        }

        public EnumItem<T> this[int value]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (item.IntValue == value)
                    {
                        return (EnumItem<T>)item;
                    }
                }
                return null;
            }
        }

        public EnumItem<T> this[object value]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (object.Equals(item.Value, value))
                    {
                        return (EnumItem<T>)item;
                    }
                }
                return null;
            }
        }

        public EnumItem<T> this[string name]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (item.Name == name)
                    {
                        return (EnumItem<T>)item;
                    }
                }
                return null;
            }
        }






    }
}
