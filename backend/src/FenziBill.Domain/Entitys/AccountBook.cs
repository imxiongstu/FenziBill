using FenziBill.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FenziBill.Entitys
{
    /// <summary>
    /// 账本
    /// </summary>
    public class AccountBook : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 账本名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public ICollection<AccountBookLine> AccountBookLines { get; set; }

        public AccountBook(string name)
        {
            Name = name;
            AccountBookLines = new List<AccountBookLine>();
        }

        public void AddAccountBookLine
            (
            Guid relationId,
            string personName,
            decimal money,
            AccountBookLineEnum.Type type,
            AccountBookLineEnum.PayType payType
            )
        {
            AccountBookLines.Add(new AccountBookLine(Id, relationId, personName, money, type, payType));
        }
    }
}
