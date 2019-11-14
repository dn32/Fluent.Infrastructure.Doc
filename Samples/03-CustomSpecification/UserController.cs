using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CustomSpecification
{
    [Route("/api/[Controller]/[Action]")]
    public class UserController : FluentController<User>
    {
        //http://localhost:5000/api/User/FindByEmail?email=test02@test.com.br
        public async Task<User> FindByEmail(string email)
        {
            var spec = CreateSpec<UserByEmailSpec>().SetParameter(email);
            return await Service.FirstOrDefaultAsync(spec);
        }

        public async Task<List<User>> ListTeens()
        {
            var minAge = 12;
            var maxAge = 18;
            var spec = CreateSpec<UserByAgeRangeEmailSpec>().SetParameter(minAge, maxAge);
            return await Service.ListAsync(spec);
        }

        public async Task<List<UserNameAndAge>> ListAdultsByViewModel()
        {
            var spec = CreateSpec<NameAndAgeOfAdultsViewModelSpec>();
            return await Service.ListSelectAsync(spec);
        }

        public async Task<List<User>> ListAdults()
        {
            var spec = CreateSpec<NameAndAgeOfAdultsSpec>().SetParameters(new string[] { nameof(CustomSpecification.User.Name), nameof(CustomSpecification.User.Age) }, true);
            return await Service.ListAsync(spec);
        }

        [Description("List all users")]
        public async Task<List<User>> List()
        {
            var spec = CreateSpec<FluentAllSpec<User>>();
            return await Service.ListAsync(spec);
        }

        [HttpPost]
        public async Task<User[]> AddRange([FromBody] User[] users)
        {
            await Service.AddRangeAsync(users);
            return users;
        }
    }
}
