namespace Study.Core.Entity
{
    /// <summary>
    /// 月度账单明细
    /// </summary>
    public class MonthlyBillDetail : BaseEntity
    {
        /// <summary>
        /// 主表流水号
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 消费类型
        /// </summary>
        public int ConsumptionType { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }
    }
}
