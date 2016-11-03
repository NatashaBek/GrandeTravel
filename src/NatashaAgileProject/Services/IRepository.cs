using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using System.Linq.Expressions;

namespace NatashaAgileProject.Services
{
    public interface IRepository <T>
    {
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
