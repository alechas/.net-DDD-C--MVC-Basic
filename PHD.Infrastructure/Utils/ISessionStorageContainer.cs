

namespace PHD.Infrastructure.Utils
{
    public interface ISessionStorageContainer<IT>
    {
        IT GetCurrentSession();
        void Store(IT session);
    }
}
