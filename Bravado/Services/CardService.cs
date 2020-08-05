using System;
using System.Linq;

using Bravado.Data;
using Bravado.ViewModel.TaskViewModels;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Services {
    public class CardService {
        private readonly AppDbContext _dbContext;

        public CardService (AppDbContext dbContext) {
            _dbContext = dbContext;
        }

        public CardDetails GetDetails (Guid id) {
            var card = _dbContext
                .Tasks
                .Include (c => c.Column)
                .SingleOrDefault (x => x.Id == id);

            if (card == null)
                return new CardDetails ();

            // retrieve boards
            var board = _dbContext
                .Boards
                .Include (b => b.Columns)
                .SingleOrDefault (x => x.Id == card.Column.BoardId);

            // map board columns
            if (board != null) {
                var availableColumns = board
                    .Columns
                    .Select (x => new SelectListItem {
                        Text = x.Title,
                            Value = x.Id.ToString ()
                    });

                return new CardDetails {
                    Id = card.Id,
                        Contents = card.Title,
                        Notes = card.Description,
                        Columns = availableColumns.ToList (), // list available columns
                        Column = card.ColumnId // map current column
                };
            }
            return null;
        }

        public void Update (CardDetails cardDetails) {
            var card = _dbContext.Tasks.SingleOrDefault (x => x.Id == cardDetails.Id);
            if (card != null) {
                card.Title = cardDetails.Contents;
                card.Description = cardDetails.Notes;
                card.ColumnId = cardDetails.Column;
            }

            _dbContext.SaveChangesAsync ();
        }

        public void Delete (Guid id) {
            var card = _dbContext.Tasks.SingleOrDefault (x => x.Id == id);
            _dbContext.Remove (card ??
                throw new Exception ($"Could not remove {(Models.Agile.Task) null}"));

            _dbContext.SaveChanges ();
        }

    }
}