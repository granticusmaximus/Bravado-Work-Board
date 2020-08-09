using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.ViewModel.BoardViewModels {
    public class AddCard {
        public Guid Id { get; set; }

        [Required]
        public string Contents { get; set; }
    }
}
