using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class CategoryName : Base
    {
        public CategoryName () : base(){}

        public CategoryName (CategoryNameEntity CategoryNameEntity) : base(CategoryNameEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is CategoryName CategoryName)
            {
                return Id.Equals(CategoryName.Id);
            }

            return false;
        }
    }
}
