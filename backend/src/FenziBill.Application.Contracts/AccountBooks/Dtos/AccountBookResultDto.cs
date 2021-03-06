using System;
using System.Collections.Generic;
using System.Text;

namespace FenziBill.AccountBooks.Dtos
{
    public class AccountBookResultDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal IncomeMoney { get; set; }
        public decimal SpendingMoney { get; set; }
    }
}
