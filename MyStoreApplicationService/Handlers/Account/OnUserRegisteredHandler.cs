using DomainNotificationHelper;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.ApplicationService.Services.Common;
using System.Collections.Generic;

namespace MyStore.ApplicationService.Handlers.Account
{
    public class OnUserRegisteredHandler : IHandler<OnUserRegisteredEvent>
    {
        public void Dispose()
        {
        }

        public void Handle(OnUserRegisteredEvent args)
        {
            var user = args.User;
            var title = args.EmailTitle;
            var body = args.EmailBody.Replace("##EMAIL##", args.User.Email);

            EmailService.Send(user.Email, title, body);
        }

        public bool HasNotifications()
        {
            return false;
        }

        public IEnumerable<OnUserRegisteredEvent> Notify()
        {
            return null;
        }
    }
}
