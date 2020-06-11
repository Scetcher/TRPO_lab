using System;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork.Interfaces;

namespace BLL.Services
{
    public class ServiceStationService : IServiceStationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceStationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            if (mapper == null)
            {
                throw new ArgumentNullException(
                    nameof(mapper));
            }

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceStationDTO> GetSerciveStationAsync(Guid id)
        {
            return _mapper.Map<ServiceStation, ServiceStationDTO>(await GetById(id));
        }

        public async Task<ServiceStationDTO> AddSensorAsync(ServiceStationDTO region)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = _mapper.Map<ServiceStationDTO, ServiceStation>(region);
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ServiceStation, ServiceStationDTO>(result);
        }

        public async Task RemoveServiceStation(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var sensor = await GetById(id);
            _unitOfWork.Remove(sensor);
            await _unitOfWork.CommitAsync();
        }

        private async Task<ServiceStation> GetById(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<ServiceStation>(id);

            if (region == null)
            {
                throw new Exception("LocalPoint with following id was not found");
            }

            return region;
        }
    }
}