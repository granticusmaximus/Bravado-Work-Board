using System.Collections.Generic;
using Bravado.Models.Agile;

namespace Bravado.ViewModel.BoardViewModels
{
    public class BoardView
    {
        public Board Board { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
        public IEnumerable<Task> TaskL1 { get; set; }
        public IEnumerable<Task> TaskL2 { get; set; }
        public IEnumerable<Task> TaskL3 { get; set; }
    }
}
