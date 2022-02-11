using FenziBill.AccountBooks.Dtos;
using FenziBill.Entitys;
using FenziBill.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace FenziBill.AccountBooks
{
    public class AccountBookService : FenziBillAppService, IAccountBookService
    {
        private readonly AccountBookManager _accountBookManager;

        public AccountBookService
            (
            AccountBookManager accountBookManager
            )
        {
            _accountBookManager = accountBookManager;
        }



        public async Task<AccountBookResultDto> CreateAccountBookAsync(AccountBookCreateDto dto)
        {
            AccountBook accountBook = new AccountBook(dto.Name);
            accountBook.Remark = dto.Remark;

            await _accountBookManager.CreateAccountBookAsync(accountBook);

            return ObjectMapper.Map<AccountBook, AccountBookResultDto>(accountBook);
        }



        public async Task DeleteAccountBookAsync(Guid id)
        {
            var accountBook = await _accountBookManager.GetAccountBookById(id);

            await _accountBookManager.DeleteAccountBookAsync(accountBook);
        }



        public async Task<AccountBookLineResultDto> CreateAccountBookLineAsync(AccountBookLineCreateDto dto)
        {
            AccountBookLine accountBookLine = new AccountBookLine
                (
                dto.AccountBookId,
                dto.RelationId,
                dto.PersonName,
                dto.Money,
                dto.Type,
                dto.PayType
                );

            await _accountBookManager.CreateAccountBookLineAsync(dto.AccountBookId, accountBookLine);

            return ObjectMapper.Map<AccountBookLine, AccountBookLineResultDto>(accountBookLine);
        }
    }
}
