using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CarrierEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Note { get; set; }
        public Boolean IsActive { get; set; }

        public CarrierEntity():base() { }

        public CarrierEntity(Carrier Carrier, params object[] args) :base(Carrier)
        {
		    foreach(object arg in args)
			{
			}
        }
    }

    public class CarrierSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Note { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
