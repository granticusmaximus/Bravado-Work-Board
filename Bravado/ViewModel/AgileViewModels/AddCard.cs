using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.ViewModel.AgileViewModels
{
    public class AddCard
    {
        public int Id { get; set; }

        [Required]
        public string Contents { get; set; }

        public string Notes {get;set;}
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
    }
}
