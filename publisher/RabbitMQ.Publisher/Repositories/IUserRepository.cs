using RabbitMQ.Publisher.Domain;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterUser(User user);
    }
}
