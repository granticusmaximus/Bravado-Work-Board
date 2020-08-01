using System.ComponentModel.DataAnnotations;

namespace Bravado.ViewModel.TaskViewModels
{
    public class AddCard
    {
        public int Id { get; set; }

        [Required]
        public string Contents { get; set; }
    }
}