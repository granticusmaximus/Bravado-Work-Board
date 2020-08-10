using System;
using System.Collections.Generic;

namespace Bravado.Models.Agile {
    public class Column : BaseEntity {
        public string Title { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task> ();
        public Guid BoardId { get; set; }
    }
}