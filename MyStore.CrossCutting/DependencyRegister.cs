using MyStore.ApplicationService.Handlers.Account;
using MyStore.ApplicationService.Services.Account;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infra.Persistence.Contexts;
using MyStore.Infra.Repositories.Account;
using MyStore.Infra.Transaction;
using DomainNotificationHelper;
using DomainNotificationHelper.Events;
using DomainNotificationHelper.Handlers;
using Unity;
using Unity.Lifetime;

namespace MyStore.CrossCutting
{
   public class DependencyRegister
    {
        public static void Register(UnityContainer container)
        {
            container.RegisterType<MyStoreDataContext, MyStoreDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnityOfWork, UnityOfWork>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IUserApplicationService, UserApplicationService>(
                new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<DomainNotification>, DomainNotificationHandler>(
                new HierarchicalLifetimeManager());

            container.RegisterType<IHandler<OnUserRegisteredEvent>, OnUserRegisteredHandler>();
        }
    }
}
