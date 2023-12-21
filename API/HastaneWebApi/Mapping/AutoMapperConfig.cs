using AutoMapper;
using HastaneWeb.DtoLayer.Dtos.DoktorDto;
using HastaneWeb.EntityLayer.Concrete;

namespace HastaneWebApi.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<AddDoktorDto, Doktor>();
            CreateMap<Doktor,AddDoktorDto>();

            CreateMap<UpdateDoktorDto, Doktor>().ReverseMap();
         
        }
    }
}
