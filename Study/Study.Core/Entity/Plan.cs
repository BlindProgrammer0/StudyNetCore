namespace Study.Core.Entity
{

    using System;

    /// <summary>
    /// 消费计划
    /// </summary>
    public class Plan : BaseEntity
    {
        /// <summary>
        /// 计划标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 计划主题
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 计划金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 计划时间
        /// </summary>
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// 计划状态
        /// </summary>
        public int PlanStatus { get; set; }
    }
}
