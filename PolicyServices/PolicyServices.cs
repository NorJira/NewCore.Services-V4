using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewCore.Data.Context;
using NewCore.Data.Models;
using NewCore.Dtos;
using NewCore.Services.BusClass.DtoConversions;

namespace NewCore.Services.PolicyServices
{
    public class PolicyServices : IPolicyServices
    {
        // private readonly DbSet<Customer> customers;
        //private readonly NewCoreDataContext dataContext;
        private readonly PolDtoConversion polDtoConversion = new PolDtoConversion();
        private bool disposedValue;

        public PolicyServices()
        {
            //this.dataContext = _dataContext;
        }

        public async Task<PolicyDto> GetPolicyAsync(string polId)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var result = await dbContext.Policies.FirstOrDefaultAsync(p => p.PolId.Trim() == polId);
                return (result is null) ? null : polDtoConversion.Pol2PolDto(result);
            }
        }

        public async Task<IEnumerable<PolicyDto>> GetPoliciesAsync()
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var results = await dbContext.Policies.ToListAsync();
                return results.Count > 0 ? results.AsEnumerable().Select(pol => polDtoConversion.Pol2PolDto(pol))
                    : new List<PolicyDto>();
            }
            
        }

        public async Task<Policy> AddPolicyAsync(PolicyDto polDto)
        {
            
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var newPol = polDtoConversion.PolDto2Pol(polDto, true);

                await dbContext.Policies.AddAsync(newPol);
                await dbContext.SaveChangesAsync();
                return newPol;
            }
        }

        public async Task UpdatePolicyAsync(PolicyDto polDto)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                //var existingCus = CusDtoConversion.CusDto2Cus(cusDto, false);
                var existingPol = await dbContext.Policies.FirstOrDefaultAsync(p => p.PolId == polDto.polId);
                if (existingPol is null)
                    throw new ApplicationException($"Not found Policy Id = {polDto.polId}");

                polDtoConversion.MovePolDto2Pol(polDto, existingPol);

                await dbContext.SaveChangesAsync();
                //return existingCus;
            }
        }

        public async Task DeletePolicyAsync(string polId)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var existingPol = await dbContext.Policies.FirstOrDefaultAsync(p => p.PolId == polId);
                if (existingPol is null)
                    throw new ApplicationException($"Not found Policy Id = {polId}");

                dbContext.Policies.Remove(existingPol);
                await dbContext.SaveChangesAsync();
                //return existingCus;
            }
        }
        //-----------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    polDtoConversion.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~PolicyServices()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        
    }
}
