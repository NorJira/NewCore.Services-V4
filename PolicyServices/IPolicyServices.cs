using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;
using NewCore.Dtos;

namespace NewCore.Services.PolicyServices
{
    public interface IPolicyServices : IDisposable
    {
        Task<IEnumerable<PolicyDto>> GetPoliciesAsync();

        Task<PolicyDto> GetPolicyAsync(string polId);

        // Add New Policy
        Task<Policy> AddPolicyAsync(PolicyDto polDto);
   
        // Update Customer
        Task UpdatePolicyAsync(PolicyDto polDto);

        // Delete Customer
        Task DeletePolicyAsync(string polId);
    }
}
