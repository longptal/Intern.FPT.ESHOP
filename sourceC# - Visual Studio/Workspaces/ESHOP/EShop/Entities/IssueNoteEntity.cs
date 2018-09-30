using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class IssueNoteEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Title { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid WareHouseId { get; set; }
        public Boolean Lock { get; set; }
        public CustomerEntity CustomerEntity { get; set; }
        public InvoiceEntity InvoiceEntity { get; set; }
        public WareHouseEntity WareHouseEntity { get; set; }
        public List<IssueNoteLineEntity> IssueNoteLineEntities { get; set; }

        public IssueNoteEntity():base() { }

        public IssueNoteEntity(IssueNote IssueNote, params object[] args) :base(IssueNote)
        {
		    foreach(object arg in args)
			{
                if (arg is Customer Customer)
                    CustomerEntity = new CustomerEntity(Customer);				
                if (arg is Invoice Invoice)
                    InvoiceEntity = new InvoiceEntity(Invoice);				
                if (arg is WareHouse WareHouse)
                    WareHouseEntity = new WareHouseEntity(WareHouse);				
                if (arg is ICollection<IssueNoteLine> IssueNoteLines)
                    IssueNoteLineEntities = IssueNoteLines.Select(model => new IssueNoteLineEntity(model, model.Product)).ToList();				
			}
        }
    }

    public class IssueNoteSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Title { get; set; }
        public Guid? InvoiceId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? WareHouseId { get; set; }
        public Boolean? Lock { get; set; }
    }
}
