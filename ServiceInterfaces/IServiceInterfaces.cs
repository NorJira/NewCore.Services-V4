using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;

namespace NewCore.Services.ServiceInterfaces
{
    public interface IServiceInterfaces
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
