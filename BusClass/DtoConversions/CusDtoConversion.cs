using System;
using NewCore.Data.Models;
using NewCore.Dtos;

namespace NewCore.Services.BusClass.DtoConversions
{
    public class CusDtoConversion : IDisposable
    {
        private bool disposedValue;

        //----------------------
        //private static CusDtoConversion _instance = null;
        //public static CusDtoConversion Instance()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new CusDtoConversion();
        //    }
        //    return _instance;
        //}
        //--------------------
        //private static CusDtoConversion instance;
        //private static object lockObject = new Object();
        //private CusDtoConversion() { }

        //public static CusDtoConversion Instance
        //{
        //    get
        //    {
        //        lock (lockObject)
        //        {
        //            if (instance == null)
        //                instance = new CusDtoConversion();
        //        }
        //        return instance;
        //    }
        //}
        //---------------------------

        public CustomerDto Cus2CusDto(Customer cus)
        {
            return new CustomerDto
            {
                customerRef = cus.CustomerRef,
                customerId = cus.CustomerId,
                name = cus.Name,
                location = cus.Location,
                email = cus.Email
            };
        }

        public Customer CusDto2Cus(CustomerDto cusDto, bool isNew)
        {
            return new Customer
            {
                CustomerRef = isNew ? 0 : cusDto.customerRef,
                CustomerId = cusDto.customerId,
                Name = cusDto.name,
                Location = cusDto.location,
                Email = cusDto.email
            };
        }

        public void MoveCusDto2Cus(CustomerDto cusDto, Customer cus)
        {
            //CustomerRef = isNew ? 0 : cusDto.customerRef,
            //CustomerId = cusDto.customerId,
            cus.Name = cusDto.name;
            cus.Location = cusDto.location;
            cus.Email = cusDto.email;
        }

        //-------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~CusDtoConversion()
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
