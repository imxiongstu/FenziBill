using FenziBill.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;

namespace FenziBill.EntityFrameworkCore
{
    public static class FenziBillEntityConfigure
    {
        public static void EntityConfigure(this ModelBuilder builder)
        {
            //配置账本表
            builder.Entity<AccountBook>(o =>
            {
                o.ToTable("Fenzi_AccountBooks");
                o.ConfigureByConvention();
                o.Property(o => o.Name).IsRequired().HasMaxLength(10);
                o.Property(o => o.Remark).HasMaxLength(100);
            });

            //配置账本明细表
            builder.Entity<AccountBookLine>(o =>
            {
                o.ToTable("Fenzi_AccountBookLines");
                o.ConfigureByConvention();
                o.Property(o => o.PersonName).IsRequired().HasMaxLength(10);
                o.Property(o => o.Remark).HasMaxLength(100);
                o.HasOne<AccountBook>()
                .WithMany(o => o.AccountBookLines)
                .HasForeignKey(o => o.AccountBookId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
                o.HasOne<Relation>()
                .WithMany()
                .HasForeignKey(o => o.RelationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            });

            //配置关系表
            builder.Entity<Relation>(o =>
            {
                o.ToTable("Fenzi_Relations");
                o.ConfigureByConvention();
                o.Property(o => o.Name).IsRequired().HasMaxLength(10);
                o.HasOne<IdentityUser>()
                .WithMany()
                .HasForeignKey(o => o.CreatorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
