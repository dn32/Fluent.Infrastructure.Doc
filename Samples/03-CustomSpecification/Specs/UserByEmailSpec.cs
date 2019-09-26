using System.Linq;
using Fluent.Architecture.Specifications;

namespace CustomSpecification
{
    public class UserByEmailSpec : FluentSpecification<User>
    {
        public string Email { get; set; }

        public UserByEmailSpec SetParameter(string email)
        {
            Email = email;
            return this;
        }

        public override IQueryable<User> Where(IQueryable<User> query)
        {
            return query.Where(x => x.Email.Equals(Email));
        }

        public override IOrderedQueryable<User> Order(IQueryable<User> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }
}
