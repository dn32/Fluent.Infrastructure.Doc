using Fluent.Architecture.Entities;
using Fluent.Architecture.EntityFramework;

namespace MultipleDatabases
{
    [DbType(FluentDbType.SQLITE, "client_db")]
    public abstract class BaseEntity : FluentEntity
    {
    }
}