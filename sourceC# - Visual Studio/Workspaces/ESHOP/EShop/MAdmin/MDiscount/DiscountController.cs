using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MDiscount
{
    [Route("api/Discounts")]
    public class DiscountController : CommonController
    {
        private IDiscountService DiscountService;
        public DiscountController(IDiscountService DiscountService)
        {
            this.DiscountService = DiscountService;
        }

        [Route("Count"), HttpGet]
        public long Count(DiscountSearchEntity SearchDiscountEntity)
        {
            return DiscountService.Count(EmployeeEntity, SearchDiscountEntity);
        }

        [Route(""), HttpGet]
        public List<DiscountEntity> Get(DiscountSearchEntity SearchDiscountEntity)
        {
            return DiscountService.Get(EmployeeEntity, SearchDiscountEntity);
        }
        [Route("{DiscountId}"), HttpGet]
        public DiscountEntity Get(Guid DiscountId)
        {
            return DiscountService.Get(EmployeeEntity, DiscountId);
        }
        [Route(""), HttpPost]
        public DiscountEntity Create([FromBody]DiscountEntity DiscountEntity)
        {
            return DiscountService.Create(EmployeeEntity, DiscountEntity);
        }
        [Route("{DiscountId}"), HttpPut]
        public DiscountEntity Update(Guid DiscountId, [FromBody]DiscountEntity DiscountEntity)
        {
            return DiscountService.Update(EmployeeEntity, DiscountId, DiscountEntity);
        }
        [Route("{DiscountId}"), HttpDelete]
        public bool Delete(Guid DiscountId)
        {
            return DiscountService.Delete(EmployeeEntity, DiscountId);
        }
    }
}