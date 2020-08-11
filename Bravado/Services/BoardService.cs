using System.Collections.Generic;
using Bravado.Models.Agile;
using Bravado.Repos;

namespace Bravado.Services
{
    public class BoardService : IBoardService
    {
        private IBoardRepo _boardRepo;

        public BoardService(IBoardRepo boardRepo)
        {
            _boardRepo = boardRepo;
        }
        public IEnumerable<Card> GetCardList()
        {
            return _boardRepo.GetCardList();
        }

        public IEnumerable<Column> GetColumnList()
        {
            return _boardRepo.GetColumnList();
        }
    }
}