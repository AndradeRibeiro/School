using System.Collections.Generic;

namespace School.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
