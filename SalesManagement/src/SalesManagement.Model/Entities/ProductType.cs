using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{    
    public class ProductType : IEntityBase
    {
        public ProductType()
        {
            Products = new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
