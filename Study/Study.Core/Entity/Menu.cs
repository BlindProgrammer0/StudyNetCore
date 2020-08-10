namespace Study.Core.Entity
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : BaseEntity
    {
        /// <summary>
        /// 菜单代码
        /// </summary>
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 菜单标题
        /// </summary>
        public string MenuCaption { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string MenuNameSpace { get; set; }

        /// <summary>
        /// 所属权限值
        /// </summary>
        public int MenuAuth { get; set; }
    }
}
