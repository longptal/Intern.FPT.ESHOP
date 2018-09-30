using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MLanguage
{
    public interface ILanguageService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, LanguageSearchEntity LanguageSearchEntity);
        List<LanguageEntity> Get(EmployeeEntity EmployeeEntity, LanguageSearchEntity LanguageSearchEntity);
        LanguageEntity Get(EmployeeEntity EmployeeEntity, Guid LanguageId);
        LanguageEntity Create(EmployeeEntity EmployeeEntity, LanguageEntity LanguageEntity);
        LanguageEntity Update(EmployeeEntity EmployeeEntity, Guid LanguageId, LanguageEntity LanguageEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid LanguageId);
    }
    public class LanguageService : CommonService, ILanguageService
    {
        public LanguageService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, LanguageSearchEntity LanguageSearchEntity)
        {
            return UnitOfWork.LanguageRepository.Count(LanguageSearchEntity);
        }
        public List<LanguageEntity> Get(EmployeeEntity EmployeeEntity, LanguageSearchEntity LanguageSearchEntity)
        {
            List<Language> Languages = UnitOfWork.LanguageRepository.List(LanguageSearchEntity);
            return Languages.ToList().Select(c => new LanguageEntity(c)).ToList();
        }

        public LanguageEntity Get(EmployeeEntity EmployeeEntity, Guid LanguageId)
        {
            Language Language = UnitOfWork.LanguageRepository.Get(LanguageId);
            return new LanguageEntity(Language);
        }
        public LanguageEntity Create(EmployeeEntity EmployeeEntity, LanguageEntity LanguageEntity)
        {
            if (LanguageEntity == null)
                throw new NotFoundException();
            Language Language = new Language(LanguageEntity);
            UnitOfWork.LanguageRepository.AddOrUpdate(Language);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Language.Id);
        }
        public LanguageEntity Update(EmployeeEntity EmployeeEntity, Guid LanguageId, LanguageEntity LanguageEntity)
        {
            LanguageEntity.Id = LanguageId;
            Language Language = new Language(LanguageEntity);
            UnitOfWork.LanguageRepository.AddOrUpdate(Language);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Language.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid LanguageId)
        {
            UnitOfWork.LanguageRepository.Delete(LanguageId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
