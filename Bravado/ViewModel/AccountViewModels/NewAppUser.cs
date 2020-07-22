using System;
using Bravado.Models;

namespace Bravado.ViewModel.AccountViewModels
{
    public class NewAppUser : ApplicationUser
    {
        public string Password { get; set; }
    }
}
