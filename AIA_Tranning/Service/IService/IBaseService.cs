using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIA_Tranning.Service.IService
{
    public interface IBaseService<T> where T : class
    {
        ICollection<T> getAll();
        T getById(int id);
        bool create(T entity);
        bool update(T entity);
        bool delete(T entity);
        bool isExist(int id);
    }
}
