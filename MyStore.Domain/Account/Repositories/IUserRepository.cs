using MyStore.Domain.Account.Entites;

namespace MyStore.Domain.Account.Repositories
{
    public interface IUserRepository
    {
        void Save(User user);
        void Update(User user);
        User GetUserByUsername(string username);
        User GetByAuthorizationCode(string authorizationCode);
    }
}
