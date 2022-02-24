using FenziBill.Entitys;
using FenziBill.Managers;
using FenziBill.Relations.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace FenziBill.Relations
{
    public class RelationService : FenziBillAppService, IRelationService
    {
        private readonly RelationManager _relationManager;
        private readonly IRepository<Relation, Guid> _relationRepository;

        public RelationService
            (
            RelationManager relationManager,
            IRepository<Relation, Guid> relationRepository
            )
        {
            _relationManager = relationManager;
            _relationRepository = relationRepository;
        }



        public async Task<RelationResultDto> CreateRelationAsync(RelationCreateDto dto)
        {
            Relation relation = new Relation(GuidGenerator.Create(), dto.Name);

            await _relationManager.CreateRelationAsync(relation);

            return ObjectMapper.Map<Relation, RelationResultDto>(relation);
        }




        public async Task<PagedResultDto<RelationResultDto>> GetAllRelationAsync(RelationGetDto dto)
        {
            var query = (await _relationRepository.GetQueryableAsync());

            var totalCount = await query.CountAsync();

            var items = await query.PageBy(dto.SkipCount, dto.MaxResultCount)
                .ToListAsync();

            return new PagedResultDto<RelationResultDto>(totalCount, ObjectMapper.Map<List<Relation>, List<RelationResultDto>>(items));
        }




        public async Task DeleteRelationAsync(Guid id)
        {
            var relation = await _relationManager.GetRelationById(id);

            await _relationManager.DeleteRelationAsync(relation);
        }




        public async Task<RelationResultDto> ChangeRelationName(Guid id, string newName)
        {
            var relation = await _relationManager.ChangeRelationName(id, newName);

            return ObjectMapper.Map<Relation, RelationResultDto>(relation);
        }
    }
}
