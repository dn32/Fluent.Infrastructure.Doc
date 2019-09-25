using System.Collections.Generic;
using System.ComponentModel;
using Fluent.Architecture.Controllers;
using Fluent.Architecture.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace CustomSpecification
{
    [Route("/api/[Controller]/[Action]")]
    public class UserController : FluentController<User>
    {
        //http://localhost:5000/api/User/FindByEmail?email=test02@test.com.br
        public User FindByEmail(string email)
        {
            var spec = CreateSpec<UserByEmailSpec>().SetParameter(email);
            return Service.FirstOrDefault(spec);
        }

        public List<User> ListTeens()
        {
            var minAge = 12;
            var maxAge = 18;
            var spec = CreateSpec<UserByAgeRangeEmailSpec>().SetParameter(minAge, maxAge);
            return Service.List(spec);
        }

        public List<UserNameAndAge> ListAdults()
        {
            var spec = CreateSpec<NameAndAgeOfAdultsSpec>();
            return Service.ListSelect(spec);
        }

        [Description("List all users")]
        public List<User> List()
        {
            var spec = CreateSpec<FluentAllSpec<User>>();
            return Service.List(spec);
        }

        [HttpPost]
        public User[] AddRange([FromBody] User[] users)
        {
            Service.AddRange(users);
            return users;
        }
    }
}
