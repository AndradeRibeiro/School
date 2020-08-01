using Microsoft.EntityFrameworkCore;
using School.Domain.Interfaces.Repository;
using School.Infra.Context;
using System.Collections.Generic;
using System.Linq;

namespace School.Infra.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SchoolContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(SchoolContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);
        
        public void Save(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
