using SalesManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesManagement.Data.Abstract
{
    public class IRepositories
    {
        public interface ICustomerRepository : IEntityBaseRepository<Customer> { }

        public interface IUserRepository : IEntityBaseRepository<User> { }

        public interface IPaymentTypeRepository : IEntityBaseRepository<PaymentType> { }

        public interface IProductRepository : IEntityBaseRepository<Product> { }

        public interface ISaleRepository : IEntityBaseRepository<Sale> { }        
    }
}
