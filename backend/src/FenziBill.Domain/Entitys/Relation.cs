using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace FenziBill.Entitys
{
    /// <summary>
    /// 关系
    /// </summary>
    public class Relation : Entity<Guid>, IMayHaveCreator
    {
        /// <summary>
        /// 关系名
        /// </summary>
        public string Name { get; set; }
        public Guid? CreatorId { get; set; }

        public Relation(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
