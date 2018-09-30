using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;
using static EShop.Entities.DiscountEntity;

namespace EShop.MAdmin.MDiscount
{
    public interface IDiscountService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, DiscountSearchEntity DiscountSearchEntity);
        List<DiscountEntity> Get(EmployeeEntity EmployeeEntity, DiscountSearchEntity DiscountSearchEntity);
        DiscountEntity Get(EmployeeEntity EmployeeEntity, Guid DiscountId);
        DiscountEntity Create(EmployeeEntity EmployeeEntity, DiscountEntity DiscountEntity);
        DiscountEntity Update(EmployeeEntity EmployeeEntity, Guid DiscountId, DiscountEntity DiscountEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid DiscountId);
    }
    public class DiscountService : CommonService, IDiscountService
    {
        public DiscountService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, DiscountSearchEntity DiscountSearchEntity)
        {
            return UnitOfWork.DiscountRepository.Count(DiscountSearchEntity);
        }
        public List<DiscountEntity> Get(EmployeeEntity EmployeeEntity, DiscountSearchEntity DiscountSearchEntity)
        {
            List<Discount> Discounts = UnitOfWork.DiscountRepository.List(DiscountSearchEntity);
            return Discounts.ToList().Select(c => new DiscountEntity(c)).ToList();
        }

        public DiscountEntity Get(EmployeeEntity EmployeeEntity, Guid DiscountId)
        {
            Discount Discount = UnitOfWork.DiscountRepository.Get(DiscountId);
            return new DiscountEntity(Discount);
        }
        public DiscountEntity Create(EmployeeEntity EmployeeEntity, DiscountEntity DiscountEntity)
        {
            if (DiscountEntity == null)
                throw new NotFoundException();
            Discount Discount = new Discount(DiscountEntity);
            UnitOfWork.DiscountRepository.AddOrUpdate(Discount);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Discount.Id);
        }
        public DiscountEntity Update(EmployeeEntity EmployeeEntity, Guid DiscountId, DiscountEntity DiscountEntity)
        {
            Discount Discount = UnitOfWork.DiscountRepository.Get(DiscountId);
            DiscountEntity.Id = DiscountId;
            Discount = new Discount(DiscountEntity);
            UnitOfWork.DiscountRepository.AddOrUpdate(Discount);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Discount.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid DiscountId)
        {
            UnitOfWork.DiscountRepository.Delete(DiscountId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
