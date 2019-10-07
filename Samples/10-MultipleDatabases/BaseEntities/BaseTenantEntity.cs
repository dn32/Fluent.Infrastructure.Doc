using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.Core.Models;

namespace MultipleDatabases
{
    [DbType(FluentDbType.SQLITE, "tanant_db")]
    public abstract class BaseTenantEntity : FluentEntity
    {
    }
}