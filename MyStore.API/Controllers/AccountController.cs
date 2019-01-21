using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Services;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyStore.API.Controllers
{
    [RoutePrefix("api/v1")]
    public class AccountController : BaseController
    {
        private readonly IUserApplicationService _service;

        public AccountController(IUserApplicationService userService)
        {
            _service = userService;
        }

        [HttpPost]
        [Route("account")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var command = new RegisterUserCommand(
                email: (string)body.email,
                username: (string)body.username,
                password: (string)body.password
            );

            var user = _service.Register(command);

            return this.CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpGet]
        [Route("account")]
        public Task<HttpResponseMessage> Get()
        {
            return this.CreateResponse(HttpStatusCode.Created, new { message = "API Online" });
        }
    }
}