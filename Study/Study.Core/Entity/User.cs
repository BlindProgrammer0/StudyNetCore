namespace Study.Core.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 用户
    /// </summary>
    public partial class User : BaseEntity
    {
        /// <summary>
        /// 账户名称
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }

        /// <summary>
        /// 最后登出时间
        /// </summary>
        public DateTime LastLogouTime { get; set; }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public int IsLocked { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否为管理员  0/1 false/true
        /// </summary>
        public int FlagAdmin { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public string FlagOnline { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginCounter { get; set; }
    }

    public partial class User
    {
        private bool isChecked;

        /// <summary>
        /// 是否选中
        /// </summary>
        [NotMapped]
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; RaisePropertyChanged(); }
        }
    }
}
