using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FenziBill.Data;

/* This is used if database provider does't define
 * IFenziBillDbSchemaMigrator implementation.
 */
public class NullFenziBillDbSchemaMigrator : IFenziBillDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
