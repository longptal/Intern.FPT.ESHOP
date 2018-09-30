using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MReceiptNote
{
    [Route("api/ReceiptNotes")]
    public class ReceiptNoteController : CommonController
    {
        private IReceiptNoteService ReceiptNoteService;
        public ReceiptNoteController(IReceiptNoteService ReceiptNoteService)
        {
            this.ReceiptNoteService = ReceiptNoteService;
        }

        [Route("Count"), HttpGet]
        public long Count(ReceiptNoteSearchEntity SearchReceiptNoteEntity)
        {
            return ReceiptNoteService.Count(EmployeeEntity, SearchReceiptNoteEntity);
        }

        [Route(""), HttpGet]
        public List<ReceiptNoteEntity> Get(ReceiptNoteSearchEntity SearchReceiptNoteEntity)
        {
            return ReceiptNoteService.Get(EmployeeEntity, SearchReceiptNoteEntity);
        }
        [Route("{ReceiptNoteId}"), HttpGet]
        public ReceiptNoteEntity Get(Guid ReceiptNoteId)
        {
            return ReceiptNoteService.Get(EmployeeEntity, ReceiptNoteId);
        }
        [Route(""), HttpPost]
        public ReceiptNoteEntity Create([FromBody]ReceiptNoteEntity ReceiptNoteEntity)
        {
            return ReceiptNoteService.Create(EmployeeEntity, ReceiptNoteEntity);
        }
        [Route("{ReceiptNoteId}"), HttpPut]
        public ReceiptNoteEntity Update(Guid ReceiptNoteId, [FromBody]ReceiptNoteEntity ReceiptNoteEntity)
        {
            return ReceiptNoteService.Update(EmployeeEntity, ReceiptNoteId, ReceiptNoteEntity);
        }
        [Route("{ReceiptNoteId}"), HttpDelete]
        public bool Delete(Guid ReceiptNoteId)
        {
            return ReceiptNoteService.Delete(EmployeeEntity, ReceiptNoteId);
        }
    }
}