using Study.Core.Entity;
using System.Collections.Generic;

namespace Study.Core.Common.Contract
{
    public static class Contract
    {

        #region 用户信息

        /// <summary>
        /// 登录名
        /// </summary>
        public static string Account = string.Empty;

        /// <summary>
        /// 用户名
        /// </summary>
        public static string UserName = string.Empty;

        /// <summary>
        /// 是否属于管理员
        /// </summary>
        public static bool IsAdmin;

        #endregion

        #region 权限验证信息

        /// <summary>
        /// 系统中已定义的功能清单-缓存用于页面验证
        /// </summary>
        public static List<AuthItem> AuthItems;

        /// <summary>
        /// 获取用户的所有模块
        /// </summary>
        public static List<Menu> Menus;

        #endregion

        #region 接口地址

        public static string ServerUrl { get; set; } = string.Empty;

        #endregion
    }
}
