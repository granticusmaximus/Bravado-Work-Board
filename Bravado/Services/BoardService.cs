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

        public Board GetBoardByID(int boardID)
        {
            Board board = _boardRepo.GetBoardByID(boardID);
            return board;
        }

        public Card GetCardByID(int cardID)
        {
            Card card = _boardRepo.GetCardByID(cardID);
            return card;
        }

        public IEnumerable<Card> GetCardList()
        {
            return _boardRepo.GetCardList();
        }

        public Column GetColumnByID(int columnID)
        {
            Column column = _boardRepo.GetColumnByID(columnID);
            return column;
        }

        public IEnumerable<Column> GetColumnList(int ID)
        {
            return _boardRepo.GetColumnList(ID);
        }
    }
}