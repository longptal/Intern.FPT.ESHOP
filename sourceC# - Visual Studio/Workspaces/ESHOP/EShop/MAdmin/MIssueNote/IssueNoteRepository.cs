using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MIssueNote
{
    public interface IIssueNoteRepository
    {
        int Count(IssueNoteSearchEntity SearchIssueNoteEntity);
        List<IssueNote> List(IssueNoteSearchEntity SearchIssueNoteEntity);
        IssueNote Get(Guid Id);
        void AddOrUpdate(IssueNote IssueNote);
        void Delete(Guid Id);
    }
    public class IssueNoteRepository : CommonRepository<IssueNote>, IIssueNoteRepository
    {
        public IssueNoteRepository(EShopContext context) : base(context)
        {

        }

        public int Count(IssueNoteSearchEntity SearchIssueNoteEntity)
        {
            if (SearchIssueNoteEntity == null) SearchIssueNoteEntity = new IssueNoteSearchEntity();
            IQueryable<IssueNote> IssueNotes = context.IssueNotes;
            Apply(IssueNotes, SearchIssueNoteEntity);
            return IssueNotes.Count();
        }

        public List<IssueNote> List(IssueNoteSearchEntity SearchIssueNoteEntity)
        {
            if (SearchIssueNoteEntity == null) SearchIssueNoteEntity = new IssueNoteSearchEntity();
            IQueryable<IssueNote> IssueNotes = context.IssueNotes;
            Apply(IssueNotes, SearchIssueNoteEntity);
            SkipAndTake(IssueNotes, SearchIssueNoteEntity);
            return IssueNotes.ToList();
        }

        public IssueNote Get(Guid Id)
        {
            IssueNote IssueNote = context.IssueNotes.Where(c => c.Id == Id ).FirstOrDefault();
            if (IssueNote == null)
                throw new NotFoundException();
            return IssueNote;
        }

        public void AddOrUpdate(IssueNote IssueNote)
        {
            if (context.Entry(IssueNote).State == EntityState.Detached)
                context.Set<IssueNote>().Add(IssueNote);
        }

        public void Delete(Guid Id)
        {
            IssueNote IssueNote = Get(Id);
            context.IssueNotes.Remove(IssueNote);
        }

        public Guid? Id { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? WareHouseId { get; set; }
        public bool? Lock { get; set; }

        private IQueryable<IssueNote> Apply(IQueryable<IssueNote> IssueNotes, IssueNoteSearchEntity SearchIssueNoteEntity)
        {
            if (SearchIssueNoteEntity.Id.HasValue)
                IssueNotes = IssueNotes.Where(t => t.Id == SearchIssueNoteEntity.Id.Value);
            if (SearchIssueNoteEntity.InvoiceId.HasValue)
                IssueNotes = IssueNotes.Where(t => t.InvoiceId == SearchIssueNoteEntity.InvoiceId.Value);
            if (SearchIssueNoteEntity.CustomerId.HasValue)
                IssueNotes = IssueNotes.Where(t => t.CustomerId == SearchIssueNoteEntity.CustomerId.Value);
            if (SearchIssueNoteEntity.WareHouseId.HasValue)
                IssueNotes = IssueNotes.Where(t => t.WareHouseId == SearchIssueNoteEntity.WareHouseId.Value);
            if (SearchIssueNoteEntity.Lock.HasValue)
                IssueNotes = IssueNotes.Where(t => t.Lock == SearchIssueNoteEntity.Lock.Value);
            return IssueNotes;
        }
    }
}
