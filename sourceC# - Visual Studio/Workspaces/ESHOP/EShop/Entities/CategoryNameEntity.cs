using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CategoryNameEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid LanguageId { get; set; }
        public String Name { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public LanguageEntity LanguageEntity { get; set; }

        public CategoryNameEntity():base() { }

        public CategoryNameEntity(CategoryName CategoryName, params object[] args) :base(CategoryName)
        {
		    foreach(object arg in args)
			{
                if (arg is Category Category)
                    CategoryEntity = new CategoryEntity(Category);				
                if (arg is Language Language)
                    LanguageEntity = new LanguageEntity(Language);				
			}
        }
    }

    public class CategoryNameSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? LanguageId { get; set; }
        public String Name { get; set; }
    }
}
