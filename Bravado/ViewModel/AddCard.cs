using System.ComponentModel.DataAnnotations;

namespace Bravado.ViewModel
{
    public class AddCard
    {
        public int Id { get; set; }

        [Required]
        public string Contents { get; set; }
    }
}

