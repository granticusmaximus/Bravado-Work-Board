using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models.Agile
{
    public class Card
    {
        [Key]
        public int CardID {get;set;}
        public Column CID {get;set;}

        [Display(Name = "Task Name:")]
        public string CardName {get;set;}

        [Display(Name = "Requirements")]
        public string CardNotes {get;set;}

        [Display(Name = "Comments")]
        public string CardComments {get;set;}

        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
    }
}