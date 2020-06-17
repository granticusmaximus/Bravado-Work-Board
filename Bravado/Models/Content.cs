using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
