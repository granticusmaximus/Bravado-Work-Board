using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bravado.Models.Agile;

namespace Bravado.Repos
{
    public interface IGenericRepository
    {
         void Add<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;

         Task<bool> SaveAllChangesAsync();
    }
}