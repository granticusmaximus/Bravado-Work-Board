using System;
using System.Collections.Generic;
using System.Linq;
using Bravado.Data;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public class BoardRepo : IBoardRepo, IDisposable
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public BoardRepo(AppDbContext context)
        {
            this.context = context;
        }
        private AppDbContext context;

        public IEnumerable<Card> GetCardList()
        {
            return context.Cards.ToList();
        }

        public IEnumerable<Column> GetColumnList(int ID)
        {
            return context.Columns.ToList().Where(x => x.BID.BoardID == ID);
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

        public Board GetBoardByID(int boardID)
        {
            try
            {
                return context.Boards.Single(x => x.BoardID == boardID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: " + ex.Message);
                throw;
            }
        }

        public Card GetCardByID(int cardID)
        {
            try
            {
                return context.Cards.Single(x => x.CardID == cardID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: " + ex.Message);
                throw;
            }
        }

        public Column GetColumnByID(int columnID)
        {
            try
            {
                return context.Columns.Single(x => x.ColumnID == columnID);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Repository Error: " + ex.Message);
                throw;
            }
        }
    }
}