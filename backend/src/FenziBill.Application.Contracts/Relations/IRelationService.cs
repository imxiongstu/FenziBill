using FenziBill.Relations.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FenziBill.Relations
{
    public interface IRelationService
    {
        /// <summary>
        /// 创建关系
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<RelationResultDto> CreateRelationAsync(RelationCreateDto dto);
        /// <summary>
        /// 获取关系
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<PagedResultDto<RelationResultDto>> GetAllRelationAsync(RelationGetDto dto);
    }
}
