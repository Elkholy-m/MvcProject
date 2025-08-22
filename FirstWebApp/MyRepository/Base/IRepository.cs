using System.Linq.Expressions;

namespace FirstWebApp.MyRepository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(params string[] eagers);

        // Search by using fat arrow function
        T SelectOne(Expression<Func<T, bool>> predicate);

        // Async methods
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
        Task<IEnumerable<T>> FindAllAsync(params string[] eagers);
        Task<T> SelectOneAsync(Expression<Func<T, bool>> predicate);

        // CRUD Operations Mehtods
        void AddOne(T item);
        void UpdateOne(T item);
        void DeleteOne(T item);
        void AddMany(IEnumerable<T> itemList);
        void UpdateMany(IEnumerable<T> itemList);
        void DeleteMany(IEnumerable<T> itemList);
    }
}
