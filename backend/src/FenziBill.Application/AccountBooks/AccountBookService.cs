using FenziBill.AccountBooks.Dtos;
using FenziBill.Entitys;
using FenziBill.Managers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace FenziBill.AccountBooks
{
    public class AccountBookService : FenziBillAppService, IAccountBookService
    {

        private readonly AccountBookManager _accountBookManager;
        private readonly IRepository<AccountBookLine, Guid> _accountBookLineRepository;
        private readonly IRepository<Relation, Guid> _relationRepository;

        public AccountBookService
            (
            AccountBookManager accountBookManager,
            IRepository<AccountBookLine, Guid> accountBookLineRepository,
            IRepository<Relation, Guid> relationRepository
            )
        {
            _accountBookManager = accountBookManager;
            _accountBookLineRepository = accountBookLineRepository;
            _relationRepository = relationRepository;
        }



        public async Task<AccountBookResultDto> CreateAccountBookAsync(AccountBookCreateDto dto)
        {
            AccountBook accountBook = new AccountBook(GuidGenerator.Create(), dto.Name);
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
                GuidGenerator.Create(),
                dto.AccountBookId,
                dto.RelationId,
                dto.PersonName,
                dto.Money,
                dto.Type,
                dto.PayType
                );

            accountBookLine.Time = dto.Time;

            await _accountBookManager.CreateAccountBookLineAsync(dto.AccountBookId, accountBookLine);

            return ObjectMapper.Map<AccountBookLine, AccountBookLineResultDto>(accountBookLine);
        }




        public async Task<PagedResultDto<AccountBookLineResultDto>> GetAllAccountBookLineAsync(AccountBookLineGetDto dto)
        {
            var query = from accountBookLine in await _accountBookLineRepository.GetQueryableAsync()
                        join relation in await _relationRepository.GetQueryableAsync()
                        on accountBookLine.RelationId equals relation.Id
                        where accountBookLine.AccountBookId == dto.AccountBookId
                        select new AccountBookLineResultDto()
                        {
                            Id = accountBookLine.Id,
                            RelationName = relation.Name,
                            PersonName = accountBookLine.PersonName,
                            Money = accountBookLine.Money,
                            Type = accountBookLine.Type,
                            PayType = accountBookLine.PayType,
                            Time = accountBookLine.Time,
                            CreationTime = accountBookLine.CreationTime,
                            Remark = accountBookLine.Remark
                        };

            var totalCount = await query.CountAsync();

            var items = await query.OrderByDescending(o => o.CreationTime)
                .PageBy(dto.SkipCount, dto.MaxResultCount)
                .ToListAsync();

            return new PagedResultDto<AccountBookLineResultDto>(totalCount, items);
        }
    }
}
