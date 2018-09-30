using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MInvoice
{
    [Route("api/Invoices")]
    public class InvoiceController : CommonController
    {
        private IInvoiceService InvoiceService;
        public InvoiceController(IInvoiceService InvoiceService)
        {
            this.InvoiceService = InvoiceService;
        }

        [Route("Count"), HttpGet]
        public long Count(InvoiceSearchEntity SearchInvoiceEntity)
        {
            return InvoiceService.Count(EmployeeEntity, SearchInvoiceEntity);
        }

        [Route(""), HttpGet]
        public List<InvoiceEntity> Get(InvoiceSearchEntity SearchInvoiceEntity)
        {
            return InvoiceService.Get(EmployeeEntity, SearchInvoiceEntity);
        }
        [Route("{InvoiceId}"), HttpGet]
        public InvoiceEntity Get(Guid InvoiceId)
        {
            return InvoiceService.Get(EmployeeEntity,  InvoiceId);
        }
        [Route(""), HttpPost]
        public InvoiceEntity Create([FromBody]InvoiceEntity InvoiceEntity)
        {
            return InvoiceService.Create(EmployeeEntity, InvoiceEntity);
        }
        [Route("{InvoiceId}"), HttpPut]
        public InvoiceEntity Update(Guid InvoiceId, [FromBody]InvoiceEntity InvoiceEntity)
        {
            return InvoiceService.Update(EmployeeEntity, InvoiceId, InvoiceEntity);
        }
        [Route("{InvoiceId}"), HttpDelete]
        public bool Delete(Guid InvoiceId)
        {
            return InvoiceService.Delete(EmployeeEntity, InvoiceId);
        }
    }
}