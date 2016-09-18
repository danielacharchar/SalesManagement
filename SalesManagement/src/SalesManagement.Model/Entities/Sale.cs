using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class Sale : IEntityBase
    {
        public Sale()
        {
            SaleProducts = new List<SaleProduct>();
            SaleCommissions = new List<SaleCommission>();
        }
        public int Id { get; set; }
        public SaleStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public User Seller { get; set; }
        public int SellerId { get; set; }
        public User Cashier { get; set; }
        public int CashierId { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
        public virtual ICollection<SaleCommission> SaleCommissions { get; set; }
        
    }
}
