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
