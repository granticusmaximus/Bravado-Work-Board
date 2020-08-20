using System.Collections.Generic;
using Bravado.Data;
using Bravado.Models.Agile;
using Bravado.Repos;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Services
{
    public class BoardService
    {
        private IBoardRepo _boardRepo;
        private readonly AppDbContext _dbContext;

        public BoardService(IBoardRepo boardRepo, AppDbContext dbContext)
        {
            _boardRepo = boardRepo;
            _dbContext = dbContext;
        }

        public ColumnDetails GetDetails(int id)
        {
            var column = _dbContext
                .Columns
                .Include(c => c.Board)
                .SingleOrDefaultAsync(x => x.BoardID == id);
            
            if (column == null)
            {
                return new ColumnDetails();
            }

            
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