using Fluent.Architecture.Entities;
using Fluent.Architecture.EntityFramework;

namespace MultipleDatabases
{
    [DbType(FluentDbType.SQLITE, "tanant_db")]
    public abstract class BaseTenantEntity : FluentEntity
    {
    }
}