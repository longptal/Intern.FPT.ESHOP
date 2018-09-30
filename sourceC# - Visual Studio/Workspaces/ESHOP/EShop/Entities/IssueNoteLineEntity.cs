using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class IssueNoteLineEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Int32 Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean Lock { get; set; }
        public Guid? IssueNoteId { get; set; }
        public Guid? ProductId { get; set; }
        public IssueNoteEntity IssueNoteEntity { get; set; }
        public ProductEntity ProductEntity { get; set; }

        public IssueNoteLineEntity():base() { }

        public IssueNoteLineEntity(IssueNoteLine IssueNoteLine, params object[] args) :base(IssueNoteLine)
        {
		    foreach(object arg in args)
			{
                if (arg is IssueNote IssueNote)
                    IssueNoteEntity = new IssueNoteEntity(IssueNote);				
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
			}
        }
    }

    public class IssueNoteLineSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Int32? Quantity { get; set; }
        public Decimal? UnitPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Boolean? Lock { get; set; }
        public Guid? IssueNoteId { get; set; }
        public Guid? ProductId { get; set; }
    }
}
