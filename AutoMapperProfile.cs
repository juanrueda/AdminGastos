using AdminGastos.Models;
using AutoMapper;
using AdminGastos.Dto.Gasto;

namespace AdminGastos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Gasto, GetGastoDto>();
            CreateMap<AddGastoDto, Gasto>();
            CreateMap<AddGastoDto, GetGastoDto>();
            CreateMap<UpdateGastoDto, Gasto>();
            CreateMap<UpdateGastoDto, GetGastoDto>();
        }
    }
}