using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Model.Entities
{
    public class SaleCommission : IEntityBase
    {        
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public User Seller { get; set; }
        public int SellerId { get; set; }
        public Sale Sale { get; set; }
        public int SaleId { get; set; }
        public double Value { get; set; }
    }
}
