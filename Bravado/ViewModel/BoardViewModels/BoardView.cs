using System;
using System.Collections.Generic;

using Bravado.Models.Agile;

namespace Bravado.ViewModel.BoardViewModels {
    public class BoardView {
        public Guid Id { get; set; }
        public readonly List<Column> Columns = new List<Column> ();

        public class Column {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public readonly List<Card> Cards = new List<Card> ();
        }

        public class Card {
            public Guid Id { get; set; }
            public string Content { get; set; }
        }
    }
}