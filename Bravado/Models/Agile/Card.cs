using System;
using System.ComponentModel.DataAnnotations;

namespace Bravado.Models.Agile
{
    public class Card : BaseEntity
    {
        [Required]
        public string Contents { get; set; }
        public string Notes { get; set; }
        public int ColumnId { get; set; }
        public Column Column { get; set; }
        public DateTime DueDate { get; set; }
        public double DaysOverDue => DateTime.Now.Subtract(DueDate).TotalDays;
    }
}