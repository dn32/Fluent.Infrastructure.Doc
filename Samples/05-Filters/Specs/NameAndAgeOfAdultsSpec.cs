using Filters;
using Fluent.Architecture.Specifications;
using System.Linq;

namespace CustomSpecification
{
    public class NameAndAgeOfAdultsSpec : FluentSelectSpecification<User, UserNameAndAge>
    {
        public override IQueryable<UserNameAndAge> Where(IQueryable<User> query)
        {
            return query.Where(x => x.Age >= 18).Select(x => new UserNameAndAge { Name = x.Name, Age = x.Age });
        }

        public override IOrderedQueryable<UserNameAndAge> Order(IQueryable<UserNameAndAge> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }
}
