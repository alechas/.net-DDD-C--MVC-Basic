using PHD.Session.Domain;

namespace PHD.Session.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterNew(IAggregateRoot entity);
    }
}
