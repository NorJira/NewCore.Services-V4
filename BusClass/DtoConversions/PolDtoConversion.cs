using System;
using NewCore.Data.Models;
using NewCore.Dtos;

namespace NewCore.Services.BusClass.DtoConversions
{
    public class PolDtoConversion : IDisposable
    {
        private bool disposedValue;

        public PolicyDto Pol2PolDto(Policy pol)
        {
            return new PolicyDto
            {
                polRef = pol.PolRef,
                polId = pol.PolId,
                polCommDt = pol.PolCommDt,
                polExpryDate = pol.PolExpryDate,
                customerId = pol.CustomerId,
                polStatus = pol.PolStatus,
                planId = pol.PlanId,
                polFaceAmt = pol.PolFaceAmt,
                polPremAmt = pol.PolPremAmt
            };
        }

        public Policy PolDto2Pol(PolicyDto polDto, bool isNew)
        {
            return new Policy
            {
                PolRef = isNew ? 0 : polDto.polRef,
                PolId = polDto.polId,
                PolCommDt = polDto.polCommDt,
                PolExpryDate = polDto.polExpryDate,
                CustomerId = polDto.customerId,
                PolStatus = polDto.polStatus,
                PlanId = polDto.planId,
                PolFaceAmt = polDto.polFaceAmt,
                PolPremAmt = polDto.polPremAmt
            };
        }

        public void MovePolDto2Pol(PolicyDto polDto, Policy pol)
        {
            pol.PolRef = polDto.polRef;
            pol.PolId = polDto.polId;
            pol.PolCommDt = polDto.polCommDt;
            pol.PolExpryDate = polDto.polExpryDate;
            pol.CustomerId = polDto.customerId;
            pol.PolStatus = polDto.polStatus;
            pol.PlanId = polDto.planId;
            pol.PolFaceAmt = polDto.polFaceAmt;
            pol.PolPremAmt = polDto.polPremAmt;
        }
        //-------------------------------------------
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
        ~PolDtoConversion()
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
