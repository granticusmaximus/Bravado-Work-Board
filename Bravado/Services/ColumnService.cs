using Bravado.Data;
using Bravado.Models.Agile;

namespace Bravado.Services
{
    public class ColumnService
    {
        private readonly AppDbContext _dbContext;

        public ColumnService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Column viewModel)
        {
        }

        public void Update(Column column)
        {
        }

        public void Delete(int id)
        {
        }
    }
}