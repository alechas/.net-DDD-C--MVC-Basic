using System.Collections.Generic;
using NHibernate;
using PHD.Session.SessionStorage;
namespace PHD.Infrastructure.Domain
{
    public abstract class EntityBase<TId>
    {
        public virtual TId Id { get; set; }

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<TId>
                && this == (EntityBase<TId>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if ((object)entity1 == (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }

        public virtual EntityBase<TId> Clone (){
            return (EntityBase<TId>)this.MemberwiseClone();
        }
        public static EntityBase<TId> Get(TId id)
        {
            
                ISession session =
                    SessionFactory.Instance.GetCurrentSession();
                return session.Get<EntityBase<TId>>(id);
            
        }
        public virtual void Save()
        {
            ISession session = SessionFactory.Instance.GetCurrentSession();
            if (!this.IsPersisted)
                session.Save(this);
            else
                session.SaveOrUpdateCopy(this);

            session.Flush();
        }
        public virtual bool IsPersisted
        {
            get
            {
                return this.Id != null;
            }
        }
        public virtual void Delete()
        {
            ISession session = SessionFactory.Instance.GetCurrentSession();
            session.Delete(this);
            session.Flush();
        }
        
       
    }
}
