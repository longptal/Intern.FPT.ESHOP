using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Entities;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.MAdmin.MCategory
{
    public interface ICategoryService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CategorySearchEntity CategorySearchEntity);
        List<CategoryEntity> Get(EmployeeEntity EmployeeEntity, CategorySearchEntity CategorySearchEntity);
        CategoryEntity Get(EmployeeEntity EmployeeEntity, Guid CategoryId);
        CategoryEntity Create(EmployeeEntity EmployeeEntity, CategoryEntity CategoryEntity);
        CategoryEntity Update(EmployeeEntity EmployeeEntity, Guid CategoryId, CategoryEntity CategoryEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CategoryId);
    }

    public class CategoryService : CommonService, ICategoryService
    {
        private ICategoryValidator CategoryValidator;
        public CategoryService(IUnitOfWork UnitOfWork, ICategoryValidator CategoryValidator) : base(UnitOfWork)
        {
            this.CategoryValidator = CategoryValidator;
        }
        public int Count(EmployeeEntity EmployeeEntity, CategorySearchEntity CategorySearchEntity)
        {
            return UnitOfWork.CategoryRepository.Count(CategorySearchEntity);
        }
        public List<CategoryEntity> Get(EmployeeEntity EmployeeEntity, CategorySearchEntity CategorySearchEntity)
        {
            List<Category> Categories = UnitOfWork.CategoryRepository.List(CategorySearchEntity);
            return Categories.ToList().Select(c => new CategoryEntity(c, c.Parent, c.CategoryNames)).ToList();
        }

        public CategoryEntity Get(EmployeeEntity EmployeeEntity, Guid CategoryId)
        {
            Category Category = UnitOfWork.CategoryRepository.Get(CategoryId);
            return new CategoryEntity(Category, Category.Parent, Category.CategoryNames);
        }
        public CategoryEntity Create(EmployeeEntity EmployeeEntity, CategoryEntity CategoryEntity)
        {
            if (CategoryEntity == null)
                throw new NotFoundException();
            if (!CategoryValidator.ValidateCreate(CategoryEntity))
                throw new BadRequestException(CategoryEntity);

            CategoryEntity.Id = Guid.NewGuid();
            Category Category = new Category(CategoryEntity);

            UnitOfWork.CategoryRepository.Add(Category);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Category.Id);
        }
        public CategoryEntity Update(EmployeeEntity EmployeeEntity, Guid CategoryId, CategoryEntity CategoryEntity)
        {
            if (CategoryEntity == null)
                throw new NotFoundException();
            CategoryEntity.Id = CategoryId;
            if (!CategoryValidator.ValidateUpdate(CategoryEntity))
                throw new BadRequestException(CategoryEntity);

            Category Category = new Category(CategoryEntity);
            UnitOfWork.CategoryRepository.Update(Category);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Category.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CategoryId)
        {
            CategoryEntity CategoryEntity = new CategoryEntity { Id = CategoryId };
            if (!CategoryValidator.ValidateDelete(CategoryEntity))
                throw new BadRequestException(CategoryEntity);
            UnitOfWork.CategoryRepository.Delete(CategoryId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
