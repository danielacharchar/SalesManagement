using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class Product : IEntityBase
    {
        public Product()
        {
            Prices = new List<Price>();
            SaleProducts = new List<SaleProduct>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public string Unit { get; set; }        
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
