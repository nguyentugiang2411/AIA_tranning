using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> findAll();
        T findById(int i);
        bool create(T entity);
        bool update(T entity);
        bool delete(T entity);
        bool save();
    }
}
