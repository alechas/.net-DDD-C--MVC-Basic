using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate;

namespace TRIMS.Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        T FindBy(TId id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCriteria(List<ICriterion> critorions, out int TotalRecord, int index, int count, string sort, string dir);
        IEnumerable<T> FindByCriteriaQuery(ICriteria criteriaQuery, out int TotalRecord, int index, int count, string sort, string dir);
        //IEnumerable<T>
    }
}
