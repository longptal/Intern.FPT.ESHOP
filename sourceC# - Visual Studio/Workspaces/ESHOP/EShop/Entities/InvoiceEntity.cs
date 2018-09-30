using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class InvoiceEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public String Number { get; set; }
        public String Seri { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public OrderEntity OrderEntity { get; set; }
        public List<InvoiceLineEntity> InvoiceLineEntities { get; set; }
        public List<IssueNoteEntity> IssueNoteEntities { get; set; }

        public InvoiceEntity():base() { }

        public InvoiceEntity(Invoice Invoice, params object[] args) :base(Invoice)
        {
		    foreach(object arg in args)
			{
                if (arg is Order Order)
                    OrderEntity = new OrderEntity(Order);				
                if (arg is ICollection<InvoiceLine> InvoiceLines)
                    InvoiceLineEntities = InvoiceLines.Select(model => new InvoiceLineEntity(model)).ToList();				
                if (arg is ICollection<IssueNote> IssueNotes)
                    IssueNoteEntities = IssueNotes.Select(model => new IssueNoteEntity(model, model.Customer, model.WareHouse)).ToList();				
			}
        }
    }

    public class InvoiceSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? OrderId { get; set; }
        public String Number { get; set; }
        public String Seri { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
