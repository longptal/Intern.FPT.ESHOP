using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Permissions = new HashSet<Permission>();
            ReceiptNotes = new HashSet<ReceiptNote>();
            WareHouses = new HashSet<WareHouse>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Display { get; set; }
        public string Phone { get; set; }
        public string IdentityCard { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Picture { get; set; }
        public long Cx { get; set; }

        public ICollection<Permission> Permissions { get; set; }
        public ICollection<ReceiptNote> ReceiptNotes { get; set; }
        public ICollection<WareHouse> WareHouses { get; set; }
    }
}
