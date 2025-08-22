using FirstWebApp.Data;
using FirstWebApp.MyRepository.Base;

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

        public T FindById(int id)
        {
            return context.Set<T>().Find(id) ?? throw new Exception("Entity Not Found");
        }
    }
}
