using AutoMapper;
using FenziBill.AccountBooks.Dtos;
using FenziBill.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenziBill.AccountBooks
{
    public class AccountBookAutoMapperProfile : Profile
    {
        public AccountBookAutoMapperProfile()
        {
            CreateMap<AccountBook, AccountBookResultDto>();
            CreateMap<AccountBookLine, AccountBookLineResultDto>();
        }
    }
}
