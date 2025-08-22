namespace FirstWebApp.MyRepository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
    }
}
