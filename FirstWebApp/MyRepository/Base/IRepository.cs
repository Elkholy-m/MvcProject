namespace FirstWebApp.MyRepository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> FindAll();

        // Async methods
        Task<T> FindByIdAsync(int id);
        Task<IEnumerable<T>> FindAllAsync();
    }
}
