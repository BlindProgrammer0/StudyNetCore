using Study.Core.Entity;
using System.Collections.Generic;

namespace Study.Core.Response
{
    /// <summary>
    /// 登录用户信息 - 包含用户的个人信息以及权限信息
    /// </summary>
    public class UserInfo
    {
        public User User { get; set; }

        public List<Menu> Menus { get; set; }
    }
}
