using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.ViewModel.AgileViewModels
{
    public class OpenBoardViewModel
    {
        public Board Board { get; set; }
        public Column Column { get; set; }
        public Card Card { get; set; }
<<<<<<< HEAD
        
       
=======
        public List<Column> Columns {get;set;}
        public List<Card> Cards {get;set;}
>>>>>>> 447e26dd8fed9bd83fe382c76d18677186f75764
    }
}