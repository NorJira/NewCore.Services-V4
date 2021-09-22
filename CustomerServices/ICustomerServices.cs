using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;

namespace NewCore.Services.Interfaces
{

    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }

}
