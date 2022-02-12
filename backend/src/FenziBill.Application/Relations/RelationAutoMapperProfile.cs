using AutoMapper;
using FenziBill.Entitys;
using FenziBill.Relations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenziBill.Relations
{
    public class RelationAutoMapperProfile : Profile
    {
        public RelationAutoMapperProfile()
        {
            CreateMap<Relation, RelationResultDto>();
        }
    }
}
