using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;
using Session.SessionStorage;
using Session.Domain;

namespace Service.Abstract
{
    public abstract class AbstractService<T, TEntityKey> where T : IAggregateRoot
    {
        public T FindBy(TEntityKey id)
        {
            T entity = SessionFactory.Instance.GetCurrentSession().Get<T>(id);
            //  entity.AfterLoad();
            entity.Bersih();
            return entity;
        }
        public T FindByCriteria(List<ICriterion> critorions)
        {
            ICriteria criteriaQuery = SessionFactory.Instance.GetCurrentSession().CreateCriteria(typeof(T));
            if (critorions != null)
            {
                foreach (var crit in critorions)
                    criteriaQuery.Add(crit);
            }
            //  entity.AfterLoad();
            List<T> Datum = (List<T>)criteriaQuery.List<T>();
            T entity = Datum.FirstOrDefault<T>();
            if (entity != null)
            {
                entity.Bersih();
            }
            return entity;
        }

        public IEnumerable<T> FindAllByCriteria(List<ICriterion> critorions, out int TotalRecord, int index, int count, string sort, string dir)
        {
            ICriteria criteriaQuery = SessionFactory.Instance.GetCurrentSession().CreateCriteria(typeof(T));
            if (critorions != null)
            {
                foreach (var crit in critorions)
                    criteriaQuery.Add(crit);
            }
            TotalRecord = (int)((ICriteria)criteriaQuery.Clone()).SetProjection(Projections.RowCount()).UniqueResult();
            if (sort != null && sort.Length > 2)
            {
                criteriaQuery.AddOrder(new Order(sort, dir.ToLower() == "asc" ? true : false));
            }
            criteriaQuery.SetFirstResult(index);
            if (count > 0)
            {
                criteriaQuery.SetMaxResults(count);
            }
            List<T> Datas = (List<T>)criteriaQuery.List<T>();
            foreach (T Data in Datas) {
                if (Data != null)
                {
                    Data.Bersih();
                }
               
            }
            return Datas;
        }

        public IEnumerable<T> FindAllByCriteriaQuery(ICriteria criteriaQuery, out int TotalRecord, int index, int count, string sort, string dir)
        {
            TotalRecord = (int)((ICriteria)criteriaQuery.Clone()).SetProjection(Projections.RowCount()).UniqueResult();
            if (sort != null && sort.Length > 2)
            {
                criteriaQuery.AddOrder(new Order(sort, dir.ToLower() == "asc" ? true : false));
            }
            criteriaQuery.SetFirstResult(index);
            if (count > 0)
            {
                criteriaQuery.SetMaxResults(count);
            }
            List<T> Datas = (List<T>)criteriaQuery.List<T>();
            foreach (T Data in Datas)
            {
                if (Data != null)
                {
                    Data.Bersih();
                }

            }
            return Datas;
        }

        public IEnumerable<T> FindAll()
        {
            ICriteria criteriaQuery =
            SessionFactory.Instance.GetCurrentSession().CreateCriteria(typeof(T));
            List<T> Datas = (List<T>)criteriaQuery.List<T>();
            foreach (T Data in Datas)
            {
                if (Data != null)
                {
                    Data.Bersih();
                }

            }
            return Datas;
        }
        public IEnumerable<T> FindAllByHql(string hql) {
            IQuery criteriaQuery = SessionFactory.Instance.GetCurrentSession().CreateQuery( hql);
            List<T> Datas = (List<T>)criteriaQuery.List<T>();
            foreach (T Data in Datas)
            {
                if (Data != null)
                {
                    Data.Bersih();
                }

            }
            return Datas;
        }
        public T FindByHql(string hql)
        {
            IQuery criteriaQuery = SessionFactory.Instance.GetCurrentSession().CreateQuery(hql);
            T data = criteriaQuery.List<T>().FirstOrDefault();
            if (data != null)
            {
                data.Bersih();
            }
            return data;
        }
    }
}
