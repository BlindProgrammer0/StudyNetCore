using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;

namespace Study.Core.Entity
{
    /// <summary>
    /// 实体基类
    /// </summary>
    public class BaseEntity : ViewModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
