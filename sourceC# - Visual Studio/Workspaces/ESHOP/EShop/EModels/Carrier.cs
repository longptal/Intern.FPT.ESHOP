using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Carrier : Base
    {
        public Carrier () : base(){}

        public Carrier (CarrierEntity CarrierEntity) : base(CarrierEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Carrier Carrier)
            {
                return Id.Equals(Carrier.Id);
            }

            return false;
        }
    }
}
