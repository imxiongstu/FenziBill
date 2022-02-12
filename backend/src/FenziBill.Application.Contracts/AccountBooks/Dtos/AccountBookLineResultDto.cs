using FenziBill.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FenziBill.AccountBooks.Dtos
{
    public class AccountBookLineResultDto
    {
        public Guid Id { get; set; }
        public string RelationName { get; set; }
        public string PersonName { get; set; }
        public decimal Money { get; set; }
        public AccountBookLineEnum.Type Type { get; set; }
        public AccountBookLineEnum.PayType PayType { get; set; }
        public DateTime? Time { get; set; }
        public DateTime CreationTime { get; set; }
        public string Remark { get; set; }
    }
}
