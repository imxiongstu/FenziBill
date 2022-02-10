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
    public class AccountBookLine : Entity<Guid>, IHasCreationTime, ISoftDelete
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
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }

        public AccountBookLine
            (
            Guid accountBookId,
            Guid relationId,
            string personName,
            decimal money,
            AccountBookLineEnum.Type type,
            AccountBookLineEnum.PayType payType
            )
        {
            AccountBookId = accountBookId;
            RelationId = relationId;
            PersonName = personName;
            Money = money;
            Type = type;
            PayType = payType;
        }

    }
}
