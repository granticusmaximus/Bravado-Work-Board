using System;
using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public interface IBoardRepo : IDisposable
    {
        IEnumerable<Column> GetColumnList ();
        IEnumerable<Card> GetCardList ();
    }
}