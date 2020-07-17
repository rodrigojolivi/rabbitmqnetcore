using RabbitMQ.Publisher.Domain;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> RegisterUser(User user)
        {
            return Task.FromResult(user);
        }
    }
}
