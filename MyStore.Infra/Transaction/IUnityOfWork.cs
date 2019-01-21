namespace MyStore.Infra.Transaction
{
    public interface IUnityOfWork
    {
        void Commit();
        void Rollback();
    }
}
