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
                    firstColumn = new Models.Agile.Column { ColumnName = "Backlog"};
                    secondColumn = new Models.Agile.Column { ColumnName = "In Progress" };
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

public BoardList ListBoard()
        {
            var model = new BoardList();

            foreach (var board in _dbContext.Boards)
            {
                model.Boards.Add(new BoardList.Board
                {
                    Id = board.BoardID,
                    Title = board.BoardTitle
                });
            }

            return model;
        }

        public BoardView GetBoard(int id)
        {
            var model = new BoardView();

            var board = _dbContext.Boards
                .Include(b => b.Columns)
                .ThenInclude(c => c.Cards)
                .SingleOrDefault(x => x.BoardID == id);

            if (board == null) return model;
            model.Id = board.BoardID;

            foreach (var column in board.Columns)
            {
                var modelColumn = new BoardView.Column
                {
                    Title = column.ColumnName,
                    Id = column.ColumnID
                };

                foreach (var card in column.Cards)
                {
                    var modelCard = new BoardView.Card
                    {
                        Id = card.CardID,
                        Content = card.CardName
                    };

                    modelColumn.Cards.Add(modelCard);
                }

                model.Columns.Add(modelColumn);
            }

            return model;
        }

        public void AddBoard(NewBoard viewModel)
        {
            _dbContext.Boards.Add(new Models.Agile.Board
            {
                BoardTitle = viewModel.Title
            });

            _dbContext.SaveChanges();
        }

        public void Move(MoveCardCommand command)
        {
            var card = _dbContext.Cards.SingleOrDefault(x => x.CardID == command.CardId);
            if (card != null) card.ColumnID = command.ColumnId;
            _dbContext.SaveChanges();
        }
    }
}