using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MReceiptNote
{
    public interface IReceiptNoteRepository
    {
        int Count(ReceiptNoteSearchEntity SearchReceiptNoteEntity);
        List<ReceiptNote> List(ReceiptNoteSearchEntity SearchReceiptNoteEntity);
        ReceiptNote Get(Guid Id);
        void AddOrUpdate(ReceiptNote ReceiptNote);
        void Delete(Guid Id);
    }
    public class ReceiptNoteRepository : CommonRepository<ReceiptNote>, IReceiptNoteRepository
    {
        public ReceiptNoteRepository(EShopContext context) : base(context)
        {

        }

        public int Count(ReceiptNoteSearchEntity ReceiptNoteSearchEntity)
        {
            if (ReceiptNoteSearchEntity == null) ReceiptNoteSearchEntity = new ReceiptNoteSearchEntity();
            IQueryable<ReceiptNote> ReceiptNotes = context.ReceiptNotes;
            Apply(ReceiptNotes, ReceiptNoteSearchEntity);
            return ReceiptNotes.Count();
        }

        public List<ReceiptNote> List(ReceiptNoteSearchEntity ReceiptNoteSearchEntity)
        {
            if (ReceiptNoteSearchEntity == null) ReceiptNoteSearchEntity = new ReceiptNoteSearchEntity();
            IQueryable<ReceiptNote> ReceiptNotes = context.ReceiptNotes
                .Include(rn => rn.WareHouse)
                .Include(rn => rn.Supplier)
                .Include(rn => rn.ReceiptNoteLines).ThenInclude(rnl => rnl.Product);
            Apply(ReceiptNotes, ReceiptNoteSearchEntity);
            SkipAndTake(ReceiptNotes, ReceiptNoteSearchEntity);
            return ReceiptNotes.ToList();
        }

        public ReceiptNote Get(Guid Id)
        {
            ReceiptNote ReceiptNote = context.ReceiptNotes.Where(c => c.Id == Id )
                .Include(rn => rn.WareHouse)
                .Include(rn => rn.Supplier)
                .Include(rn => rn.ReceiptNoteLines).ThenInclude(rnl => rnl.Product)
                .FirstOrDefault();
            if (ReceiptNote == null)
                throw new NotFoundException();
            return ReceiptNote;
        }

        public void AddOrUpdate(ReceiptNote ReceiptNote)
        {
            if (context.Entry(ReceiptNote).State == EntityState.Detached)
                context.Set<ReceiptNote>().Add(ReceiptNote);
        }

        public void Delete(Guid Id)
        {
            ReceiptNote ReceiptNote = Get(Id);
            context.ReceiptNotes.Remove(ReceiptNote);
        }

        private IQueryable<ReceiptNote> Apply(IQueryable<ReceiptNote> ReceiptNotes, ReceiptNoteSearchEntity ReceiptNoteSearchEntity)
        {
            if (ReceiptNoteSearchEntity.Id.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.Id == ReceiptNoteSearchEntity.Id.Value);
            if (ReceiptNoteSearchEntity.WareHouseId.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.WareHouseId == ReceiptNoteSearchEntity.WareHouseId.Value);
            if (ReceiptNoteSearchEntity.SupplierId.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.SupplierId == ReceiptNoteSearchEntity.SupplierId.Value);
            if (ReceiptNoteSearchEntity.ReceiptNoteNo.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.ReceiptNoteNo == ReceiptNoteSearchEntity.ReceiptNoteNo.Value);
            if (!string.IsNullOrEmpty(ReceiptNoteSearchEntity.Title))
                ReceiptNotes = ReceiptNotes.Where(wh => wh.Title.ToLower().Contains(ReceiptNoteSearchEntity.Title.ToLower()));
            if (!string.IsNullOrEmpty(ReceiptNoteSearchEntity.Address))
                ReceiptNotes = ReceiptNotes.Where(wh => wh.Address.ToLower().Contains(ReceiptNoteSearchEntity.Address.ToLower()));
            if (!string.IsNullOrEmpty(ReceiptNoteSearchEntity.PhoneNumber))
                ReceiptNotes = ReceiptNotes.Where(wh => wh.PhoneNumber.ToLower().Contains(ReceiptNoteSearchEntity.PhoneNumber.ToLower()));
            if (!string.IsNullOrEmpty(ReceiptNoteSearchEntity.Comment))
                ReceiptNotes = ReceiptNotes.Where(wh => wh.Comment.ToLower().Contains(ReceiptNoteSearchEntity.Comment.ToLower()));
            if (ReceiptNoteSearchEntity.Lock.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.Lock == ReceiptNoteSearchEntity.Lock.Value);
            if (ReceiptNoteSearchEntity.EmployeeId.HasValue)
                ReceiptNotes = ReceiptNotes.Where(wh => wh.EmployeeId == ReceiptNoteSearchEntity.EmployeeId.Value);
            return ReceiptNotes;
        }
    }
}
