using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;

namespace EShop.MAdmin.MReceiptNote
{
    public interface IReceiptNoteService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, ReceiptNoteSearchEntity ReceiptNoteSearchEntity);
        List<ReceiptNoteEntity> Get(EmployeeEntity EmployeeEntity, ReceiptNoteSearchEntity ReceiptNoteSearchEntity);
        ReceiptNoteEntity Get(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId);
        ReceiptNoteEntity Create(EmployeeEntity EmployeeEntity, ReceiptNoteEntity ReceiptNoteEntity);
        ReceiptNoteEntity Update(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId, ReceiptNoteEntity ReceiptNoteEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId);
    }
    public class ReceiptNoteService : CommonService, IReceiptNoteService
    {
        public ReceiptNoteService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, ReceiptNoteSearchEntity ReceiptNoteSearchEntity)
        {
            return UnitOfWork.ReceiptNoteRepository.Count(ReceiptNoteSearchEntity);
        }
        public List<ReceiptNoteEntity> Get(EmployeeEntity EmployeeEntity, ReceiptNoteSearchEntity ReceiptNoteSearchEntity)
        {
            List<ReceiptNote> ReceiptNotes = UnitOfWork.ReceiptNoteRepository.List(ReceiptNoteSearchEntity);
            return ReceiptNotes.ToList().Select(rn => new ReceiptNoteEntity(rn, rn.WareHouse, rn.Supplier)).ToList();
        }

        public ReceiptNoteEntity Get(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId)
        {
            ReceiptNote ReceiptNote = UnitOfWork.ReceiptNoteRepository.Get(ReceiptNoteId);
            return new ReceiptNoteEntity(ReceiptNote, ReceiptNote.WareHouse, ReceiptNote.Supplier, ReceiptNote.ReceiptNoteLines);
        }
        public ReceiptNoteEntity Create(EmployeeEntity EmployeeEntity, ReceiptNoteEntity ReceiptNoteEntity)
        {
            if (ReceiptNoteEntity == null)
                throw new NotFoundException();

            ReceiptNote ReceiptNote = new ReceiptNote(ReceiptNoteEntity);
            UnitOfWork.ReceiptNoteRepository.AddOrUpdate(ReceiptNote);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, ReceiptNote.Id);
        }
        public ReceiptNoteEntity Update(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId, ReceiptNoteEntity ReceiptNoteEntity)
        {
            if (ReceiptNoteEntity == null)
                throw new NotFoundException();
            ReceiptNoteEntity.Id = ReceiptNoteId;
            ReceiptNote ReceiptNote = new ReceiptNote(ReceiptNoteEntity);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, ReceiptNote.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid ReceiptNoteId)
        {
            UnitOfWork.ReceiptNoteRepository.Delete(ReceiptNoteId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
