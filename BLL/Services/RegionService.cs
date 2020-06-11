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
    public class RegionService : IRegionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegionService(IUnitOfWork unitOfWork, IMapper mapper)
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

        public async Task<RegionDTO> GeteRegionAsync(Guid id)
        {
            return _mapper.Map<Region, RegionDTO>(await GetById(id));
        }

        public async Task<RegionDTO> AddRegionAsync(RegionDTO region)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var entity = _mapper.Map<RegionDTO, Region>(region);
            var result = await _unitOfWork.InsertAsync(entity);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<Region, RegionDTO>(result);
        }

        public async Task RemoveRegion(Guid id)
        {
            var user = Authorization.GetUser();
            var userRole = user.GetType();
            if (userRole != typeof(Administrator))
            {
                throw new MethodAccessException();
            }

            var region = await GetById(id);
            _unitOfWork.Remove(region);
            await _unitOfWork.CommitAsync();
        }

        private async Task<Region> GetById(Guid id)
        {
            var region = await _unitOfWork.GetByIdAsync<Region>(id);

            if (region == null)
            {
                throw new Exception("LocalPoint with following id was not found");
            }

            return region;
        }
    }
}