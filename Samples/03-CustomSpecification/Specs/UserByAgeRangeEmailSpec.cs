using System.Linq;
using Fluent.Architecture.Specifications;

namespace CustomSpecification
{
    public class UserByAgeRangeEmailSpec : FluentSpecification<User>
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public UserByAgeRangeEmailSpec SetParameter(int minAge, int maxAge)
        {
            MinAge = minAge;
            MaxAge = maxAge;
            return this;
        }

        public override IQueryable<User> Where(IQueryable<User> query)
        {
            return query.Where(x => x.Age >= MinAge && x.Age <= MaxAge);
        }
    }

}
