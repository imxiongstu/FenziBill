using FenziBill.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace FenziBill.Entitys
{
    /// <summary>
    /// 账本明细
    /// </summary>
    public class AccountBookLine : Entity<Guid>, IHasCreationTime, IMayHaveCreator, IHasDeletionTime, ISoftDelete
    {
        public Guid AccountBookId { get; set; }
        public Guid RelationId { get; set; }
        /// <summary>
        /// 人名
        /// </summary>
        public string PersonName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 类型（收入/支出）
        /// </summary>
        public AccountBookLineEnum.Type Type { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public AccountBookLineEnum.PayType PayType { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Time { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public Guid? CreatorId { get; set; }
        public AccountBookLine
            (
            Guid id,
            Guid accountBookId,
            Guid relationId,
            string personName,
            decimal money,
            AccountBookLineEnum.Type type,
            AccountBookLineEnum.PayType payType
            )
        {
            Id = id;
            AccountBookId = accountBookId;
            RelationId = relationId;
            PersonName = personName;
            Money = money;
            Type = type;
            PayType = payType;
        }

    }
}
