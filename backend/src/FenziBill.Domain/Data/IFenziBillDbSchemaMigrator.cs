using System.Threading.Tasks;

namespace FenziBill.Data;

public interface IFenziBillDbSchemaMigrator
{
    Task MigrateAsync();
}
