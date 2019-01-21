using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entites;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infra.Transaction;

namespace MyStore.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _userRepository;

        public UserApplicationService(IUserRepository userRepository,
                                      IUnityOfWork unitOfWork) : base(unitOfWork)
        {
            _userRepository = userRepository;
        }

        public User Register(RegisterUserCommand command)
        {
            //Cria a instancia do usuario
            var user = new User(command.Email, command.UserName, command.Password);
            //Tentar registrar o usuário
            user.Register();

            //Chama o commit
            if (Commit())
            {

                // Dispara o evento de usuario registrado
                DomainEvent.Raise(new OnUserRegisteredEvent(user));
                // Retonar o usuario
                return user;
            }

            // Se não comitou, retorna nulo
            return null;
        }
    }
}
