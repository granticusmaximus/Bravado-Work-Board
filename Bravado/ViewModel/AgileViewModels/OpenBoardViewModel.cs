using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.ViewModel.AgileViewModels
{
    public class OpenBoardViewModel
    {
        public Board Board { get; set; }
        public List<Column> Columns {get;set;}
        public List<Card> Cards {get;set;}
    }
}