using EShop.Entities;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.MAdmin.MCarrier
{
    public interface ICarrierValidator : IValidator<CarrierEntity>, ITransientService { }
    public class CarrierValidator : CommonValidator, ICarrierValidator
    {
        public CarrierValidator(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }

        public bool ValidateCreate(CarrierEntity CarrierEntity)
        {
            IsValid = true;
            if (string.IsNullOrEmpty(CarrierEntity.Code))
                CarrierEntity.AddError(nameof(CarrierEntity.Code), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Name))
                CarrierEntity.AddError(nameof(CarrierEntity.Name), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Address))
                CarrierEntity.AddError(nameof(CarrierEntity.Address), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Phone))
                CarrierEntity.AddError(nameof(CarrierEntity.Phone), "Must fill data.");
            if (CarrierEntity.Errors.Count > 0) IsValid = false;
            return IsValid;
        }

        public bool ValidateDelete(CarrierEntity CarrierEntity)
        {
            IsValid = true;
            Carrier Carrier = UnitOfWork.CarrierRepository.Get(CarrierEntity.Id);
            if (Carrier == null)
                CarrierEntity.AddError(nameof(CarrierEntity.Id), "Item doesn't exsited.");
            if (CarrierEntity.Errors.Count > 0) IsValid = false;
            return IsValid;
        }

        public bool ValidateUpdate(CarrierEntity CarrierEntity)
        {
            IsValid = true;
            Carrier Carrier = UnitOfWork.CarrierRepository.Get(CarrierEntity.Id);
            if (Carrier == null)
                CarrierEntity.AddError(nameof(CarrierEntity.Id), "Item doesn't exsited.");
            if (string.IsNullOrEmpty(CarrierEntity.Code))
                CarrierEntity.AddError(nameof(CarrierEntity.Code), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Name))
                CarrierEntity.AddError(nameof(CarrierEntity.Name), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Address))
                CarrierEntity.AddError(nameof(CarrierEntity.Address), "Must fill data.");
            if (string.IsNullOrEmpty(CarrierEntity.Phone))
                CarrierEntity.AddError(nameof(CarrierEntity.Phone), "Must fill data.");
            if (CarrierEntity.Errors.Count > 0) IsValid = false;
            return IsValid;
        }
    }
}
