using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;
using NewCore.Dtos;

namespace NewCore.Services.Interfaces
{

    public interface ICustomerServices : IDisposable
    {
        // Get All Customers
        Task<IEnumerable<CustomerDto>> GetCustomersAsync();

        // Get Customer by ID
        Task<CustomerDto> GetCustomerAsync(string cusId);

        // Add New Customer
        Task<Customer> AddCustomerAsync(CustomerDto cusDto);

        // Update Customer
        Task UpdateCustomerAsync(CustomerDto cusDto);

        // Delete Customer
        Task DeleteCustomerAsync(string cusId);

    }

}
