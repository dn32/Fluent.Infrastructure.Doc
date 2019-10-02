using Fluent.Architecture.Specifications;
using System.Linq;

namespace MVCWebSite.brand_scope
{
    public class BrandSelectListItemSpec : FluentSpecification<Brand>
    {
        public override IQueryable<Brand> Where(IQueryable<Brand> query)
        {
            return query;
        }

        public override IOrderedQueryable<Brand> Order(IQueryable<Brand> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }

    /*
        It is possible to query by specifying a return type as a view model,
        but there is a bug in the Entity Framework that is temporarily preventing this.
   */

    //public class BrandSelectListItemSpec : FluentSelectSpecification<Brand, BrandViewModel>
    //{
    //    public override IQueryable<BrandViewModel> Where(IQueryable<Brand> query)
    //    {
    //        return query.Select(x => new BrandViewModel(x.Name, x.Id));
    //    }

    //    public override IOrderedQueryable<BrandViewModel> Order(IQueryable<BrandViewModel> query)
    //    {
    //        return query.OrderBy(x => x.Name);
    //    }
    //}
}
