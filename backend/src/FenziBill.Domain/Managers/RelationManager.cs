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
    public class RelationManager : DomainService
    {

        private readonly IRepository<Relation, Guid> _relationRepository;
        private readonly IRepository<AccountBookLine, Guid> _accountBookLineRepository;

        public RelationManager
            (
            IRepository<Relation, Guid> relationRepository,
            IRepository<AccountBookLine, Guid> accountBookLineRepository
            )
        {
            _relationRepository = relationRepository;
            _accountBookLineRepository = accountBookLineRepository;
        }


        /// <summary>
        /// 通过Id获取关系
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<Relation> GetRelationById(Guid id)
        {
            var relation = await _relationRepository.FirstOrDefaultAsync(o => o.Id == id);

            if (relation == null)
            {
                throw new UserFriendlyException("未找到该Id的关系");
            }

            return relation;
        }


        /// <summary>
        /// 创建关系
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        public async Task<Relation> CreateRelationAsync(Relation relation)
        {
            if (await _relationRepository.AnyAsync(o => o.Name == relation.Name))
            {
                throw new UserFriendlyException("该关系名称已经存在！");
            }

            return await _relationRepository.InsertAsync(relation);
        }


        /// <summary>
        /// 删除关系
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        public async Task DeleteRelationAsync(Relation relation)
        {
            if (await _accountBookLineRepository.AnyAsync(o => o.RelationId == relation.Id))
            {
                throw new UserFriendlyException("此关系存在账单明细中，无法删除！");
            }

            await _relationRepository.DeleteAsync(relation);
        }



        /// <summary>
        /// 改变关系名称通过Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public async Task<Relation> ChangeRelationName(Guid id, string newName)
        {
            var relation = await GetRelationById(id);

            if (await _relationRepository.AnyAsync(o => o.Name == newName && o.Id != id))
            {
                throw new UserFriendlyException("该关系名称已经存在！");
            }

            relation.Name = newName;

            return await _relationRepository.UpdateAsync(relation);
        }
    }
}
