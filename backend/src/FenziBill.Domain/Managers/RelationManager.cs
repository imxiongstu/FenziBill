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
    }
}
