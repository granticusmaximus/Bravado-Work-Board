using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models.Agile
{
    public class Board
    {
        [Key]
        public int BoardID {get;set;}
        public string BoardTitle {get;set;}
        public string UserId { get; set; }
        public List<Column> Columns {get;set;}
    
    }

    public class Column
    {
        [Key]
        public int ColumnID {get;set;}
        public string ColumnName {get;set;}
        public Board BID {get;set;}
        public List<Card> Cards {get;set;}
    }

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