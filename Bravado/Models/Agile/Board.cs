using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models.Agile
{
    public class Board
    {
        [Key]
        public int BoardID {get;set;}

        [Display(Name = "Board Name:")]
        public string BoardTitle {get;set;}
        public string UserId { get; set; }
        public List<Column> Columns {get;set;}
    
    }

}