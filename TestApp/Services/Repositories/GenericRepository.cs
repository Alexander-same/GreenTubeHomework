using System.Data.Entity;
using TestApp.Services.Data;
using TestApp.Services.Interfaces;

namespace TestApp.Services.Repositories
{
    public class GenericRepository<T> : IGenericReporistory<T> where T : class
    {
        protected EmptyContext _context = null;
        protected DbSet<T> table = null;
        public GenericRepository()
        {
            _context = new EmptyContext();
            table = _context.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            table.Add(entity);
            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            T existing = await table.FindAsync(entity);
            table.Remove(existing);
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await table.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
