using DomainNotificationHelper;
using DomainNotificationHelper.Events;
using MyStore.Infra.Transaction;

namespace MyStore.ApplicationService.Services
{
    public class ApplicationService
    {
        private readonly IHandler<DomainNotification> _notification;
        private readonly IUnityOfWork _unitOfWork;

        public ApplicationService(IUnityOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notification = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
        }

        public bool Commit()
        {
            if (_notification.HasNotifications())
                return false;

            _unitOfWork.Commit();
            return true;
        }

        public void Rollback(string message)
        {
            DomainEvent.Raise<DomainNotification>(new DomainNotification("BusinessErros", message));
            _unitOfWork.Rollback();
        }

        public void Rollback()
        {
            _unitOfWork.Rollback();
        }
    }
}
