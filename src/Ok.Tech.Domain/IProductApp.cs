using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ok.Tech.Domain.Entities;

namespace Ok.Tech.Domain.Apps

{
    public interface IProductApp
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task Create(Product product);
        void Update(Product product);
        void Delete(Guid id);

    }
}
