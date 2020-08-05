using System.Threading.Tasks;

namespace Bravado.Interfaces {
    public interface IGenericRepository {
        void Add<T> (T entity) where T : class;

        void Delete<T> (T entity) where T : class;

        Task<bool> SaveAllChangesAsync ();
    }
}