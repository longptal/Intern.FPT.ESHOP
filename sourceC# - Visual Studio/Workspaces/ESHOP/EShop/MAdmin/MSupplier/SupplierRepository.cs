using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MSupplier
{
    public interface ISupplierRepository
    {
        int Count(SupplierSearchEntity SearchSupplierEntity);
        List<Supplier> List(SupplierSearchEntity SearchSupplierEntity);
        Supplier Get(Guid Id);
        void AddOrUpdate(Supplier Supplier);
        void Delete(Guid Id);
    }
    public class SupplierRepository : CommonRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(EShopContext context) : base(context)
        {

        }

        public int Count(SupplierSearchEntity SearchSupplierEntity)
        {
            if (SearchSupplierEntity == null) SearchSupplierEntity = new SupplierSearchEntity();
            IQueryable<Supplier> Suppliers = context.Suppliers;
            Apply(Suppliers, SearchSupplierEntity);
            return Suppliers.Count();
        }

        public List<Supplier> List(SupplierSearchEntity SearchSupplierEntity)
        {
            if (SearchSupplierEntity == null) SearchSupplierEntity = new SupplierSearchEntity();
            IQueryable<Supplier> Suppliers = context.Suppliers;
            Apply(Suppliers, SearchSupplierEntity);
            SkipAndTake(Suppliers, SearchSupplierEntity);
            return Suppliers.ToList();
        }

        public Supplier Get(Guid Id)
        {
            Supplier Supplier = context.Suppliers.Where(c => c.Id == Id ).FirstOrDefault();
            if (Supplier == null)
                throw new NotFoundException();
            return Supplier;
        }

        public void AddOrUpdate(Supplier Supplier)
        {
            if (context.Entry(Supplier).State == EntityState.Detached)
                context.Set<Supplier>().Add(Supplier);
        }

        public void Delete(Guid Id)
        {
            Supplier Supplier = Get(Id);
            context.Suppliers.Remove(Supplier);
        }
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string TaxCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Origin { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }

        private IQueryable<Supplier> Apply(IQueryable<Supplier> Suppliers, SupplierSearchEntity SearchSupplierEntity)
        {
            if (SearchSupplierEntity.Id.HasValue)
                Suppliers = Suppliers.Where(t => t.Id == SearchSupplierEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchSupplierEntity.Name))
                Suppliers = Suppliers.Where(t => t.Name.ToLower().Contains(SearchSupplierEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(SearchSupplierEntity.TaxCode))
                Suppliers = Suppliers.Where(t => t.TaxCode.ToLower().Contains(SearchSupplierEntity.TaxCode.ToLower()));
            if (!string.IsNullOrEmpty(SearchSupplierEntity.Address))
                Suppliers = Suppliers.Where(t => t.Address.ToLower().Contains(SearchSupplierEntity.Address.ToLower()));
            if (!string.IsNullOrEmpty(SearchSupplierEntity.Phone))
                Suppliers = Suppliers.Where(t => t.Phone.ToLower().Contains(SearchSupplierEntity.Phone.ToLower()));
            if (!string.IsNullOrEmpty(SearchSupplierEntity.Origin))
                Suppliers = Suppliers.Where(t => t.Origin.ToLower().Contains(SearchSupplierEntity.Origin.ToLower()));
            if (!string.IsNullOrEmpty(SearchSupplierEntity.Description))
                Suppliers = Suppliers.Where(t => t.Description.ToLower().Contains(SearchSupplierEntity.Description.ToLower()));
            if (SearchSupplierEntity.IsActive.HasValue)
                Suppliers = Suppliers.Where(t => t.IsActive == SearchSupplierEntity.IsActive.Value);
            return Suppliers;
        }
    }
}
