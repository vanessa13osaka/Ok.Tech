using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ok.Tech.Api.Models;
using Ok.Tech.Domain.Apps;
using Ok.Tech.Domain.Entities;

namespace Ok.Tech.Api.Controllers
{
    [Route("products")]
    public class ProductsController : MainController
    {
        private readonly IProductApp _productApp;
        private readonly IMapper _mapper;

        public ProductsController(IProductApp productApp, IMapper mapper)
        {
            _productApp = productApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetProducts ()
        {
            var products = await _productApp.GetAll();

            var productViewModels= _mapper.Map<IEnumerable<ProductViewModel>>(products);
            //criação do produto.
            return CustomResponse (products);
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<ProductViewModel> GetProductById(Guid Id)
        {
            var product = _mapper.Map<ProductViewModel>(_productApp.GetById(Id));

            return CustomResponse(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> CreateProduct(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                CustomResponse(ModelState, productViewModel);
            }

           await _productApp.Create(_mapper.Map<Product>(productViewModel));

            //criacao do produto
            return CustomResponse(productViewModel);
        }

        //[HttpPost("{id:Guid}")]
        //public ActionResult<ProductViewModel> CreateProduct(Guid id, ProductViewModel productViewModel)
        //{
        //    return CustomResponse(ModelState, productViewModel);
        //}

        [HttpPut("{id:Guid}")]
        public ActionResult<ProductViewModel> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            return productViewModel;
        }

        [HttpDelete("{id:Guid}")]
        public ActionResult<ProductViewModel> DeleteProduct(Guid id)
        {
            
            _productApp.Delete(id);
            return CustomResponse();
        }
    }
}
