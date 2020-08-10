using System;

namespace Bravado.ViewModel.TaskViewModels {
    public class MoveCardCommand {
        public Guid CardId { get; set; }
        public int ColumnId { get; set; }
    }
}