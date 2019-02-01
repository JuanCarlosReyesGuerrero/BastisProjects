using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bastis.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(long Id);
        void Delete(TEntity entity);
        TEntity GetByID(long? id);
        IEnumerable<TEntity> GetAll();
    }
}
