using FenziBill.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace FenziBill.Managers
{
    /// <summary>
    /// 账本领域服务
    /// </summary>
    public class AccountBookManager : DomainService
    {
        private readonly IRepository<AccountBook, Guid> _accountBookRepository;
        public AccountBookManager(IRepository<AccountBook, Guid> accountBookRepository)
        {
            _accountBookRepository = accountBookRepository;
        }


        /// <summary>
        /// 获取账本通过Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<AccountBook> GetAccountBookById(Guid id)
        {
            var accountBook = await _accountBookRepository.FirstOrDefaultAsync(o => o.Id == id);

            if (accountBook == null)
            {
                throw new UserFriendlyException("未找到该Id的账本");
            }

            return accountBook;
        }


        /// <summary>
        /// 创建账本
        /// </summary>
        /// <param name="accountBook"></param>
        /// <returns></returns>
        public async Task<AccountBook> CreateAccountBookAsync(AccountBook accountBook)
        {
            if (await _accountBookRepository.AnyAsync(o => o.Name == accountBook.Name))
            {
                throw new UserFriendlyException("已存在相同账本名称！");
            }

            return await _accountBookRepository.InsertAsync(accountBook);
        }

        /// <summary>
        /// 删除账本
        /// </summary>
        /// <param name="accountBook"></param>
        /// <returns></returns>
        public async Task DeleteAccountBookAsync(AccountBook accountBook)
        {
            if (accountBook.AccountBookLines.Count > 0)
            {
                throw new UserFriendlyException("请先删除账本中所有明细！");
            }

            await _accountBookRepository.DeleteAsync(accountBook);
        }


        public async Task<AccountBookLine> CreateAccountBookLineAsync(Guid accountBookId, AccountBookLine accountBookLine)
        {
            var accountBook = await GetAccountBookById(accountBookId);

            accountBook.AddAccountBookLine(accountBookLine);

            await _accountBookRepository.UpdateAsync(accountBook);

            return accountBookLine;
        }
    }
}
