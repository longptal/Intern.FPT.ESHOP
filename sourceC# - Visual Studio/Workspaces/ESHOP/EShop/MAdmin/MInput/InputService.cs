using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MInput
{
    public interface IInputService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, InputSearchEntity InputSearchEntity);
        List<InputEntity> Get(EmployeeEntity EmployeeEntity, InputSearchEntity InputSearchEntity);
        InputEntity Get(EmployeeEntity EmployeeEntity, Guid InputId);
        InputEntity Create(EmployeeEntity EmployeeEntity, InputEntity InputEntity);
        InputEntity Update(EmployeeEntity EmployeeEntity, Guid InputId, InputEntity InputEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid InputId);
    }
    public class InputService : CommonService, IInputService
    {
        public InputService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, InputSearchEntity InputSearchEntity)
        {
            return UnitOfWork.InputRepository.Count(InputSearchEntity);
        }
        public List<InputEntity> Get(EmployeeEntity EmployeeEntity, InputSearchEntity InputSearchEntity)
        {
            List<Input> Inputs = UnitOfWork.InputRepository.List(InputSearchEntity);
            return Inputs.ToList().Select(c => new InputEntity(c)).ToList();
        }

        public InputEntity Get(EmployeeEntity EmployeeEntity, Guid InputId)
        {
            Input Input = UnitOfWork.InputRepository.Get(InputId);
            return new InputEntity(Input);
        }
        public InputEntity Create(EmployeeEntity EmployeeEntity, InputEntity InputEntity)
        {
            if (InputEntity == null)
                throw new NotFoundException();
            Input Input = new Input(InputEntity);
            UnitOfWork.InputRepository.AddOrUpdate(Input);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Input.Id);
        }
        public InputEntity Update(EmployeeEntity EmployeeEntity, Guid InputId, InputEntity InputEntity)
        {
            InputEntity.Id = InputId;
            Input Input = new Input(InputEntity);
            UnitOfWork.InputRepository.AddOrUpdate(Input);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Input.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid InputId)
        {
            UnitOfWork.InputRepository.Delete(InputId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
