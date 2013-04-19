using NHibernate;

namespace Session.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}
