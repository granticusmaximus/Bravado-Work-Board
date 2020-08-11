using System.Collections.Generic;
using Bravado.Data;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public class BoardRepo : IBoardRepo
    {
        private AppDbContext _context = new AppDbContext();

        public IEnumerable<Card> GetCardList()
        {
            return _context.Cards.ToList();
        }

        public IEnumerable<Column> GetColumnList()
        {
            return _context.Columns.ToList();
        }
    }
}