using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MCarrier
{
    public interface ICarrierRepository
    {
        int Count(CarrierSearchEntity CarrierSearchEntity);
        List<Carrier> List(CarrierSearchEntity CarrierSearchEntity);
        Carrier Get(Guid Id);
        bool Add(Carrier Carrier);
        bool Update(Carrier Carrier);
        bool Delete(Guid Id);
    }
    public class CarrierRepository : CommonRepository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(EShopContext context) : base(context)
        {

        }

        public int Count(CarrierSearchEntity CarrierSearchEntity)
        {
            if (CarrierSearchEntity == null) CarrierSearchEntity = new CarrierSearchEntity();
            IQueryable<Carrier> Carriers = context.Carriers;
            Carriers = Apply(Carriers, CarrierSearchEntity);
            return Carriers.Count();
        }

        public List<Carrier> List(CarrierSearchEntity CarrierSearchEntity)
        {
            if (CarrierSearchEntity == null) CarrierSearchEntity = new CarrierSearchEntity();
            IQueryable<Carrier> Carriers = context.Carriers;
            Carriers = Apply(Carriers, CarrierSearchEntity);
            Carriers = SkipAndTake(Carriers, CarrierSearchEntity);
            return Carriers.ToList();
        }

        public Carrier Get(Guid Id)
        {
            Carrier Carrier = context.Carriers.Where(c => c.Id == Id).FirstOrDefault();
            if (Carrier == null)
                throw new NotFoundException();
            return Carrier;
        }

        public bool Add(Carrier Carrier)
        {
            if (Carrier.Id == Guid.Empty) Carrier.Id = Guid.NewGuid();
            context.Carriers.Add(Carrier);
            return true;
        }
        public bool Update(Carrier Carrier)
        {
            Carrier Current = context.Carriers.Where(c => c.Id == Carrier.Id).FirstOrDefault();
            if (Current == null) return false;
            Common<Carrier>.Copy(Carrier, Current);
            return true;
        }

        public bool Delete(Guid Id)
        {
            Carrier Carrier = Get(Id);
            context.Carriers.Remove(Carrier);
            return true;
        }

        private IQueryable<Carrier> Apply(IQueryable<Carrier> Carriers, CarrierSearchEntity CarrierSearchEntity)
        {
            if (CarrierSearchEntity.Id.HasValue)
                Carriers = Carriers.Where(T => T.Id == CarrierSearchEntity.Id.Value);
            if (!string.IsNullOrEmpty(CarrierSearchEntity.Code))
                Carriers = Carriers.Where(T => T.Code.ToLower().Contains(CarrierSearchEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(CarrierSearchEntity.Name))
                Carriers = Carriers.Where(T => T.Name.ToLower().Contains(CarrierSearchEntity.Name.ToLower()));
            if (!string.IsNullOrEmpty(CarrierSearchEntity.Address))
                Carriers = Carriers.Where(T => T.Address.ToLower().Contains(CarrierSearchEntity.Address.ToLower()));
            if (!string.IsNullOrEmpty(CarrierSearchEntity.Phone))
                Carriers = Carriers.Where(T => T.Phone.ToLower().Contains(CarrierSearchEntity.Phone.ToLower()));
            if (!string.IsNullOrEmpty(CarrierSearchEntity.Note))
                Carriers = Carriers.Where(T => T.Note.ToLower().Contains(CarrierSearchEntity.Note.ToLower()));
            if (CarrierSearchEntity.IsActive.HasValue)
                Carriers = Carriers.Where(T => T.IsActive == CarrierSearchEntity.IsActive.Value);
            return Carriers;
        }
    }
}
