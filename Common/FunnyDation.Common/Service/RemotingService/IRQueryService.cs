using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service
{
    /// <summary>
    /// 基础查询接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRQueryService<T>
    {
        /// <summary>
        /// 获取对象集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<T> GetList(Dictionary<string, string> condition);
        /// <summary>
        /// 获取分页对象集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        RPagerInfo<T> GetRecords(Dictionary<string, string> condition);
        /// <summary>
        /// 获取对象总数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetCount(Dictionary<string, string> condition);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByID(long id);
    }
    public interface IRQueryService
    {
        /// <summary>
        /// 获取对象集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        List<object> GetList(Dictionary<string, string> condition);
        /// <summary>
        /// 获取分页对象集合
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        RPagerInfo<object> GetRecords(Dictionary<string, string> condition);
        /// <summary>
        /// 获取对象总数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        int GetCount(Dictionary<string, string> condition);
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        object GetByID(long id);
    }
}
