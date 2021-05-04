using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ok.Tech.Domain.Entities;

namespace Ok.Tech.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {

        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> GetById(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid id);



    }
}
