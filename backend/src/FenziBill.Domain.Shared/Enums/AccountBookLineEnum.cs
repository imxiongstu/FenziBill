using System;
using System.Collections.Generic;
using System.Text;

namespace FenziBill.Enums
{
    public class AccountBookLineEnum
    {
        public enum Type
        {
            Income, Spending
        }

        public enum PayType
        {
            Cash, WeChat, Alipay, BackCard
        }
    }
}
