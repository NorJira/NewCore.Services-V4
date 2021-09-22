using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCore.Data;
using NewCore.Data.Models;
using NewCore.Services.ServiceInterfaces;
// using static NewCore.Services.CustomerServices;

namespace NewCore.Services
{
    public partial class NewCoreServices : IServiceInterfaces
    {
        private readonly DbSet<Customer> customers;
        // private readonly NewCoreDataContext _dataContext;

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await customers.ToListAsync();
        }
    }
}
