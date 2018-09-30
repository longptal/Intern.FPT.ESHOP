using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MCarrier
{
    public interface ICarrierService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, CarrierSearchEntity CarrierSearchEntity);
        List<CarrierEntity> Get(EmployeeEntity EmployeeEntity, CarrierSearchEntity CarrierSearchEntity);
        CarrierEntity Get(EmployeeEntity EmployeeEntity, Guid CarrierId);
        CarrierEntity Create(EmployeeEntity EmployeeEntity, CarrierEntity CarrierEntity);
        CarrierEntity Update(EmployeeEntity EmployeeEntity, Guid CarrierId, CarrierEntity CarrierEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid CarrierId);
    }

    public class CarrierService : CommonService, ICarrierService
    {
        private ICarrierValidator CarrierValidator;
        public CarrierService(IUnitOfWork UnitOfWork, ICarrierValidator CarrierValidator) : base(UnitOfWork)
        {
            this.CarrierValidator = CarrierValidator;
        }
        public int Count(EmployeeEntity EmployeeEntity, CarrierSearchEntity CarrierSearchEntity)
        {
            return UnitOfWork.CarrierRepository.Count(CarrierSearchEntity);
        }
        public List<CarrierEntity> Get(EmployeeEntity EmployeeEntity, CarrierSearchEntity CarrierSearchEntity)
        {
            List<Carrier> Carriers = UnitOfWork.CarrierRepository.List(CarrierSearchEntity);
            return Carriers.Select(c => new CarrierEntity(c)).ToList();
        }

        public CarrierEntity Get(EmployeeEntity EmployeeEntity, Guid CarrierId)
        {
            Carrier Carrier = UnitOfWork.CarrierRepository.Get(CarrierId);
            if (Carrier == null)
                throw new NotFoundException();

            return new CarrierEntity(Carrier);
        }
        public CarrierEntity Create(EmployeeEntity EmployeeEntity, CarrierEntity CarrierEntity)
        {
            if (CarrierEntity == null)
                throw new NotFoundException();
            if (!CarrierValidator.ValidateCreate(CarrierEntity))
                throw new BadRequestException(CarrierEntity);
            Carrier Carrier = new Carrier(CarrierEntity);
            UnitOfWork.CarrierRepository.Add(Carrier);
            return Get(EmployeeEntity, Carrier.Id);
        }
        public CarrierEntity Update(EmployeeEntity EmployeeEntity, Guid CarrierId, CarrierEntity CarrierEntity)
        {
            if (CarrierEntity == null)
                throw new NotFoundException();
            CarrierEntity.Id = CarrierId;
            if (!CarrierValidator.ValidateUpdate(CarrierEntity))
                throw new BadRequestException(CarrierEntity);
            Carrier Carrier = new Carrier(CarrierEntity);
            UnitOfWork.CarrierRepository.Update(Carrier);
            return Get(EmployeeEntity, Carrier.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid CarrierId)
        {
            CarrierEntity CarrierEntity = new CarrierEntity { Id = CarrierId };
            if (!CarrierValidator.ValidateUpdate(CarrierEntity))
                throw new BadRequestException(CarrierEntity);
            UnitOfWork.CarrierRepository.Delete(CarrierId);
            return true;
        }
    }
}
