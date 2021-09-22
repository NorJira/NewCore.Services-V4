using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCore.Data;
using NewCore.Data.Context;
using NewCore.Data.Models;
// using NewCore.Services.ServiceInterfaces;
using NewCore.Services;
using NewCore.Services.CustomerServices;

namespace NewCore.Services.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        private readonly DbSet<Customer> customers;
        private readonly NewCoreDataContext dataContext;

        public CustomerServices(NewCoreDataContext _dataContext,
                                DbSet<Customer> _customers
                                )
        {
            this.dataContext = _dataContext;
            this.customers = _customers;
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await customers.ToListAsync();
        }
    }
}
