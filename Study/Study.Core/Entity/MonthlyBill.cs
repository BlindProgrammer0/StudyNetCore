
using System;

namespace Study.Core.Entity
{
    /// <summary>
    /// 月度账单
    /// </summary>
    public class MonthlyBill : BaseEntity
    {
        /// <summary>
        /// 账单流水号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
