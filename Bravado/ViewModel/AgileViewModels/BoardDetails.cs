using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.ViewModel.AgileViewModels
{
    public class BoardDetails
    {
        public Board Board { get; set; }
        public Column Column { get; set; }
        public Card Card { get; set; }
        public List<Board> Boards {get;set;}
        public IEnumerable<Column> Columns {get;set;}
        public IEnumerable<Card> Cards {get;set;}
    }
}