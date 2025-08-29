namespace Liver_Disease_System.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes);
        Task<T> GetById(int id);
        Task<T> GetByEntity(Expression<Func<T, bool>> Predicate);
        Task<T> Add(T entity);
        T Update(T entity);
        Task<T> Delete(int id);
        Task<bool> Complete();
    }
}
