using FirstWebApp.Data;
using FirstWebApp.MyRepository.Base;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApp.MyRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id) ?? throw new Exception("Entity Not Found");
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id) ?? throw new Exception("Entity Not Found");
        }
    }
}
