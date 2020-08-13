using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.Services
{
    public interface IBoardService
    {
        IEnumerable<Column> GetColumnList ();
        IEnumerable<Card> GetCardList ();
    }
}