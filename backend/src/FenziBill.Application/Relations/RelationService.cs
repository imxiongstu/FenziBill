using FenziBill.Entitys;
using FenziBill.Managers;
using FenziBill.Relations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace FenziBill.Relations
{
    public class RelationService : FenziBillAppService, IRelationService
    {
        private readonly RelationManager _relationManager;

        public RelationService(RelationManager relationManager)
        {
            _relationManager = relationManager;
        }



        public async Task<RelationResultDto> CreateRelationAsync(RelationCreateDto dto)
        {
            Relation relation = new Relation(GuidGenerator.Create(), dto.Name);

            await _relationManager.CreateRelationAsync(relation);

            return ObjectMapper.Map<Relation, RelationResultDto>(relation);
        }
    }
}
