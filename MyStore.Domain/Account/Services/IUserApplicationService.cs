using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entites;

namespace MyStore.Domain.Account.Services
{
    public interface IUserApplicationService
    {
        User Register(RegisterUserCommand command);
    }
}
