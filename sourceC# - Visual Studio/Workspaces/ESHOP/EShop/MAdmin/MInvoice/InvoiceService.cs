using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;
namespace EShop.MAdmin.MInvoice
{
    public interface IInvoiceService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, InvoiceSearchEntity InvoiceSearchEntity);
        List<InvoiceEntity> Get(EmployeeEntity EmployeeEntity, InvoiceSearchEntity InvoiceSearchEntity);
        InvoiceEntity Get(EmployeeEntity EmployeeEntity, Guid InvoiceId);
        InvoiceEntity Create(EmployeeEntity EmployeeEntity, InvoiceEntity InvoiceEntity);
        InvoiceEntity Update(EmployeeEntity EmployeeEntity, Guid InvoiceId, InvoiceEntity InvoiceEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid InvoiceId);
    }
    public class InvoiceService : CommonService, IInvoiceService
    {
        public InvoiceService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, InvoiceSearchEntity InvoiceSearchEntity)
        {
            return UnitOfWork.InvoiceRepository.Count(InvoiceSearchEntity);
        }
        public List<InvoiceEntity> Get(EmployeeEntity EmployeeEntity, InvoiceSearchEntity InvoiceSearchEntity)
        {
            List<Invoice> Invoices = UnitOfWork.InvoiceRepository.List(InvoiceSearchEntity);
            return Invoices.ToList().Select(c => new InvoiceEntity(c)).ToList();
        }

        public InvoiceEntity Get(EmployeeEntity EmployeeEntity, Guid InvoiceId)
        {
            Invoice Invoice = UnitOfWork.InvoiceRepository.Get(InvoiceId);
            return new InvoiceEntity(Invoice);
        }
        public InvoiceEntity Create(EmployeeEntity EmployeeEntity, InvoiceEntity InvoiceEntity)
        {
            if (InvoiceEntity == null)
                throw new NotFoundException();
            Invoice Invoice = new Invoice(InvoiceEntity);
            UnitOfWork.InvoiceRepository.AddOrUpdate(Invoice);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Invoice.Id);
        }
        public InvoiceEntity Update(EmployeeEntity EmployeeEntity, Guid InvoiceId, InvoiceEntity InvoiceEntity)
        {
            InvoiceEntity.Id = InvoiceId;
            Invoice Invoice = new Invoice(InvoiceEntity);
            UnitOfWork.InvoiceRepository.AddOrUpdate(Invoice);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Invoice.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid InvoiceId)
        {
            UnitOfWork.InvoiceRepository.Delete(InvoiceId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
