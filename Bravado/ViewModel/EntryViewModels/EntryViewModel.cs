using System.Collections.Generic;

using Bravado.Models.Wiki;

namespace Bravado.ViewModel.EntryViewModels
{
    public class EntryViewModel
    {
        public List<Entry> Entries {get;set;}
        public Entry Entry {get;set;}
        public string SearchString {get;set;}
    }
}