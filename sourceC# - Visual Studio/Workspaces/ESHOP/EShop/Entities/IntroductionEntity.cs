using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class IntroductionEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Content { get; set; }
        public String Route { get; set; }

        public IntroductionEntity():base() { }

        public IntroductionEntity(Introduction Introduction, params object[] args) :base(Introduction)
        {
		    foreach(object arg in args)
			{
			}
        }
    }

    public class IntroductionSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Content { get; set; }
        public String Route { get; set; }
    }
}
