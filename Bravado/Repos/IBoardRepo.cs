using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public interface IBoardRepo
    {
        IEnumerable<Column> GetColumnList ();
        IEnumerable<Card> GetCardList ();
    }
}