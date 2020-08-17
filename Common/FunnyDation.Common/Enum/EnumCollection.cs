using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace FunnyDation.Common.Base
{
    public class EnumCollection : ICollection
    {
        private Type EnumType;
        public Collection<EnumItem> coll = new Collection<EnumItem>();
        public EnumCollection(Type enumType)
        {
            this.EnumType = enumType;
        }

        public void Add(EnumItem item)
        {
            coll.Add(item);
        }


        public EnumItem this[int value]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (item.IntValue == value)
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        public EnumItem this[object value]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (object.Equals(item.Value, value))
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        public EnumItem this[string name]
        {
            get
            {
                foreach (var item in coll)
                {
                    if (item.Name == name)
                    {
                        return item;
                    }
                }
                return null;
            }
        }
        public int Count => coll.Count;

        public bool IsSynchronized => ((ICollection)coll).IsSynchronized;

        public object SyncRoot => ((ICollection)coll).SyncRoot;

        public void CopyTo(Array array, int index)
        {
            ((ICollection)coll).CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return ((ICollection)coll).GetEnumerator();
        }


        public EnumCollection GetEnumCollection(Type type)
        {
            var methos = typeof(EnumCollection).GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(p => p.Name.Equals("GetEnumCollection") && p.GetParameters().Length.Equals(0));
            var result = methos.MakeGenericMethod(type).Invoke(null, null);

            return (EnumCollection)result;
        }

        /// <summary>
        /// GetEnumCollection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public EnumCollection GetEnumCollection<T>(T type) where T : struct
        {
            var result = new EnumCollection<T>();
            var enumType = typeof(T);
            Type attributeType = typeof(DescriptionAttribute);
            FieldInfo[] fields = enumType.GetFields();
            foreach (FieldInfo info in fields)
            {
                if (info.FieldType.IsEnum)
                {
                    var value = enumType.InvokeMember(info.Name, BindingFlags.GetField, null, null, null);
                    var name = enumType.InvokeMember(info.Name, BindingFlags.GetField, null, null, null).ToString();
                    var description = name;
                    object[] customAttributes = info.GetCustomAttributes(attributeType, true);
                    if (customAttributes.Length > 0)
                    {
                        DescriptionAttribute attribute = (DescriptionAttribute)customAttributes[0];
                        description = attribute.Description;

                    }
                    var item = new EnumItem<T>((T)value, name, description);
                    result.Add(item);
                }
            }

            return result;
        }


    }
}
