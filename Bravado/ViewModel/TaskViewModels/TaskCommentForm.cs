using Bravado.Models.Agile;
using System.Collections.Generic;

namespace Bravado.ViewModel.TaskViewModels
{
    public class TaskCommentForm
    {
        public Task Task { get; set; }
        public TaskComment TaskComment { get; set; }
        public IEnumerable<TaskComment> TaskComments { get; set; }
    }
}