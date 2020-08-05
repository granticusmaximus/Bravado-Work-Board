using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bravado.ViewModel.TaskViewModels {
    public class CardDetails {
        public Guid Id { get; set; }
        public string Contents { get; set; }
        public string Notes { get; set; }

        public int Column { get; set; }
        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem> ();
    }
}