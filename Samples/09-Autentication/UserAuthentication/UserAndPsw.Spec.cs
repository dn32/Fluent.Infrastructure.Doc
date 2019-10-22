using System.Linq;
using Fluent.Architecture.Specifications;

namespace Authentication.UserAuthentication
{
    public class UserAndPswSpec : FluentSpecification<User>
    {
        public string Email { get; set; }
        public string PswMD5 { get; set; }
      
        public UserAndPswSpec AddParameters(string email, string psw)
        {
            Email = email;
            PswMD5 = psw.MD5Hash();

            return this;
        }

        public override IQueryable<User> Where(IQueryable<User> query)
        {
            return query.Where(x => x.Email.Equals(Email, System.StringComparison.InvariantCultureIgnoreCase) && x.MD5Password == PswMD5);
        }

        public override IOrderedQueryable<User> Order(IQueryable<User> query)
        {
            return query.OrderBy(x => x.Name);
        }
    }
}
