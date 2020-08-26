using System;
using System.Linq;
using Bravado.Data;
using Bravado.ViewModel.AgileViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bravado.Services
{
    public class CardService
    {
        private readonly AppDbContext _dbContext;

        public CardService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public CardDetails GetDetails(int id)
        {
            var card = _dbContext
                .Cards
                .Include(c => c.Column)
                .SingleOrDefault(x => x.CardID == id);

            if (card == null) 
                return new CardDetails();
           
            // retrieve boards
            var board = _dbContext
                .Boards
                .Include(b => b.Columns)
                .SingleOrDefault(x => x.BoardID == card.Column.BoardID);

            // map board columns
            if (board != null) 
            {
                var availableColumns = board
                    .Columns
                    .Select(x => new SelectListItem
                    {
                        Text = x.ColumnName,
                        Value = x.ColumnID.ToString()
                    });


                return new CardDetails
                {
                    Id = card.CardID,
                    Contents = card.CardName,
                    Notes = card.CardNotes,
                    Columns = availableColumns.ToList(), // list available columns
                    Column = card.ColumnID // map current column
                };
            }
            return null;
        }

        public void Update(CardDetails cardDetails)
        {
            var card = _dbContext.Cards.SingleOrDefault(x => x.CardID == cardDetails.Id);
            if (card != null)
            {
                card.CardName = cardDetails.Contents;
                card.CardNotes = cardDetails.Notes;
                card.ColumnID = cardDetails.Column;
            }

            _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var card = _dbContext.Cards.SingleOrDefault(x => x.CardID == id);
            _dbContext.Remove(card);
            
            _dbContext.SaveChanges();
        }
        
    }
}