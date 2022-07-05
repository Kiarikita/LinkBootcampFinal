using System.Linq.Expressions;

namespace FinalProject.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();
        /*Yazılan sorgular veritabanına gitmez, memoryde birleştirilir 
         * tek seferde (tolist etc. çağrıldığında) veritabanına gönderilir*/
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
