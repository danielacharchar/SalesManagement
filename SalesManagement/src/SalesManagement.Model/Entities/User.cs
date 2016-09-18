using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class User : IEntityBase
    {
        public User()
        {
            UserRoles = new List<UserRole>();
            SalesAsCashier = new List<Sale>();
            SalesAsSeller = new List<Sale>();
            SaleCommissions = new List<SaleCommission>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Sale> SalesAsCashier { get; set; }
        public virtual ICollection<Sale> SalesAsSeller { get; set; }
        public virtual ICollection<SaleCommission> SaleCommissions { get; set; }

        public double CommissionValue { get; set; }
    }
}
