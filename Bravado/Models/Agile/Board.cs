using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Bravado.Models.Agile;


namespace Bravado.Models
{
    /// <summary>
    /// A board
    /// </summary>
    public class Board
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
    }
}
