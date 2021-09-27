using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using NewCore.API.Dtos;
using NewCore.Data.Context;
using NewCore.Data.Models;
using NewCore.Dtos;
using NewCore.Services.Interfaces;
using NewCore.Services.BusClass.DtoConversions;

namespace NewCore.Services.CustomerServices
{
    public class CustomerServices : ICustomerServices
    {
        //private readonly DbSet<Customer> customers;
        //private readonly NewCoreDataContext dataContext;
        private readonly CusDtoConversion cusDtoConversion = new CusDtoConversion();
        private bool disposedValue;

        //public CustomerServices(NewCoreDataContext _dataContext)
        public CustomerServices()
        {
            //this.dataContext = _dataContext;
            // this.customers = _customers;
            //this.cusDtoConversion = _cusDtoConversion;
        }

        public async Task<CustomerDto> GetCustomerAsync(string cusId)
        {
            //--var result = await dataContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == cusId);
            using (NewCoreDataContext dataContext = new NewCoreDataContext())
            {
                var result = await dataContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == cusId);
                return (result is null) ? null : cusDtoConversion.Cus2CusDto(result);
            }

            //if (result is null)
            //    throw new ApplicationException($"Not found Customer ID {cusId}");
            //CustomerDto x = result.AsDto();
            //return result.AsDto();

            //if (result is null)
            //    return result;

            //--return (result is null) ? null : Convert2CusDto(result);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomersAsync()
        {
            //--var results = await dataContext.Customers.ToListAsync();

            //--return results.Count > 0 ? results.AsEnumerable().Select(cus => Convert2CusDto(cus))
            //--    : new List<CustomerDto>();
            using (NewCoreDataContext dataContext = new NewCoreDataContext())
            {
                var results = await dataContext.Customers.ToListAsync();
                return results.Count > 0 ? results.AsEnumerable().Select(cus => cusDtoConversion.Cus2CusDto(cus))
                    : new List<CustomerDto>();
            }

            //var resultsDto = new List<CustomerDto> { }; 

            //foreach ( Customer c in results)
            //{
            //    resultsDto.Add(c.AsDto());
            //}

            //return await resultsDto.AsEnumerable<>;

            //return results.AsEnumerable().Select(c => c.AsDto());
        }

        public async Task<Customer> AddCustomerAsync(CustomerDto cusDto)
        {
            //--var newCus = Convert2Cus(cusDto);
            //--await dataContext.Customers.AddAsync(newCus);
            //--await dataContext.Customers.SaveChangesAsync();
            //--return newCus;
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var newCus = cusDtoConversion.CusDto2Cus(cusDto, true);

                await dbContext.Customers.AddAsync(newCus);
                await dbContext.SaveChangesAsync();
                return newCus;
            }
        }

        public async Task UpdateCustomerAsync(CustomerDto cusDto)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                //var existingCus = CusDtoConversion.CusDto2Cus(cusDto, false);
                var existingCus = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == cusDto.customerId); 
                if (existingCus is null)
                    throw new ApplicationException($"Not found Customer Id = {cusDto.customerId}");

                cusDtoConversion.MoveCusDto2Cus(cusDto, existingCus);

                await dbContext.SaveChangesAsync();
                //return existingCus;
            }
        }

        public async Task DeleteCustomerAsync(string cusId)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var existingCus = await dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == cusId);
                if (existingCus is null)
                    throw new ApplicationException($"Not found Customer Id = {cusId}");

                dbContext.Customers.Remove(existingCus);
                await dbContext.SaveChangesAsync();
                //return existingCus;
            }
        }

        //-------------------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    cusDtoConversion.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~CustomerServices()
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

        

        // Dispose

    }
}

