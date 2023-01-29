using DatabaseHandler.Context;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHandler.Repositories.CommonGenericRepository
{
    public class CommonGenericRepository<T> : ICommonGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public CommonGenericRepository(ApplicationDbContext Context)
        {
            _context = Context;
        }

        public async Task Add(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
        }

        public async Task<string> AddSome(IEnumerable<T> Entities)
        {
            IEnumerable<T> _entities = Entities;
            string To_return;
            try
            {
                foreach(var entity in _entities)
                {
                    _context.Set<T>().AddAsync(entity);
                }
                To_return = "list added successfully";
            }
            catch(Exception ex)
            {
                To_return = ex.Message;
            }
            return To_return;
        }

        public async Task Delete(T Entity)
        {
            _context.Set<T>().Remove(Entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            //  return _context.Set<T>().ToList();
            var Entities = await _context.Set<T>().ToListAsync<T>();
            return Entities;
        }

        public async Task Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
        }
    }
}
