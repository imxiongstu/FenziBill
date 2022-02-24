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
        /// <summary>
        /// 通过Id删除关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteRelationAsync(Guid id);
        /// <summary>
        /// 修改关系名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        Task<RelationResultDto> ChangeRelationName(Guid id, string newName);
    }
}
