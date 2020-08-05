using System.Collections.Generic;
using System.Threading.Tasks;

using Bravado.Data;
using Bravado.Interfaces;
using Bravado.Models.Agile;

namespace Bravado.Repos {
    public class BoardRepository : IBoardRepository {
        private readonly AppDbContext _dbContext;

        public BoardRepository (AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Add<T> (T entity) where T : class {
            throw new System.NotImplementedException ();
        }

        public void Delete<T> (T entity) where T : class {
            throw new System.NotImplementedException ();
        }

        public Task<Board> GetBoardByIdAsync (int id) {
            throw new System.NotImplementedException ();
        }

        public Task<List<Board>> GetBoardsAsync () {
            throw new System.NotImplementedException ();
        }

        public Task<bool> SaveAllChangesAsync () {
            throw new System.NotImplementedException ();
        }
    }
}