using Bravado.Models.Agile;
using System.Collections.Generic;

namespace Bravado.ViewModel.TaskViewModels
{
    public class TaskCommentForm
    {
        public Board Board { get; set; }
        public Task Task { get; set; }
        public TaskComment TaskComment { get; set; }
        public IEnumerable<TaskComment> TaskComments { get; set; }
    }
}