﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ok.Tech.Domain.Apps;
using Ok.Tech.Domain.Entities;
using Ok.Tech.Domain.Repositories;

namespace Ok.Tech.App
{
    public class ProductApp : AppBase, IProductApp
    {
        private readonly IProductRepository _productRepository;

        public ProductApp(IProductRepository productRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task Create(Product product)
        {
            _productRepository.Create(product);
            await UnitOfWork.Save();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }

        public void Delete(Guid id)
        {
            _productRepository.Delete(id);
        }


    }
}
