using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MInvoice
{
    public interface IInvoiceRepository
    {
        int Count(InvoiceSearchEntity SearchInvoiceEntity);
        List<Invoice> List(InvoiceSearchEntity SearchInvoiceEntity);
        Invoice Get(Guid Id);
        void AddOrUpdate(Invoice Invoice);
        void Delete(Guid Id);
    }
    public class InvoiceRepository : CommonRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(EShopContext context) : base(context)
        {

        }

        public int Count(InvoiceSearchEntity SearchInvoiceEntity)
        {
            if (SearchInvoiceEntity == null) SearchInvoiceEntity = new InvoiceSearchEntity();
            IQueryable<Invoice> Invoices = context.Invoices;
            Apply(Invoices, SearchInvoiceEntity);
            return Invoices.Count();
        }

        public List<Invoice> List(InvoiceSearchEntity SearchInvoiceEntity)
        {
            if (SearchInvoiceEntity == null) SearchInvoiceEntity = new InvoiceSearchEntity();
            IQueryable<Invoice> Invoices = context.Invoices;
            Apply(Invoices, SearchInvoiceEntity);
            SkipAndTake(Invoices, SearchInvoiceEntity);
            return Invoices.ToList();
        }

        public Invoice Get(Guid Id)
        {
            Invoice Invoice = context.Invoices.Where(c => c.Id == Id ).FirstOrDefault();
            if (Invoice == null)
                throw new NotFoundException();
            return Invoice;
        }

        public void AddOrUpdate(Invoice Invoice)
        {
            if (context.Entry(Invoice).State == EntityState.Detached)
                context.Set<Invoice>().Add(Invoice);
        }

        public void Delete(Guid Id)
        {
            Invoice Invoice = context.Invoices.Where(c => c.Id == Id ).FirstOrDefault();
            if (Invoice == null)
                throw new NotFoundException();
            context.Invoices.Remove(Invoice);
        }

        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public string Number { get; set; }
        public string Seri { get; set; }

        private IQueryable<Invoice> Apply(IQueryable<Invoice> Invoices, InvoiceSearchEntity SearchInvoiceEntity)
        {
            if (SearchInvoiceEntity.Id.HasValue)
                Invoices = Invoices.Where(t => t.Id == SearchInvoiceEntity.Id.Value);
            if (SearchInvoiceEntity.OrderId.HasValue)
                Invoices = Invoices.Where(t => t.OrderId == SearchInvoiceEntity.OrderId.Value);
            if (!string.IsNullOrEmpty(SearchInvoiceEntity.Number))
                Invoices = Invoices.Where(t => t.Number.ToLower().Contains(SearchInvoiceEntity.Number.ToLower()));
            if (!string.IsNullOrEmpty(SearchInvoiceEntity.Seri))
                Invoices = Invoices.Where(t => t.Seri.ToLower().Contains(SearchInvoiceEntity.Seri.ToLower()));
            return Invoices;
        }
    }
}
