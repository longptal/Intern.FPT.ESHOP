using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            IssueNotes = new HashSet<IssueNote>();
            Orders = new HashSet<Order>();
            ShipmentDetails = new HashSet<ShipmentDetail>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Display { get; set; }
        public string Picture { get; set; }
        public string FacebookId { get; set; }
        public string FacebookEmail { get; set; }
        public string GoogleId { get; set; }
        public string GoogleEmail { get; set; }
        public Guid CustomerGroupId { get; set; }
        public long Cx { get; set; }

        public CustomerGroup CustomerGroup { get; set; }
        public ICollection<IssueNote> IssueNotes { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<ShipmentDetail> ShipmentDetails { get; set; }
    }
}
