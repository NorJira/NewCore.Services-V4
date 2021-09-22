using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCore.Data.Context;
using NewCore.Data.Models;

namespace NewCore.Services.PolicyServices
{
    public class PolicyServices : IPolicyServices
    {
        // private readonly DbSet<Customer> customers;
        private readonly NewCoreDataContext dataContext;

        public PolicyServices(NewCoreDataContext _dataContext)
        {
            this.dataContext = _dataContext;
        }

        public async Task<IEnumerable<Policy>> GetPoliciesAsync()
        {
            return await dataContext.Policies.ToListAsync();
        }
    }
}
