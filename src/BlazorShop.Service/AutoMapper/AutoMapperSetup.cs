using AutoMapper;
using BlazorShop.Domain.Entities;
using BlazorShop.Service.ViewModel;

namespace BlazorShop.Service.AutoMapper;

public class AutoMapperSetup : Profile
{
    public AutoMapperSetup()
    {
        CreateMap<UsuarioViewModel, Usuario>().ReverseMap();
        CreateMap<LoginViewModel, Login>().ReverseMap();
    }
}
