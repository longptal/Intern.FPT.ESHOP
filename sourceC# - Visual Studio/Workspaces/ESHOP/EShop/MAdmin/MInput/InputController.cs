using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MInput
{
    [Route("api/Inputs")]
    public class InputController : CommonController
    {
        private IInputService InputService;
        public InputController(IInputService InputService)
        {
            this.InputService = InputService;
        }

        [Route("Count"), HttpGet]
        public long Count(InputSearchEntity SearchInputEntity)
        {
            return InputService.Count(EmployeeEntity, SearchInputEntity);
        }

        [Route(""), HttpGet]
        public List<InputEntity> Get(InputSearchEntity SearchInputEntity)
        {
            return InputService.Get(EmployeeEntity, SearchInputEntity);
        }
        [Route("{InputId}"), HttpGet]
        public InputEntity Get(Guid InputId)
        {
            return InputService.Get(EmployeeEntity, InputId);
        }
        [Route(""), HttpPost]
        public InputEntity Create([FromBody]InputEntity InputEntity)
        {
            return InputService.Create(EmployeeEntity, InputEntity);
        }
        [Route("{InputId}"), HttpPut]
        public InputEntity Update(Guid InputId, [FromBody]InputEntity InputEntity)
        {
            return InputService.Update(EmployeeEntity, InputId, InputEntity);
        }
        [Route("{InputId}"), HttpDelete]
        public bool Delete(Guid InputId)
        {
            return InputService.Delete(EmployeeEntity, InputId);
        }
    }
}