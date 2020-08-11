﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Core.Response
{
    /// <summary>
    /// 请求返回定义类
    /// </summary>
    public class ConsumptionResponse
    {
        /// <summary>
        /// 后台消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// //返回状态
        /// </summary>
        public int statusCode { get; set; }

        /// <summary>
        /// //分页的时候指定每页显示多少条数据
        /// </summary>
        public int pageSize { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int totalPage { get; set; }

        /// <summary>
        /// 是否分页
        /// </summary>
        public string paging { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 总共的记录数
        /// </summary>
        public int TotalRecord { get; set; }

        public dynamic dynamicObj { get; set; }
    }
}
