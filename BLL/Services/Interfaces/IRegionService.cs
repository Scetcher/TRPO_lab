using System;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IRegionService
    {
        Task<RegionDTO> GeteRegionAsync(Guid id);
        Task<RegionDTO> AddRegionAsync(RegionDTO region);
        Task RemoveRegion(Guid id);
    }
}