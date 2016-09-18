using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class PaymentType : IEntityBase
    {
        public PaymentType()
        {
            Sales = new List<Sale>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
