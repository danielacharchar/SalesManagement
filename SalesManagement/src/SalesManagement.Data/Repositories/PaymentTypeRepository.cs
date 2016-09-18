﻿using SalesManagement.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SalesManagement.Data.Abstract.IRepositories;

namespace SalesManagement.Data.Repositories
{
    public class PaymentTypeRepository : EntityBaseRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(SalesManagementContext context)
            : base(context)
        { }
    }
}
