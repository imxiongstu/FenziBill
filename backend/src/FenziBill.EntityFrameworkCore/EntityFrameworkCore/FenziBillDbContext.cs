using FenziBill.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users;

namespace FenziBill.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class FenziBillDbContext :
    AbpDbContext<FenziBillDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    #region 框架自带
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<AccountBook> AccountBooks { get; set; }
    public DbSet<AccountBookLine> AccountBookLines { get; set; }
    public DbSet<Relation> Relations { get; set; }


    public ICurrentUser CurrentUser => LazyServiceProvider.LazyGetRequiredService<ICurrentUser>();

    public FenziBillDbContext(DbContextOptions<FenziBillDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.EntityConfigure();
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureIdentityServer();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
    }

    protected bool IMayHaveCreatorFilterEnabled => DataFilter?.IsEnabled<IMayHaveCreator>() ?? false;

    protected override bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType)
    {
        //如果不是HttpApi服务，则禁用过滤
        if (Process.GetCurrentProcess().ProcessName != "FenziBill.HttpApi.Host")
        {
            return false;
        }

        if (typeof(IMayHaveCreator).IsAssignableFrom(typeof(TEntity)))
        {
            return true;
        }

        return base.ShouldFilterEntity<TEntity>(entityType);
    }

    protected override Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
    {
        var expression = base.CreateFilterExpression<TEntity>();

        //实现用户数据隔离过滤
        if (typeof(IMayHaveCreator).IsAssignableFrom(typeof(TEntity)))
        {
            //只筛选出CreatorId为当前用户Id的数据
            Expression<Func<TEntity, bool>> isActiveFilter =
            e => !IMayHaveCreatorFilterEnabled || EF.Property<Guid>(e, "CreatorId") == CurrentUser.Id;
            expression = expression == null
                ? isActiveFilter
                : CombineExpressions(expression, isActiveFilter);
        }

        return expression;
    }
}
