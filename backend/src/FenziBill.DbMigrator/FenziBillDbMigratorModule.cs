using FenziBill.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FenziBill.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FenziBillEntityFrameworkCoreModule),
    typeof(FenziBillApplicationContractsModule)
    )]
public class FenziBillDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
