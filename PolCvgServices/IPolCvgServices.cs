using System;
using System.Threading.Tasks;
using NewCore.Dtos;

namespace NewCore.Services.PolCvgServices
{
    public interface IPolCvgServices : IDisposable
    {
        //
        Task<PolCvgDto> GetPolCvgByPolIdAsync(string polId);
        //
        Task<PolCvgDto> AddPolCvgsAsyc(PolCvgDto polCvgDto);
    }
}
