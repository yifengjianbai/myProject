using System;
using System.Collections.Generic;
using System.Text;

namespace OpenAuth.App.Base
{
    public class PagingData<T>
    {
        /// <summary>
        /// (不分页计算)检索到的行为总条数
        /// </summary>
        public int Countnum { get; set; }
        /// <summary>
        /// （分页）某页数据
        /// </summary>
        public List<T> Data { get; set; }
        /// <summary>
        /// (不分页计算)检索到的行为总条数
        /// </summary>
        public int Code { get; set; } = 0;//0表示无问题,1timeout
        /// <summary>
        /// 用于统计查询数据的总计值
        /// </summary>
        public decimal? totalData = 0;
    }
}
