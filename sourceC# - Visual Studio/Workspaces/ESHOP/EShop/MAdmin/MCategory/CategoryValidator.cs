using EShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.MAdmin.MCategory
{
    public interface ICategoryValidator : IValidator<CategoryEntity>, ITransientService { }
    public class CategoryValidator : CommonValidator, ICategoryValidator
    {
        public CategoryValidator(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public bool ValidateCreate(CategoryEntity CategoryEntity)
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(CategoryEntity.Code))
                CategoryEntity.AddError(nameof(CategoryEntity.Code), "Must fill data.");
            if (CategoryEntity.Errors.Count > 0) IsValid = false;
            foreach (CategoryNameEntity CategoryNameEntity in CategoryEntity.CategoryNameEntities)
            {
                if (string.IsNullOrEmpty(CategoryNameEntity.Name))
                    CategoryNameEntity.AddError(nameof(CategoryNameEntity.Name), "Must fill data.");
                if (CategoryNameEntity.Errors.Count > 0) IsValid = false;
            }
            return IsValid;
        }

        public bool ValidateUpdate(CategoryEntity CategoryEntity)
        {
            bool IsValid = true;
            if (UnitOfWork.CategoryRepository.Get(CategoryEntity.Id) == null)
                CategoryEntity.AddError(nameof(CategoryEntity.Id), "Item doesn't existed.");
            if (string.IsNullOrEmpty(CategoryEntity.Code))
                CategoryEntity.AddError(nameof(CategoryEntity.Code), "Must fill data.");
            if (CategoryEntity.Errors.Count > 0) IsValid = false;
            foreach (CategoryNameEntity CategoryNameEntity in CategoryEntity.CategoryNameEntities)
            {
                if (string.IsNullOrEmpty(CategoryNameEntity.Name))
                    CategoryNameEntity.AddError(nameof(CategoryNameEntity.Name), "Must fill data.");
                if (CategoryNameEntity.Errors.Count > 0) IsValid = false;
            }
            return IsValid;
        }

        public bool ValidateDelete( CategoryEntity CategoryEntity)
        {
            bool IsValid = true;
            if (UnitOfWork.CategoryRepository.Get(CategoryEntity.Id) == null)
                CategoryEntity.AddError(nameof(CategoryEntity.Id), "Item doesn't existed.");
            if (CategoryEntity.Errors.Count > 0) IsValid = false;
            return IsValid;
        }

       
    }
}

