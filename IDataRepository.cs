using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_API.Repository
{
    internal interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        void Update(TEntity dbEntity);
        void Delete(int entity);
        IEnumerable<TEntity> GetAllFlights();

    }
}
