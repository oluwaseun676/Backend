namespace Core.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
