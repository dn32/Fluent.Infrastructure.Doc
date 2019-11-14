using Fluent.Architecture.Core.Specifications;
using Fluent.Architecture.Specifications;
using System.Linq;

namespace CustomSpecification
{
    public class NameAndAgeOfAdultsViewModelSpec : FluentSelectSpecification<User, UserNameAndAge>
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

    public class NameAndAgeOfAdultsSpec : FluentDynamicSpec<User>
    {
        public override IQueryable<User> Where(IQueryable<User> query)
        {
            return base.Where(query.Where(x => x.Age >= 18));
        }

        public override IOrderedQueryable<User> Order(IQueryable<User> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }
}
