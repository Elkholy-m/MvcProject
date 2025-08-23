using FirstWebApp.Data;
using FirstWebApp.Models;
using FirstWebApp.MyRepository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FirstWebApp.MyRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext context;

        public Repository(AppDbContext context)
        {
            this.context = context;
        }

        public void AddMany(IEnumerable<T> itemList) => context.Set<T>().AddRange(itemList);
        public void AddOne(T item) => context.Set<T>().Add(item);
        public void DeleteMany(IEnumerable<T> itemList) => context.Set<T>().RemoveRange(itemList);
        public void DeleteOne(T item) => context.Set<T>().Remove(item);
        public void UpdateMany(IEnumerable<T> itemList) => context.Set<T>().UpdateRange(itemList);
        public void UpdateOne(T item) => context.Set<T>().Update(item);


        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public IEnumerable<T> FindAll(params string[] eagers)
        {
            IQueryable<T> query = context.Set<T>();
            if (eagers.Length > 0)
            {
                foreach (string eager in eagers)
                {
                    // Eiger loading to fill the navigation property with values
                    query = query.Include(eager);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] eagers)
        {
            IQueryable<T> query = context.Set<T>();
            if (eagers.Length > 0)
            {
                foreach (var eager in eagers)
                    query = query.Include(eager);
            }
            return await query.ToListAsync();
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id) ?? throw new Exception("Entity Not Found");
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id) ?? throw new Exception("Entity Not Found");
        }

        public T SelectOne(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate) ?? throw new Exception("Entity Not Found");
        }

        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().FirstOrDefaultAsync(predicate) ?? throw new Exception("Entity Not Found");
        }
    }
}
