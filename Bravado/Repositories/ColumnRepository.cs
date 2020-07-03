using System;
using Bravado.Data;

namespace Bravado.Repositories
{
    public class ColumnRepository
    {
        private readonly AppDbContext _dbContext;

        public ColumnRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}