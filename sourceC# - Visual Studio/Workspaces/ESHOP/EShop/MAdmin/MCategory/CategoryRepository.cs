using EShop.Entities;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using EShop.Entities;

namespace EShop.MAdmin.MCategory
{
    public interface ICategoryRepository
    {
        int Count(CategorySearchEntity CategorySearchEntity);
        List<Category> List(CategorySearchEntity CategorySearchEntity);
        Category Get(Guid Id);
        bool Add(Category Category);
        bool Update(Category Category);
        bool Delete(Guid Id);
    }

    public class CategoryRepository : CommonRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EShopContext EShopContext) : base(EShopContext)
        {

        }
        public int Count(CategorySearchEntity CategorySearchEntity)
        {
            if (CategorySearchEntity == null) CategorySearchEntity = new CategorySearchEntity();
            IQueryable<Category> Categories = context.Categories;
            Apply(Categories, CategorySearchEntity);
            return Categories.Count();
        }

        public List<Category> List(CategorySearchEntity CategorySearchEntity)
        {
            if (CategorySearchEntity == null) CategorySearchEntity = new CategorySearchEntity();
            IQueryable<Category> Categories = context.Categories
                .Include(c => c.Parent)
                .Include(c => c.CategoryNames)
                .ThenInclude(cn => cn.Language);
            Apply(Categories, CategorySearchEntity);
            SkipAndTake(Categories, CategorySearchEntity);
            return Categories.ToList();
        }
        public Category Get(Guid Id)
        {
            Category Category = context.Categories.Where(c => c.Id == Id)
                .Include(c => c.Parent)
                .Include(c => c.CategoryNames)
                .ThenInclude(cn => cn.Language)
                .FirstOrDefault();
            return Category;
        }

        public bool Add(Category Category)
        {
            if (Category.Id == Guid.Empty) Category.Id = Guid.NewGuid();
            context.Categories.Add(Category);
            foreach (CategoryName CategoryName in Category.CategoryNames)
            {
                CategoryName.Id = Guid.NewGuid();
                context.CategoryNames.Add(CategoryName);
            }
            return true;
        }

        public bool Update(Category Category)
        {
            Category Current = context.Categories.Where(c => c.Id == Category.Id)
                   .FirstOrDefault();
            if (Current == null) return false;
            Common<Category>.Copy(Category, Current);
            context.SaveChanges();
            List<CategoryName> CategoryNames = context.CategoryNames.Where(cn => cn.CategoryId == Category.Id).ToList();
            List<CategoryName> Insert, Update, Delete;
            Common<CategoryName>.Split(Category.CategoryNames, CategoryNames, out Insert, out Update, out Delete);
            foreach (CategoryName CategoryName in Insert)
            {
                CategoryName.Id = Guid.NewGuid();
                CategoryName.CategoryId = Category.Id;
                context.CategoryNames.Add(CategoryName);
            }
            foreach (CategoryName CategoryName in Update)
            {
                CategoryName CN = CategoryNames.Where(cn => cn.Id == CategoryName.Id).FirstOrDefault();
                Common<CategoryName>.Copy(CategoryName, CN);
            }
            foreach (CategoryName CategoryName in Delete)
                context.CategoryNames.Remove(CategoryName);
            context.SaveChanges();
            return true;
        }

        public bool Delete(Guid Id)
        {
            Category Category = Get(Id);
            if (Category == null) return false;
            context.Categories.Remove(Category);
            context.CategoryNames.RemoveRange(Category.CategoryNames);
            return true;
        }


        private IQueryable<Category> Apply(IQueryable<Category> Categories, CategorySearchEntity CategorySearchEntity)
        {
            if (CategorySearchEntity.Id.HasValue)
                Categories = Categories.Where(wh => wh.Id == CategorySearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(CategorySearchEntity.Code))
                Categories = Categories.Where(T => T.Code.ToLower().Contains(CategorySearchEntity.Code.ToLower()));
            if (CategorySearchEntity.ParentId.HasValue)
                Categories = Categories.Where(T => T.ParentId.HasValue && T.ParentId.Value == CategorySearchEntity.ParentId.Value);
            return Categories;
        }
    }
}
