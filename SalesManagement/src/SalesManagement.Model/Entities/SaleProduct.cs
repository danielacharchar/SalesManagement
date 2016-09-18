using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class SaleProduct : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
        public double Quantity { get; set; }
    }
}
