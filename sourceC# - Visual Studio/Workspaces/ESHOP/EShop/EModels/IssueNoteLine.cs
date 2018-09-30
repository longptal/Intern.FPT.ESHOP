using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class IssueNoteLine : Base
    {
        public IssueNoteLine () : base(){}

        public IssueNoteLine (IssueNoteLineEntity IssueNoteLineEntity) : base(IssueNoteLineEntity)
        {
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is IssueNoteLine IssueNoteLine)
            {
                return Id.Equals(IssueNoteLine.Id);
            }

            return false;
        }
    }
}
