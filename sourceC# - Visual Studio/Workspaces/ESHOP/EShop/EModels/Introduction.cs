using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Introduction : Base
    {
        public Introduction () : base(){}

        public Introduction (IntroductionEntity IntroductionEntity) : base(IntroductionEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Introduction Introduction)
            {
                return Id.Equals(Introduction.Id);
            }

            return false;
        }
    }
}
