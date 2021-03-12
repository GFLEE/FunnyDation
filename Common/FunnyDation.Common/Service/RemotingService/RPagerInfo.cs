using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service
{
    /// <summary>
    /// 带有翻页记录的集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RPagerInfo<T>
    {
        public RPagerInfo()
        {

        }

        public void Set(int? pageSize, int? skip, int count)
        {
            if (pageSize == null || pageSize < 0)
            {
                PageSize = 20;
            }
            if (skip == null || skip < 0)
            {
                skip = 0;
            }
            this.Count = count;
            this.PageSize = pageSize.Value;
            this.PageIndex = (int)(skip.Value / pageSize);
            this.PageCount = (int)(count / pageSize);
            if (count != PageCount * PageSize)
            {
                PageCount++;


            }

        }


        /// <summary>
        /// 从1开始
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页数量
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 记录数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 记录集合
        /// </summary>
        public List<T> Record { get; set; }

    }
}
