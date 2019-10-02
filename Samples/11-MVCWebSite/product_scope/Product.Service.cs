using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.Entities;
using Fluent.Architecture.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCWebSite.brand_scope;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebSite.product_scope
{
    public class ProductService : FluentService<Product>
    {
        protected virtual FluentService<Brand> BrandService => null;

        public async Task<IEnumerable<SelectListItem>> GetBrandsAsync()
        {
            var spec = CreateSpec<BrandSelectListItemSpec>();
            var viewModel = await BrandService.ListAsync(spec, new FluentPagination(0, true, int.MaxValue));
            return viewModel.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public async Task UpdateProductsValue(decimal increasePercentage)
        {
            var allProducts = await base.ListAsync(CreateSpec<FluentAllSpec<Product>>(), new FluentPagination(0, true, int.MaxValue));
            allProducts.ForEach(x => x.Value *= increasePercentage);
            await base.UpdateRangeAsync(allProducts);
        }
    }
}
