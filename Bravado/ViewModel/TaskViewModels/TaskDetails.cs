using Bravado.Models.Agile;

namespace Bravado.ViewModel.TaskViewModels
{
    public class TaskDetails
    {
        public Board Board { get; set; }
        public Task Task { get; set; }
        public Task Description { get; set; }
    }
}
