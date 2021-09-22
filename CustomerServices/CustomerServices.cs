using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCore.Data.Context;
using NewCore.Data.Models;
using NewCore.Services.Interfaces;

namespace NewCore.Services.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        // private readonly DbSet<Customer> customers;
        private readonly NewCoreDataContext dataContext;

        public CustomerServices(NewCoreDataContext _dataContext)
        {
            this.dataContext = _dataContext;
            // this.customers = _customers;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            // return await dataContext.Customers.ToListAsync();
            try
            {
                return await dataContext.Customers.ToListAsync();
            } catch {
                throw new ApplicationException("Error GetCustomers()");
            } finally
            {
                //
            } 

        }

    }
}

