using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;

namespace NewCore.Services.ServiceInterfaces
{
    public partial class CustomerServices
    {
        public interface ICustomerServices
        {
            Task<IEnumerable<Customer>> GetCustomersAsync();
        }
    }
}
