﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bravado.Models.Agile {
    public class Board {
        [Key, DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public List<Column> Columns { get; set; } = new List<Column> ();
    }
}