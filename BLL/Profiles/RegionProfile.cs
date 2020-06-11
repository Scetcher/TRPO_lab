using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace DAL.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<RegionDTO, Region>();
            CreateMap<Region, RegionDTO>();
        }
    }
}