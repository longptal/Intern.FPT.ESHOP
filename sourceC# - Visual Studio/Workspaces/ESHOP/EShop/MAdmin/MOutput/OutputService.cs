using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MOutput
{
    public interface IOutputService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, OutputSearchEntity OutputSearchEntity);
        List<OutputEntity> Get(EmployeeEntity EmployeeEntity, OutputSearchEntity OutputSearchEntity);
        OutputEntity Get(EmployeeEntity EmployeeEntity, Guid OutputId);
        OutputEntity Create(EmployeeEntity EmployeeEntity, OutputEntity OutputEntity);
        OutputEntity Update(EmployeeEntity EmployeeEntity, Guid OutputId, OutputEntity OutputEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid OutputId);
    }
    public class OutputService : CommonService, IOutputService
    {
        public OutputService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, OutputSearchEntity OutputSearchEntity)
        {
            return UnitOfWork.OutputRepository.Count(OutputSearchEntity);
        }
        public List<OutputEntity> Get(EmployeeEntity EmployeeEntity, OutputSearchEntity OutputSearchEntity)
        {
            List<Output> Outputs = UnitOfWork.OutputRepository.List(OutputSearchEntity);
            return Outputs.ToList().Select(c => new OutputEntity(c)).ToList();
        }

        public OutputEntity Get(EmployeeEntity EmployeeEntity, Guid OutputId)
        {
            Output Output = UnitOfWork.OutputRepository.Get(OutputId);
            return new OutputEntity(Output);
        }
        public OutputEntity Create(EmployeeEntity EmployeeEntity, OutputEntity OutputEntity)
        {
            if (OutputEntity == null)
                throw new NotFoundException();
            Output Output = new Output(OutputEntity);
            UnitOfWork.OutputRepository.AddOrUpdate(Output);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Output.Id);
        }
        public OutputEntity Update(EmployeeEntity EmployeeEntity, Guid OutputId, OutputEntity OutputEntity)
        {
            OutputEntity.Id = OutputId;
            Output Output = new Output(OutputEntity);
            UnitOfWork.OutputRepository.AddOrUpdate(Output);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Output.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid OutputId)
        {
            UnitOfWork.OutputRepository.Delete(OutputId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
