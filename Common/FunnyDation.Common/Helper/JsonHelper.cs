using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FunnyDation.Common
{
    public class JsonHelper
    {

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="format">json 格式</param>
        /// <returns></returns>
        public static string Serialize(object obj, Formatting format = Formatting.None)
        {
            return JsonConvert.SerializeObject(obj, format);

        }
        public static string SerializeWithSetting(object obj, JsonSerializerSettings settings = null)
        {
            return JsonConvert.SerializeObject(obj, settings);

        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);

        }

        /// <summary>
        /// 反序列化并转换成指定类型
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object Deserialize(string jsonStr, Type type)
        {
            return JsonConvert.DeserializeObject(jsonStr, type);

        }

    }
}
