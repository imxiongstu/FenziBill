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
    public class AccountBook : FullAuditedAggregateRoot<Guid>
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

        public AccountBook(Guid id, string name)
        {
            Id = id;
            Name = name;
            AccountBookLines = new List<AccountBookLine>();
        }

        /// <summary>
        /// 添加账本明细
        /// </summary>
        /// <param name="relationId"></param>
        /// <param name="personName"></param>
        /// <param name="money"></param>
        /// <param name="type"></param>
        /// <param name="payType"></param>
        public void AddAccountBookLine
            (
            Guid id,
            Guid relationId,
            string personName,
            decimal money,
            AccountBookLineEnum.Type type,
            AccountBookLineEnum.PayType payType,
            DateTime? time
            )
        {
            AccountBookLine accountBookLine = new AccountBookLine
                (
                id,
                Id,
                relationId,
                personName,
                money,
                type,
                payType
                );

            accountBookLine.Time = time;

            AccountBookLines.Add(accountBookLine);
        }

        /// <summary>
        /// 添加账本明细
        /// </summary>
        /// <param name="accountBookLine"></param>
        public void AddAccountBookLine(AccountBookLine accountBookLine)
        {
            accountBookLine.AccountBookId = Id;
            AccountBookLines.Add(accountBookLine);
        }
    }
}
