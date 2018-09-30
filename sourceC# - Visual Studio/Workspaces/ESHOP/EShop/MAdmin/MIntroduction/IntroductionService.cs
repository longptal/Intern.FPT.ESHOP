using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MIntroduction
{
    public interface IIntroductionService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, IntroductionSearchEntity IntroductionSearchEntity);
        List<IntroductionEntity> Get(EmployeeEntity EmployeeEntity, IntroductionSearchEntity IntroductionSearchEntity);
        IntroductionEntity Get(EmployeeEntity EmployeeEntity, Guid IntroductionId);
        IntroductionEntity Create(EmployeeEntity EmployeeEntity, IntroductionEntity IntroductionEntity);
        IntroductionEntity Update(EmployeeEntity EmployeeEntity, Guid IntroductionId, IntroductionEntity IntroductionEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid IntroductionId);
    }
    public class IntroductionService : CommonService, IIntroductionService
    {
        public IntroductionService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, IntroductionSearchEntity IntroductionSearchEntity)
        {
            return UnitOfWork.IntroductionRepository.Count(IntroductionSearchEntity);
        }
        public List<IntroductionEntity> Get(EmployeeEntity EmployeeEntity, IntroductionSearchEntity IntroductionSearchEntity)
        {
            List<Introduction> Introductions = UnitOfWork.IntroductionRepository.List(IntroductionSearchEntity);
            return Introductions.ToList().Select(c => new IntroductionEntity(c)).ToList();
        }

        public IntroductionEntity Get(EmployeeEntity EmployeeEntity, Guid IntroductionId)
        {
            Introduction Introduction = UnitOfWork.IntroductionRepository.Get(IntroductionId);
            return new IntroductionEntity(Introduction);
        }
        public IntroductionEntity Create(EmployeeEntity EmployeeEntity, IntroductionEntity IntroductionEntity)
        {
            if (IntroductionEntity == null)
                throw new NotFoundException();
            Introduction Introduction = new Introduction(IntroductionEntity);
            UnitOfWork.IntroductionRepository.AddOrUpdate(Introduction);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Introduction.Id);
        }
        public IntroductionEntity Update(EmployeeEntity EmployeeEntity, Guid IntroductionId, IntroductionEntity IntroductionEntity)
        {
            IntroductionEntity.Id = IntroductionId;
            Introduction Introduction = new Introduction(IntroductionEntity);
            UnitOfWork.IntroductionRepository.AddOrUpdate(Introduction);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Introduction.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid IntroductionId)
        {
            UnitOfWork.IntroductionRepository.Delete(IntroductionId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
