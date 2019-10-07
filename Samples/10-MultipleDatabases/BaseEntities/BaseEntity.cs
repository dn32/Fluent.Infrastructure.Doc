using Fluent.Architecture.EntityFramework;
using Fluent.Architecture.Core.Models;

namespace MultipleDatabases
{
    [DbType(FluentDbType.SQLITE, "client_db")]
    public abstract class BaseEntity : FluentEntity
    {
    }
}