using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MCategory
{
    [Route("api/Categories")]
    public class CategoryController : CommonController
    {
        private ICategoryService CategoryService;
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        [Route("Count"), HttpGet]
        public long Count(CategorySearchEntity SearchCategoryEntity)
        {
            return CategoryService.Count(EmployeeEntity, SearchCategoryEntity);
        }

        [Route(""), HttpGet]
        public List<CategoryEntity> Get(CategorySearchEntity SearchCategoryEntity)
        {
            return CategoryService.Get(EmployeeEntity, SearchCategoryEntity);
        }
        [Route("{CategoryId}"), HttpGet]
        public CategoryEntity Get(Guid CategoryId)
        {
            return CategoryService.Get(EmployeeEntity, CategoryId);
        }
        [Route(""), HttpPost]
        public CategoryEntity Create([FromBody]CategoryEntity CategoryEntity)
        {
            return CategoryService.Create(EmployeeEntity, CategoryEntity);
        }
        [Route("{CategoryId}"), HttpPut]
        public CategoryEntity Update(Guid CategoryId, [FromBody]CategoryEntity CategoryEntity)
        {
            return CategoryService.Update(EmployeeEntity, CategoryId, CategoryEntity);
        }
        [Route("{CategoryId}"), HttpDelete]
        public bool Delete(Guid CategoryId)
        {
            return CategoryService.Delete(EmployeeEntity, CategoryId);
        }
    }
}