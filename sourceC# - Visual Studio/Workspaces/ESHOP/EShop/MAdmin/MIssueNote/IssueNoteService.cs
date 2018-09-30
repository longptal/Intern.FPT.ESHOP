using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;
namespace EShop.MAdmin.MIssueNote
{
    public interface IIssueNoteService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, IssueNoteSearchEntity IssueNoteSearchEntity);
        List<IssueNoteEntity> Get(EmployeeEntity EmployeeEntity, IssueNoteSearchEntity IssueNoteSearchEntity);
        IssueNoteEntity Get(EmployeeEntity EmployeeEntity, Guid IssueNoteId);
        IssueNoteEntity Create(EmployeeEntity EmployeeEntity, IssueNoteEntity IssueNoteEntity);
        IssueNoteEntity Update(EmployeeEntity EmployeeEntity, Guid IssueNoteId, IssueNoteEntity IssueNoteEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid IssueNoteId);
    }
    public class IssueNoteService : CommonService, IIssueNoteService
    {
        public IssueNoteService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, IssueNoteSearchEntity IssueNoteSearchEntity)
        {
            return UnitOfWork.IssueNoteRepository.Count(IssueNoteSearchEntity);
        }
        public List<IssueNoteEntity> Get(EmployeeEntity EmployeeEntity, IssueNoteSearchEntity IssueNoteSearchEntity)
        {
            List<IssueNote> IssueNotes = UnitOfWork.IssueNoteRepository.List(IssueNoteSearchEntity);
            return IssueNotes.ToList().Select(c => new IssueNoteEntity(c)).ToList();
        }

        public IssueNoteEntity Get(EmployeeEntity EmployeeEntity, Guid IssueNoteId)
        {
            IssueNote IssueNote = UnitOfWork.IssueNoteRepository.Get(IssueNoteId);
            return new IssueNoteEntity(IssueNote);
        }
        public IssueNoteEntity Create(EmployeeEntity EmployeeEntity, IssueNoteEntity IssueNoteEntity)
        {
            if (IssueNoteEntity == null)
                throw new NotFoundException();

            IssueNote IssueNote = new IssueNote(IssueNoteEntity);
            UnitOfWork.IssueNoteRepository.AddOrUpdate(IssueNote);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, IssueNote.Id);
        }
        public IssueNoteEntity Update(EmployeeEntity EmployeeEntity, Guid IssueNoteId, IssueNoteEntity IssueNoteEntity)
        {
            IssueNoteEntity.Id = IssueNoteId;
            IssueNote IssueNote = new IssueNote(IssueNoteEntity);
            UnitOfWork.IssueNoteRepository.AddOrUpdate(IssueNote);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, IssueNote.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid IssueNoteId)
        {
            UnitOfWork.IssueNoteRepository.Delete(IssueNoteId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
