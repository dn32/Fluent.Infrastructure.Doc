using Fluent.Architecture.Core.Models;
using Fluent.Architecture.EntityFramework.Specifications;
using Fluent.Architecture.Extensions;
using Fluent.Architecture.Interfaces;
using Fluent.Architecture.Services;
using SimpleHelloWorld;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sql.scope
{
    public class UserService : FluentService<User>
    {
        public override async Task<List<User>> ListAsync(IFluentSpecification spec, FluentPagination pagination = null)
        {
            var tableName = typeof(User).GetTableName();
            var collumName = typeof(User).GetProperty("Code").GetColumnName();
            var sql = $"select * from {tableName} where {collumName} = {{0}}";

            var newSpec = CreateSpec<FluentSqlSpec<User>>().SetParameter(sql, 45);
            return await base.ListAsync(newSpec, pagination);
        }
    }
}