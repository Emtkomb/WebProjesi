using AutoMapper;
using HastaneWeb.EntityLayer.Concrete;
using HastaneWeb.UI.Dtos.BirimDto;
using HastaneWeb.UI.Dtos.HizmetDto;
using HastaneWeb.UI.Dtos.LoginDto;
using HastaneWeb.UI.Dtos.RandevuDto;
using HastaneWeb.UI.Dtos.RegisterDto;

namespace HastaneWeb.UI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultHizmetDto,Hizmet>().ReverseMap();
            CreateMap<UpdateHizmetDto,Hizmet>().ReverseMap();
            CreateMap<CreateHizmetDto,Hizmet>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();
            CreateMap<CreateRandevuDto,Randevu>().ReverseMap();
            CreateMap<CreateBirimDto,Birim>().ReverseMap();
        }
    }
}
