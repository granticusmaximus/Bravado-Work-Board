using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bravado.ViewModel.AgileViewModels
{
    public class CardDetails
    {
        public int Id { get; set; }
        
        public string Contents { get; set; }

        public string Notes { get; set; }

        public DateTime DueDate { get; set; }

        public int Column { get; set; }
        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem>();
    }
}