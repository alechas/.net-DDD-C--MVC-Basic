using Session.Domain;

namespace Session.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterNew(IAggregateRoot entity);
    }
}
