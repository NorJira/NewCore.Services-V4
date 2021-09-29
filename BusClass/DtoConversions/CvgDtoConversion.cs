using System;
using NewCore.Data.Models;
using NewCore.Dtos;

namespace NewCore.Services.BusClass.DtoConversions
{
    public class CvgDtoConversion : IDisposable
    {
        private bool disposedValue;

        public CvgDtoConversion() 
        {
        }

        public CoverageDto Cvg2CvgDto(Coverage cvg)
        {
            return new CoverageDto
            {
                cvgRef = cvg.CvgRef,
                polId = cvg.PolId,
                cvgNo = cvg.CvgNo,
                cvgStatus = cvg.CvgStatus,
                cvgCommDt = cvg.CvgCommDt,
                cvgExpryDate = cvg.CvgExpryDate,
                customerId = cvg.CustomerId,
                planId = cvg.PlanId,
                cvgFaceAmt = cvg.CvgFaceAmt,
                cvgPremAmt = cvg.CvgPremAmt
            };
        }

        public Coverage CvgDto2Cvg(CoverageDto cvgDto, bool isNew)
        {
            return new Coverage
            {
                CvgRef = isNew ? 0 : cvgDto.cvgRef,
                PolId = cvgDto.polId,
                CvgNo = cvgDto.cvgNo,
                CvgStatus = cvgDto.cvgStatus,
                CvgCommDt = cvgDto.cvgCommDt,
                CvgExpryDate = cvgDto.cvgExpryDate,
                CustomerId = cvgDto.customerId,
                PlanId = cvgDto.planId,
                CvgFaceAmt = cvgDto.cvgFaceAmt,
                CvgPremAmt = cvgDto.cvgPremAmt
            };
        }

        public void MoveCvgDto2Cvg(CoverageDto cvgDto, Coverage cvg)
        {
            cvg.CvgRef = cvgDto.cvgRef;
            cvg.PolId = cvgDto.polId;
            cvg.CvgNo = cvgDto.cvgNo;
            cvg.CvgStatus = cvgDto.cvgStatus;
            cvg.CvgCommDt = cvgDto.cvgCommDt;
            cvg.CvgExpryDate = cvgDto.cvgExpryDate;
            cvg.CustomerId = cvgDto.customerId;
            cvg.PlanId = cvgDto.planId;
            cvg.CvgFaceAmt = cvgDto.cvgFaceAmt;
            cvg.CvgPremAmt = cvgDto.cvgPremAmt;
        }
        //----------------------------
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
        // ~PolCvgDtoConversion()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
