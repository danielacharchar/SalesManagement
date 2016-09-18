using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class Price : IEntityBase
    {        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime RegistrationDate { get; set; }
        public double Value { get; set; }
    }
}
