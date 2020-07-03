using System.Collections.Generic;
using System.Threading.Tasks;
using Bravado.Models;

namespace Bravado.Interfaces
{
    public interface IBoardRepository : IGenericRepository
    {
        Task<List<Board>> GetBoardsAsync();
        Task<Board> GetBoardByIdAsync(int id);
    }
}