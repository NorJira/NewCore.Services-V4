using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using NewCore.Data.Context;
using NewCore.Data.Models;
using NewCore.Dtos;
using NewCore.Services.BusClass;
using NewCore.Services.BusClass.DtoConversions;

namespace NewCore.Services.PolCvgServices
{
    public class PolCvgServices : IPolCvgServices
    {
        //private readonly CusBAL cusBal = new CusBAL();
        private readonly PolDtoConversion polDtoConversion = new PolDtoConversion();
        private readonly CvgDtoConversion cvgDtoConversion = new CvgDtoConversion();
        private bool disposedValue;

        public PolCvgServices()
        {
            //var s1 = cusBal.CusFunc1();
            //var s2 = cusBal.CusFunc3();
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
        }

        public async Task<PolCvgDto> GetPolCvgByPolIdAsync(string polId)
        {
            using (NewCoreDataContext dbContext = new NewCoreDataContext())
            {
                var pol = await dbContext.Policies.FirstOrDefaultAsync(p => p.PolId.Trim() == polId);
                var cvgs = await dbContext.Coverages.Where(c => c.PolId.Trim() == polId).ToListAsync();

                if ((pol is null) || (cvgs is null)) {
                    throw new ApplicationException($"Not found Policy or Coverage Info for PolId = {polId}");
                }
                //var result = new PolCvgDto { polInfo = null, cvgsInfo = new IEnumerable<CoverageDto>() };
                return new PolCvgDto()
                {
                    polInfo = polDtoConversion.Pol2PolDto(pol),
                    cvgsInfo = cvgs.Count > 0 ? cvgs.AsEnumerable().Select(cvg => cvgDtoConversion.Cvg2CvgDto(cvg))
                        : new List<CoverageDto>()
                };
            }
        }

        public async Task<PolCvgDto> AddPolCvgsAsyc(PolCvgDto polCvgDto)
        {
            //var options = new TransactionOptions
            //{
            //    IsolationLevel = IsolationLevel.ReadCommitted,
            //    Timeout = TransactionManager.DefaultTimeout
            //};

            // do not use try/catch here because transactionscope will throw ex itself
            using (var transactionScope = new TransactionScope(
                TransactionScopeOption.Required,
                new TransactionOptions {
                    IsolationLevel = IsolationLevel.ReadCommitted,
                    Timeout = TransactionManager.DefaultTimeout },
                TransactionScopeAsyncFlowOption.Enabled))
            {
                using (NewCoreDataContext dbContext = new NewCoreDataContext())
                {

                    // Add new policy
                    var newPol = polDtoConversion.PolDto2Pol(polCvgDto.polInfo, true);

                    await dbContext.Policies.AddAsync(newPol);
                    await dbContext.SaveChangesAsync();
                    // save new ref back to dto
                    polCvgDto.polInfo.polRef = newPol.PolRef;
                    // Add coverages
                    if (polCvgDto.cvgsInfo.Count() == 0)
                        throw new ApplicationException("Not found Coverage info");
                    // save each coverage
                    foreach (CoverageDto cvgDto in polCvgDto.cvgsInfo)
                    {
                        var newCvg = cvgDtoConversion.CvgDto2Cvg(cvgDto, true);

                        await dbContext.Coverages.AddAsync(newCvg);
                        await dbContext.SaveChangesAsync();
                        // save new ref back to dto
                        cvgDto.cvgRef = newCvg.CvgRef;
                    }
                };
                /// Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transactionScope.Complete();
                // return polCvgDto
                return polCvgDto;
            };
        }
    
        //---------------------------------------------------------
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    polDtoConversion.Dispose();
                    cvgDtoConversion.Dispose();
                    //cusBal.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~PolCvgServices()
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
        //-----------------------------------------
    }
}
