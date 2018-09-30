using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Invoice : Base
    {

        public Invoice (InvoiceEntity InvoiceEntity) : base(InvoiceEntity)
        {

			if (InvoiceEntity.InvoiceLineEntities != null)
            {
                this.InvoiceLines = new HashSet<InvoiceLine>();
                foreach (InvoiceLineEntity InvoiceLineEntity in InvoiceEntity.InvoiceLineEntities)
                {
					InvoiceLineEntity.InvoiceId = InvoiceEntity.Id;
                    this.InvoiceLines.Add(new InvoiceLine(InvoiceLineEntity));
                }
            }

			if (InvoiceEntity.IssueNoteEntities != null)
            {
                this.IssueNotes = new HashSet<IssueNote>();
                foreach (IssueNoteEntity IssueNoteEntity in InvoiceEntity.IssueNoteEntities)
                {
					IssueNoteEntity.InvoiceId = InvoiceEntity.Id;
                    this.IssueNotes.Add(new IssueNote(IssueNoteEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Invoice Invoice)
            {
                return Id.Equals(Invoice.Id);
            }

            return false;
        }
    }
}
