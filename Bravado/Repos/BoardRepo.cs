using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bravado.Data;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public class BoardRepo : IBoardRepo
    {
        private readonly AppDbContext _dbContext;

        public BoardRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Board> GetBoardByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Board>> GetBoardsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveAllChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}