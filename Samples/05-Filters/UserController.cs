using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Enumerator;
using Fluent.Architecture.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CustomSpecification
{
    [Route("/api/[Controller]/[Action]")]
    public class UserController : FluentController<User>
    {

        [HttpPost]
        [Route("/api/[controller]/ListByFilter")]
        [Description("Get a paginated list of items based on filters")]
        public virtual async Task<DefaultPaginationResult> ListByFilterPost([FromBody] Filter[] filters)
        {
            return await InternalListByFilterAsync(filters);
        }

        private async Task<DefaultPaginationResult> InternalListByFilterAsync([FromBody] Filter[] filters)
        {
            var spec = CreateSpec<FluentFilterSpec<User>>().SetParameter(filters, isList: true);
            return await ResultAsync(Service.ListAsync(spec), LastRequestPagination);
        }
    }

    //public class FluentFilterSpec<T> : FluentSpecification<T> where T : FluentEntity
    //{
    //    private Filter[] Filters { get; set; }

    //    public bool IsList { get; set; }

    //    public FluentFilterSpec<T> SetParameter(Filter[] filters, bool isList)
    //    {
    //        Filters = filters;
    //        IsList = isList;
    //        return this;
    //    }

    //    public override IQueryable<T> Where(IQueryable<T> query)
    //    {
    //        var expression = Filters.FiltersToExtression<T>();
    //        query = query.GetInclusions(IsList);
    //        query = query.Where(expression);
    //        return query;
    //    }

    //    public override IOrderedQueryable<T> Order(IQueryable<T> query)
    //    {
    //        return query.OrderBy(x => x);
    //    }
    //}

    //    public class FluentFilterOracleSpec<TE> : FluentFilterSpec<TE> where TE : FluentEntity
    //    {
    //        //private string Term { get; set; }

    //        //private string TableName { get; set; }

    //        //private string ColumnName { get; set; }

    //        //private int Tolerance { get; set; }

    //        //public FluentFilterOracleSpec<TE> AddParameter(string property, string term, int tolerance)
    //        //{
    //        //    TableName = typeof(TE).GetTableName();
    //        //    ColumnName = typeof(TE).GetProperties().FirstOrDefault(x => x.Name.Equals(property, StringComparison.InvariantCultureIgnoreCase))?.GetColumnName() ?? throw new Exception($"Property not found {typeof(TE).Name}.{property}");
    //        //    Term = term;
    //        //    Tolerance = tolerance;
    //        //    return this;
    //        //}

    //        public override IQueryable<TE> Where(IQueryable<TE> query)
    //        {
    //            IgnoreOrder = true;
    //            if (string.IsNullOrWhiteSpace(Term)) { return query.OrderBy(x => x); }

    //            var dbSet = query as DbSet<TE>;
    //            var sql = $@"
    //select * from {TableName}
    //where UTL_MATCH.jaro_winkler_similarity(lower({ColumnName}), lower({{0}})) > {Tolerance}
    //order by UTL_MATCH.jaro_winkler_similarity(lower({ColumnName}), lower({{0}})) DESC
    //";

    //#if NETCOREAPP3_0
    //            return dbSet.FromSqlRaw(sql, Term);
    //#else
    //            return dbSet.FromSql(sql, Term);
    //#endif
    //        }

    //        public override IOrderedQueryable<TE> Order(IQueryable<TE> query) => throw new NotImplementedException();
    //    }

}
