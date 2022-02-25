using FenziBill.AccountBooks.Dtos;
using FenziBill.Entitys;
using FenziBill.Managers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        private readonly IRepository<AccountBook, Guid> _accountBookRepository;

        public AccountBookService
            (
            AccountBookManager accountBookManager,
            IRepository<AccountBookLine, Guid> accountBookLineRepository,
            IRepository<Relation, Guid> relationRepository,
            IRepository<AccountBook, Guid> accountBookRepository
            )
        {
            _accountBookManager = accountBookManager;
            _accountBookLineRepository = accountBookLineRepository;
            _relationRepository = relationRepository;
            _accountBookRepository = accountBookRepository;
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
                        on accountBookLine.RelationId equals relation.Id into _relation
                        from relation in _relation.DefaultIfEmpty()
                        join accountBook in await _accountBookRepository.GetQueryableAsync()
                        on accountBookLine.AccountBookId equals accountBook.Id
                        select new AccountBookLineResultDto()
                        {
                            AccountBookId = accountBook.Id,
                            AccountBookName = accountBook.Name,
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

            query = query.WhereIf(dto.AccountBookId != null, o => o.AccountBookId == dto.AccountBookId);

            var totalCount = await query.CountAsync();

            var items = await query.PageBy(dto.SkipCount, dto.MaxResultCount)
                                   .OrderBy(dto.Sorting)
                                   .ToListAsync();

            return new PagedResultDto<AccountBookLineResultDto>(totalCount, items);
        }




        public async Task<PagedResultDto<AccountBookResultDto>> GetAllAccountBookAsync(AccountBookGetDto dto)
        {
            var query = (await _accountBookRepository.WithDetailsAsync(o => o.AccountBookLines))
                .WhereIf(dto.AccountBookId != null, o => o.Id == dto.AccountBookId);

            var totalCount = await query.CountAsync();

            var items = await query.Select(o => new AccountBookResultDto()
            {
                Id = o.Id,
                Name = o.Name,
                Remark = o.Remark,
                CreationTime = o.CreationTime,
                IncomeMoney = o.AccountBookLines.Where(o => o.Type == Enums.AccountBookLineEnum.Type.Income).Sum(o => o.Money),
                SpendingMoney = o.AccountBookLines.Where(o => o.Type == Enums.AccountBookLineEnum.Type.Spending).Sum(o => o.Money)
            }).ToListAsync();

            return new PagedResultDto<AccountBookResultDto>(totalCount, items);
        }




        public async Task<AccountBookResultDto> UpdateAccountBookAsync(AccountBookUpdateDto dto)
        {
            var accountBook = await _accountBookManager.GetAccountBookById(dto.Id);

            await _accountBookManager.UpdateAccountBookAsync(accountBook);

            return ObjectMapper.Map<AccountBook, AccountBookResultDto>(accountBook);
        }
    }
}
