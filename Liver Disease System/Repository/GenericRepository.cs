namespace Liver_Disease_System.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _Context;

        public GenericRepository(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[]includes)
        {
            IQueryable<T>query = _Context.Set<T>();
            if(includes!=null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            var entity = await _Context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }
            return entity;
        }
        public async Task<T> GetByEntity(Expression<Func<T,bool>>Predicate)
        {
            var entity = await _Context.Set<T>().FirstOrDefaultAsync(Predicate);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {entity} not found");
            }
            return entity;
        }
        public async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            await _Context.Set<T>().AddAsync(entity);
            return entity;

        }
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null");
            }
            _Context.Set<T>().Update(entity);
            return entity;

        }
        public async Task<T> Delete(int id)
        {
            var entity = _Context.Set<T>().Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found");
            }
            _Context.Set<T>().Remove(entity);
            return entity;
        }
        public async Task<bool> Complete()=>await _Context.SaveChangesAsync() > 0;
    }
}
