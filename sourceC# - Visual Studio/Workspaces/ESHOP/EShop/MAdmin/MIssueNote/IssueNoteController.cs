using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MIssueNote
{
    [Route("api/IssueNotes")]
    public class IssueNoteController : CommonController
    {
        private IIssueNoteService IssueNoteService;
        public IssueNoteController(IIssueNoteService IssueNoteService)
        {
            this.IssueNoteService = IssueNoteService;
        }

        [Route("Count"), HttpGet]
        public long Count(IssueNoteSearchEntity SearchIssueNoteEntity)
        {
            return IssueNoteService.Count(EmployeeEntity, SearchIssueNoteEntity);
        }

        [Route(""), HttpGet]
        public List<IssueNoteEntity> Get(IssueNoteSearchEntity SearchIssueNoteEntity)
        {
            return IssueNoteService.Get(EmployeeEntity, SearchIssueNoteEntity);
        }
        [Route("{IssueNoteId}"), HttpGet]
        public IssueNoteEntity Get(Guid IssueNoteId)
        {
            return IssueNoteService.Get(EmployeeEntity, IssueNoteId);
        }
        [Route(""), HttpPost]
        public IssueNoteEntity Create([FromBody]IssueNoteEntity IssueNoteEntity)
        {
            return IssueNoteService.Create(EmployeeEntity, IssueNoteEntity);
        }
        [Route("{IssueNoteId}"), HttpPut]
        public IssueNoteEntity Update(Guid IssueNoteId, [FromBody]IssueNoteEntity IssueNoteEntity)
        {
            return IssueNoteService.Update(EmployeeEntity, IssueNoteId, IssueNoteEntity);
        }
        [Route("{IssueNoteId}"), HttpDelete]
        public bool Delete(Guid IssueNoteId)
        {
            return IssueNoteService.Delete(EmployeeEntity, IssueNoteId);
        }
    }
}