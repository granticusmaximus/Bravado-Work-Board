using System.Collections.Generic;

using Bravado.Models;

namespace Bravado.ViewModel.EntryViewModels
{
    public class EntryViewModel
    {
        public List<Entry> Entries {get;set;}
        public string SearchString {get;set;}
    }
}