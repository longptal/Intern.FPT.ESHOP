using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Output : Base
    {
        public Output () : base(){}

        public Output (OutputEntity OutputEntity) : base(OutputEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Output Output)
            {
                return Id.Equals(Output.Id);
            }

            return false;
        }
    }
}
