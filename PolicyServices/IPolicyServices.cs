using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewCore.Data.Models;

namespace NewCore.Services.PolicyServices
{
    public interface IPolicyServices
    {
        Task<IEnumerable<Policy>> GetPoliciesAsync();
    }
}
