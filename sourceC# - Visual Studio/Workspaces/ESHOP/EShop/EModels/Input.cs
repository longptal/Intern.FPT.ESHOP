using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Input : Base
    {
        public Input () : base(){}

        public Input (InputEntity InputEntity) : base(InputEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Input Input)
            {
                return Id.Equals(Input.Id);
            }

            return false;
        }
    }
}
