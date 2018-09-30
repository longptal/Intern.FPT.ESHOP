using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class IssueNote : Base
    {

        public IssueNote (IssueNoteEntity IssueNoteEntity) : base(IssueNoteEntity)
        {

			if (IssueNoteEntity.IssueNoteLineEntities != null)
            {
                this.IssueNoteLines = new HashSet<IssueNoteLine>();
                foreach (IssueNoteLineEntity IssueNoteLineEntity in IssueNoteEntity.IssueNoteLineEntities)
                {
					IssueNoteLineEntity.IssueNoteId = IssueNoteEntity.Id;
                    this.IssueNoteLines.Add(new IssueNoteLine(IssueNoteLineEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is IssueNote IssueNote)
            {
                return Id.Equals(IssueNote.Id);
            }

            return false;
        }
    }
}
