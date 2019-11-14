using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Models;
using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.EntityFramework.Specifications;
using Microsoft.AspNetCore.Mvc;
using SimpleHelloWorld;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pagination.scope
{
    public class UserController : FluentController<User>
    {
        [HttpGet]
        public async Task<DefaultPaginationResult<List<User>>> ListAll(int currentPage, int itemsPerPage)
        {
            var spec = CreateSpec<FluentSqlSpec<User>>();
            var pagination = new FluentPagination(currentPage, itemsPerPage: itemsPerPage);
            var list = await Service.ListAsync(spec, pagination);
            return await ResultAsync<List<User>>(list, pagination);
        }

        /// <summary>
        /// No exemplo abaixo, envie os parâmetros pelo header da requisição:
        /// CurrentPage
        /// ItemsPerPage
        /// StartAtZero
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<DefaultPaginationResult<List<User>>> ListAllAlternative()
        {
            var spec = CreateSpec<FluentSqlSpec<User>>();
            var list = await Service.ListAsync(spec);
            return await ResultAsync<List<User>>(list, LastRequestPagination);
        }
    }
}
