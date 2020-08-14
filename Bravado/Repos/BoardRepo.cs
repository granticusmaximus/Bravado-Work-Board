using System;
using System.Collections.Generic;
using System.Linq;
using Bravado.Data;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public class BoardRepo : IBoardRepo, IDisposable
    {
        
        public BoardRepo(AppDbContext context)
        {
            this.context = context;
        }
        private AppDbContext context;

        public IEnumerable<Card> GetCardList()
        {
            return context.Cards.ToList();
        }

        public IEnumerable<Column> GetColumnList()
        {
            return context.Columns.ToList();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}