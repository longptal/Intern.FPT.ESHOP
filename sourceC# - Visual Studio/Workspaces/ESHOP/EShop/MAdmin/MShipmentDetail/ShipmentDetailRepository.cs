using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MShipmentDetail
{
    public interface IShipmentDetailRepository
    {
        int Count(ShipmentDetailSearchEntity SearchShipmentDetailEntity);
        List<ShipmentDetail> List(ShipmentDetailSearchEntity SearchShipmentDetailEntity);
        ShipmentDetail Get(Guid Id);
        void AddOrUpdate(ShipmentDetail ShipmentDetail);
        void Delete(Guid Id);
    }
    public class ShipmentDetailRepository : CommonRepository<ShipmentDetail>, IShipmentDetailRepository
    {
        public ShipmentDetailRepository(EShopContext context) : base(context)
        {

        }

        public int Count(ShipmentDetailSearchEntity SearchShipmentDetailEntity)
        {
            if (SearchShipmentDetailEntity == null) SearchShipmentDetailEntity = new ShipmentDetailSearchEntity();
            IQueryable<ShipmentDetail> ShipmentDetails = context.ShipmentDetails;
              
            Apply(ShipmentDetails, SearchShipmentDetailEntity);
            return ShipmentDetails.Count();
        }

        public List<ShipmentDetail> List(ShipmentDetailSearchEntity SearchShipmentDetailEntity)
        {
            if (SearchShipmentDetailEntity == null) SearchShipmentDetailEntity = new ShipmentDetailSearchEntity();
            IQueryable<ShipmentDetail> ShipmentDetails = context.ShipmentDetails
                .Include(sd => sd.Customer)
                .Include(sd => sd.City)
                .Include(sd => sd.Country); 
            Apply(ShipmentDetails, SearchShipmentDetailEntity);
            SkipAndTake(ShipmentDetails, SearchShipmentDetailEntity);
            return ShipmentDetails.ToList();
        }

        public ShipmentDetail Get(Guid Id)
        {
            ShipmentDetail ShipmentDetail = context.ShipmentDetails.Where(c => c.Id == Id )
                .Include(sd => sd.Customer)
                .Include(sd => sd.City)
                .Include(sd => sd.Country)
                .FirstOrDefault();
            if (ShipmentDetail == null)
                throw new NotFoundException();
            return ShipmentDetail;
        }

        public void AddOrUpdate(ShipmentDetail ShipmentDetail)
        {
            if (context.Entry(ShipmentDetail).State == EntityState.Detached)
                context.Set<ShipmentDetail>().Add(ShipmentDetail);
        }

        public void Delete(Guid Id)
        {
            ShipmentDetail ShipmentDetail = Get(Id);
            context.ShipmentDetails.Remove(ShipmentDetail);
        }


        private IQueryable<ShipmentDetail> Apply(IQueryable<ShipmentDetail> ShipmentDetails, ShipmentDetailSearchEntity SearchShipmentDetailEntity)
        {
            if (SearchShipmentDetailEntity.Id.HasValue)
                ShipmentDetails = ShipmentDetails.Where(t => t.Id == SearchShipmentDetailEntity.Id.Value);
            if (!string.IsNullOrEmpty(SearchShipmentDetailEntity.FullName))
                ShipmentDetails = ShipmentDetails.Where(t => t.FullName.ToLower().Contains(SearchShipmentDetailEntity.FullName.ToLower()));
            if (SearchShipmentDetailEntity.CountryId.HasValue)
                ShipmentDetails = ShipmentDetails.Where(t => t.CountryId == SearchShipmentDetailEntity.CountryId.Value);
            if (SearchShipmentDetailEntity.CityId.HasValue)
                ShipmentDetails = ShipmentDetails.Where(t => t.CityId == SearchShipmentDetailEntity.CityId.Value);
            if (!string.IsNullOrEmpty(SearchShipmentDetailEntity.Address))
                ShipmentDetails = ShipmentDetails.Where(t => t.Address.ToLower().Contains(SearchShipmentDetailEntity.Address.ToLower()));
            if (!string.IsNullOrEmpty(SearchShipmentDetailEntity.Phone))
                ShipmentDetails = ShipmentDetails.Where(t => t.Phone.ToLower().Contains(SearchShipmentDetailEntity.Phone.ToLower()));
            if (!string.IsNullOrEmpty(SearchShipmentDetailEntity.Note))
                ShipmentDetails = ShipmentDetails.Where(t => t.Note.ToLower().Contains(SearchShipmentDetailEntity.Note.ToLower()));
            if (SearchShipmentDetailEntity.CustomerId.HasValue)
                ShipmentDetails = ShipmentDetails.Where(t => t.CustomerId == SearchShipmentDetailEntity.CustomerId.Value);
            return ShipmentDetails;
        }
    }
}
