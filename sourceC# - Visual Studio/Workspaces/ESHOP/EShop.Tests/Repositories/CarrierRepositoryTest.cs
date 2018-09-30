using EShop.MAdmin;
using EShop.MAdmin.MCarrier;
using EShop.Models;
using EShop.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace EShop.Tests.Repositories
{
    [TestClass]
    public class CarrierRepositoryTest : CommonTest
    {
        private ICarrierRepository CarrierRepository;
        [TestInitialize]
        public void Setup()
        {
            CarrierRepository = UnitOfWork.CarrierRepository;
        }

        [TestMethod]
        public void List_All_EqualNumberOfCount()
        {
            List<Carrier> carriers = CarrierRepository.List(null);
            int count = CarrierRepository.Count(null);
            Assert.AreEqual(count, carriers.Count);
        }

        [TestMethod]
        public void DeleteAndCreate_AnItemFromMockContext_ExistedInDatabase()
        {
            Carrier Carrier = MockContext.Carriers.FirstOrDefault();

            CarrierRepository.Delete(Carrier.Id);
            UnitOfWork.Complete();

            UnitOfWork.CarrierRepository.Add(Carrier);
            UnitOfWork.Complete();
            Carrier Existed = CarrierRepository.Get(Carrier.Id);
            Assert.AreEqual(Carrier.Id, Existed.Id);
        }

        [TestMethod]
        public void Update_LastItemHasCodeFPT_UpdateNewAddressInDatabase()
        {
            CarrierSearchEntity CarrierSearchEntity = new CarrierSearchEntity { Code = "FPT" };
            List<Carrier> carriers = CarrierRepository.List(CarrierSearchEntity);
            Carrier Carrier = carriers.LastOrDefault();
            Assert.AreNotEqual(null, Carrier);
            Carrier.Address = "17 Duy Tân Cầu Giấy";
            CarrierRepository.Update(Carrier);
            UnitOfWork.Complete();
            Carrier Existed = CarrierRepository.Get(Carrier.Id);
            Assert.AreEqual(Carrier.Address, Existed.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void Get_RandomId_NotExistedInDatabase()
        {
            Guid Id = Guid.NewGuid();
            Carrier Carrier = UnitOfWork.CarrierRepository.Get(Id);
        }

        [TestMethod]
        public void Search_FirstItemAllAttribute_IsItSelf()
        {
            List<Carrier> Carriers = CarrierRepository.List(null);
            Carrier Carrier = Carriers.LastOrDefault();
            CarrierSearchEntity CarrierSearchEntity = new CarrierSearchEntity
            {
                Id = Carrier.Id,
                Code = Carrier.Code,
                Name = Carrier.Name,
                Address = Carrier.Address,
                Phone = Carrier.Phone,
                Note = Carrier.Note
            };
            Carriers = CarrierRepository.List(CarrierSearchEntity);
            Assert.AreEqual(1, Carriers.Count);
        }
    }
}
