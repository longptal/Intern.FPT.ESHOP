using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MOperation
{
    public interface IOperationService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, OperationSearchEntity OperationSearchEntity);
        List<OperationEntity> Get(EmployeeEntity EmployeeEntity, OperationSearchEntity OperationSearchEntity);
        OperationEntity Get(EmployeeEntity EmployeeEntity, Guid OperationId);
        OperationEntity Create(EmployeeEntity EmployeeEntity, OperationEntity OperationEntity);
        OperationEntity Update(EmployeeEntity EmployeeEntity, Guid OperationId, OperationEntity OperationEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid OperationId);
    }
    public class OperationService : CommonService, IOperationService
    {
        public OperationService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, OperationSearchEntity OperationSearchEntity)
        {
            return UnitOfWork.OperationRepository.Count(OperationSearchEntity);
        }
        public List<OperationEntity> Get(EmployeeEntity EmployeeEntity, OperationSearchEntity OperationSearchEntity)
        {
            List<Operation> Operations = UnitOfWork.OperationRepository.List(OperationSearchEntity);
            return Operations.ToList().Select(c => new OperationEntity(c)).ToList();
        }

        public OperationEntity Get(EmployeeEntity EmployeeEntity, Guid OperationId)
        {
            Operation Operation = UnitOfWork.OperationRepository.Get(OperationId);
            return new OperationEntity(Operation);
        }
        public OperationEntity Create(EmployeeEntity EmployeeEntity, OperationEntity OperationEntity)
        {
            if (OperationEntity == null)
                throw new NotFoundException();
            Operation Operation = new Operation(OperationEntity);
            UnitOfWork.OperationRepository.AddOrUpdate(Operation);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Operation.Id);
        }
        public OperationEntity Update(EmployeeEntity EmployeeEntity, Guid OperationId, OperationEntity OperationEntity)
        {
            OperationEntity.Id = OperationId;
            Operation Operation = new Operation(OperationEntity);
            UnitOfWork.OperationRepository.AddOrUpdate(Operation);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Operation.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid OperationId)
        {
            UnitOfWork.OperationRepository.Delete(OperationId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
