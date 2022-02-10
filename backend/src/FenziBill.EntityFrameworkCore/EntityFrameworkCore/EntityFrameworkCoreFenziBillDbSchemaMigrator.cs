using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FenziBill.Data;
using Volo.Abp.DependencyInjection;

namespace FenziBill.EntityFrameworkCore;

public class EntityFrameworkCoreFenziBillDbSchemaMigrator
    : IFenziBillDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFenziBillDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FenziBillDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FenziBillDbContext>()
            .Database
            .MigrateAsync();
    }
}
