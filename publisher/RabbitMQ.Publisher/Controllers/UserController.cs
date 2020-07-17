using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Publisher.Bus;
using RabbitMQ.Publisher.Domain;
using RabbitMQ.Publisher.Repositories;
using RabbitMQ.Publisher.ViewModels;
using System.Threading.Tasks;

namespace RabbitMQ.Publisher.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUser(
            [FromServices] IUserRepository userRepository,
            [FromBody]UserViewModel userViewModel)
        {
            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.Password);
            var result = await userRepository.RegisterUser(user);

            await MessageBus.Publish("registerUserQueue", result);

            return Ok(result);
        }
    }
}

