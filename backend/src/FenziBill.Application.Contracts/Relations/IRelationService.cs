using FenziBill.Relations.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FenziBill.Relations
{
    public interface IRelationService
    {
        Task<RelationResultDto> CreateRelationAsync(RelationCreateDto dto);
    }
}
