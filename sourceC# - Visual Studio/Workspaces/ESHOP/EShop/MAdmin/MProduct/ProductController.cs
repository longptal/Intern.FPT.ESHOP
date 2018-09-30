using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MProduct
{
    [Route("api/Products")]
    public class ProductController : CommonController
    {
        private IProductService ProductService;
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        [Route("Count"), HttpGet]
        public long Count(ProductSearchEntity SearchProductEntity)
        {
            return ProductService.Count(EmployeeEntity, SearchProductEntity);
        }

        [Route(""), HttpGet]
        public List<ProductEntity> Get(ProductSearchEntity SearchProductEntity)
        {
            return ProductService.Get(EmployeeEntity, SearchProductEntity);
        }
        [Route("{ProductId}"), HttpGet]
        public ProductEntity Get(Guid ProductId)
        {
            return ProductService.Get(EmployeeEntity, ProductId);
        }
        [Route(""), HttpPost]
        public ProductEntity Create([FromBody]ProductEntity ProductEntity)
        {
            return ProductService.Create(EmployeeEntity, ProductEntity);
        }
        [Route("{ProductId}"), HttpPut]
        public ProductEntity Update(Guid ProductId, [FromBody]ProductEntity ProductEntity)
        {
            return ProductService.Update(EmployeeEntity, ProductId, ProductEntity);
        }
        [Route("{ProductId}"), HttpDelete]
        public bool Delete(Guid ProductId)
        {
            return ProductService.Delete(EmployeeEntity, ProductId);
        }
    }
}