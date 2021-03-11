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

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T DeSerialize<T>(string jsonStr)
        {
            return JsonConvert.DeserializeObject<T>(jsonStr);

        }


    }
}
