using FenziBill.AccountBooks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FenziBill.AccountBooks
{
    public interface IAccountBookService
    {
        /// <summary>
        /// 创建账本
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AccountBookResultDto> CreateAccountBookAsync(AccountBookCreateDto dto);
        /// <summary>
        /// 通过Id删除账本
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAccountBookAsync(Guid id);
        /// <summary>
        /// 创建账本明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AccountBookLineResultDto> CreateAccountBookLineAsync(AccountBookLineCreateDto dto);
        /// <summary>
        /// 获取账本明细
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<PagedResultDto<AccountBookLineResultDto>> GetAllAccountBookLineAsync(AccountBookLineGetDto dto);
        /// <summary>
        /// 获取账本
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<PagedResultDto<AccountBookResultDto>> GetAllAccountBookAsync(AccountBookGetDto dto);
        /// <summary>
        /// 修改账本
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<AccountBookResultDto> UpdateAccountBookAsync(AccountBookUpdateDto dto);
    }
}
