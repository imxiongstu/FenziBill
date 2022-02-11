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

        public RelationManager(IRepository<Relation, Guid> relationRepository)
        {
            _relationRepository = relationRepository;
        }

        public async Task<Relation> CreateRelationAsync(Relation relation)
        {
            if (await _relationRepository.AnyAsync(o => o.Name == relation.Name))
            {
                throw new UserFriendlyException("该关系名称已经存在！");
            }

            return await _relationRepository.InsertAsync(relation);
        }
    }
}
