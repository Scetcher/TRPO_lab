using System;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IServiceStationService
    {
        Task<ServiceStationDTO> GetSerciveStationAsync(Guid id);
        Task<ServiceStationDTO> AddSensorAsync(ServiceStationDTO region);
        Task RemoveServiceStation(Guid id);
    }
}