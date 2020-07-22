using System.ComponentModel.DataAnnotations;

namespace Bravado.ViewModel.AccountViewModels
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}