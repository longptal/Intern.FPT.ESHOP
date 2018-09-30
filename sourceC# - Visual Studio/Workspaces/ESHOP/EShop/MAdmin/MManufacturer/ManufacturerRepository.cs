using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MManufacturer
{
    public interface IManufacturerRepository
    {
        int Count(ManufacturerSearchEntity SearchManufacturerEntity);
        List<Manufacturer> List(ManufacturerSearchEntity SearchManufacturerEntity);
        Manufacturer Get(Guid Id);
        void AddOrUpdate(Manufacturer Manufacturer);
        void Delete(Guid Id);
    }
    public class ManufacturerRepository : CommonRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(EShopContext context) : base(context)
        {

        }

        public int Count(ManufacturerSearchEntity SearchManufacturerEntity)
        {
            if (SearchManufacturerEntity == null) SearchManufacturerEntity = new ManufacturerSearchEntity();
            IQueryable<Manufacturer> Manufacturers = context.Manufacturers;
            Apply(Manufacturers, SearchManufacturerEntity);
            return Manufacturers.Count();
        }

        public List<Manufacturer> List(ManufacturerSearchEntity SearchManufacturerEntity)
        {
            if (SearchManufacturerEntity == null) SearchManufacturerEntity = new ManufacturerSearchEntity();
            IQueryable<Manufacturer> Manufacturers = context.Manufacturers;
            Apply(Manufacturers, SearchManufacturerEntity);
            SkipAndTake(Manufacturers, SearchManufacturerEntity);
            return Manufacturers.ToList();
        }

        public Manufacturer Get(Guid Id)
        {
            Manufacturer Manufacturer = context.Manufacturers.Where(c => c.Id == Id ).FirstOrDefault();
            if (Manufacturer == null)
                throw new NotFoundException();
            return Manufacturer;
        }

        public void AddOrUpdate(Manufacturer Manufacturer)
        {
            if (context.Entry(Manufacturer).State == EntityState.Detached)
                context.Set<Manufacturer>().Add(Manufacturer);
        }

        public void Delete(Guid Id)
        {
            Manufacturer Manufacturer = Get(Id);
            context.Manufacturers.Remove(Manufacturer);
        }

        private IQueryable<Manufacturer> Apply(IQueryable<Manufacturer> Manufacturers, ManufacturerSearchEntity SearchManufacturerEntity)
        {
            if (SearchManufacturerEntity.Id.HasValue)
                Manufacturers = Manufacturers.Where(wh => wh.Id == SearchManufacturerEntity.Id.Value);
            if (SearchManufacturerEntity.IsActive.HasValue)
                Manufacturers = Manufacturers.Where(wh => wh.IsActive == SearchManufacturerEntity.IsActive.Value);
            if (!string.IsNullOrEmpty(SearchManufacturerEntity.Code))
                Manufacturers = Manufacturers.Where(wh => wh.Code.ToLower().Contains(SearchManufacturerEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(SearchManufacturerEntity.Name))
                Manufacturers = Manufacturers.Where(wh => wh.Name.ToLower().Contains(SearchManufacturerEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(SearchManufacturerEntity.Address))
                Manufacturers = Manufacturers.Where(wh => wh.Address.ToLower().Contains(SearchManufacturerEntity.Address.ToLower()));
            if (!string.IsNullOrEmpty(SearchManufacturerEntity.Origin))
                Manufacturers = Manufacturers.Where(wh => wh.Origin.ToLower().Contains(SearchManufacturerEntity.Origin.ToLower()));
            if (!string.IsNullOrEmpty(SearchManufacturerEntity.TaxCode))
                Manufacturers = Manufacturers.Where(wh => wh.TaxCode.ToLower().Contains(SearchManufacturerEntity.TaxCode.ToLower()));
            return Manufacturers;
        }

    }
}
