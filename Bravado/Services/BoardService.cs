using System.Collections.Generic;
using System.Linq;
using Bravado.Data;
using Bravado.Models.Agile;
using Bravado.Repos;
using Bravado.ViewModel.AgileViewModels;
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
        
        public void AddCard(AddCard viewModel)
        {
            var board = _dbContext.Boards
                .Include(b => b.Columns)
                .SingleOrDefault(x => x.BoardID == viewModel.Id);

            if (board != null)
            {
                var firstColumn = board.Columns.FirstOrDefault();
                var secondColumn = board.Columns.FirstOrDefault();
                var thirdColumn = board.Columns.FirstOrDefault();
            
                if (firstColumn == null || secondColumn == null || thirdColumn == null)
                {
                    firstColumn = new Models.Agile.Column { ColumnName = "Todo"};
                    secondColumn = new Models.Agile.Column { ColumnName = "Doing" };
                    thirdColumn = new Models.Agile.Column { ColumnName = "Done" };
                    board.Columns.Add(firstColumn);
                    board.Columns.Add(secondColumn);
                    board.Columns.Add(thirdColumn);
                }

                firstColumn.Cards.Add(new Models.Agile.Card
                {
                    CardName = viewModel.Contents,
                    CardNotes = viewModel.Notes,
                    DateCreated = viewModel.DateCreated,
                    DueDate = viewModel.DueDate
                });
            }

            _dbContext.SaveChanges();
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