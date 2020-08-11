using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models.Agile
{
    public class Column
    {
        [Key]
        public int ColumnID {get;set;}

        [Display(Name = "Column Name:")]
        public string ColumnName {get;set;}
        public Board BID {get;set;}
        public List<Card> Cards {get;set;}
    }
}