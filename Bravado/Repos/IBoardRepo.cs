using System.Collections.Generic;
using System.Threading.Tasks;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public interface IBoardRepo : IGenericRepository
    {
        Task<List<Board>> GetBoardsAsync();
        Task<Board> GetBoardByIdAsync(int id);
    }
}