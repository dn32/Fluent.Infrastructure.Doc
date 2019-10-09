using Fluent.Architecture.Redis;
using Fluent.Architecture.Services;
using System.Threading.Tasks;

namespace Redis
{
    public class UserService : FluentService<User>
    {
        protected virtual FluentRedisService RedisService => null;

        public override async Task<User> AddAsync(User entity)
        {
            var userAdded = await base.AddAsync(entity);
            await RedisService.SetFluentEntityAsync(userAdded);
            return userAdded;
        }

        public override async Task<User> FindAsync(User entity, bool checkId = true)
        {
            var userOnMemory = await RedisService.GetFluentEntityAsync<User>(entity);
            if (userOnMemory == null)
            {
                var userFinded = await base.FindAsync(entity, checkId);
                await RedisService.SetFluentEntityAsync(userFinded);
                return userFinded;
            }

            return userOnMemory;
        }
    }
}
