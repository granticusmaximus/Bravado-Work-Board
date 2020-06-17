using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models
{
    public class Entry
    {
        [Key]
        public int ContentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        public ApplicationUser AppUser { get; set; }
    }
}
