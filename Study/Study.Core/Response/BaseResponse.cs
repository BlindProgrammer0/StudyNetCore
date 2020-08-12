using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Core.Response
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 返回结果基类
    /// </summary>
    public class BaseResponse<T>
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
        /// 是否成功
        /// </summary>
        public bool success { get; set; }

        public T dynamicObj { get; set; }
    }

    public class BaseResponse
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
        /// 是否成功
        /// </summary>
        public bool success { get; set; }
    }
}
