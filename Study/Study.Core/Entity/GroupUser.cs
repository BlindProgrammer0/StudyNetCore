using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.Core.Entity
{
    /// <summary>
    /// 组用户
    /// </summary>
    public partial class GroupUser : BaseEntity
    {
        /// <summary>
        /// 组代码
        /// </summary>
        public string GroupCode { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

    }

    public partial class GroupUser
    {
        private bool isChecked;

        [JsonIgnore]
        [NotMapped]
        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

    }
}
