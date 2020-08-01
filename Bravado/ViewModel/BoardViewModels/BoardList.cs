using System.Collections.Generic;

namespace Bravado.ViewModel.BoardViewModels
{
    public class BoardList
    {
        public List<Board> Boards = new List<Board>();

        public class Board
        {
            public int Id { get; set; }
            public string Title { get; set; }
        }
    }
}