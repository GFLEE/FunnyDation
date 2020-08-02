using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Wpf
{
    /// <summary>
    /// RESTService
    /// </summary>
    public interface IRESTService
    {
        /// <summary>
        /// 简单发送Get请求: 指定Url地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string Get(string url);
        /// <summary>
        /// 带请求参数的Get方法: 发送Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        string Get(string url, Dictionary<string, string> dic);
        /// <summary>
        /// 不带参数发送Post请求: 指定Post地址使用Get 方式获取全部字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string Post(string url);
        /// <summary>
        /// 带参数Post请求,指定键值对: 指定Post地址使用Post 方式获取全部字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        string Post(string url, Dictionary<string, string> dic);
        /// <summary>
        /// 带参数的Post请求，指定发送字符串内容: 指定Post地址使用Post 方式获取全部字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        string Post(string url, string content);

    }
}
