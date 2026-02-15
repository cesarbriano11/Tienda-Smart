using AutoMapper;
using TiendaSmartBack.Application.Features.Articulo.DTOs;
using TiendaSmartBack.Application.Features.Auth.DTOs;
using TiendaSmartBack.Application.Features.Sucursal.DTOs;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Application.Utils
{
    public class PerfilesMapper:Profile
    {
        public PerfilesMapper() 
        {
            CreateMap<DatosRegistroRequestDTO, Cliente>();
            CreateMap<DatosRegistroRequestDTO, Usuario>()
                .ForMember(dest => dest.PasswordHash,opt => opt.Ignore())
                .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => "Cliente"));
            CreateMap<DatosSucursalRequestDTO, Sucursal>()
                .ForMember(dest => dest.Habilitado, opt => opt.MapFrom(src => 1));
            CreateMap<Sucursal, ResSucursalesActivasDTO>();
            CreateMap<DatosSucursalActualizaDTO, Sucursal>();
            CreateMap<SucursalArticulo, ResArticulosPorSucursalDTO>()
                .ForMember(dest => dest.IdArticulo,
                    opt => opt.MapFrom(src => src.Articulo.IdArticulo))
            .ForMember(dest => dest.NombreArticulo,
                    opt => opt.MapFrom(src => src.Articulo.NombreArticulo))
            .ForMember(dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Articulo.Codigo))
            .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Articulo.Descripcion))
            .ForMember(dest => dest.Precio,
                    opt => opt.MapFrom(src => src.Articulo.Precio))
            .ForMember(dest => dest.UrlImagen,
                    opt => opt.MapFrom(src => src.Articulo.UrlImagen))
            .ForMember(dest => dest.Stock,
                    opt => opt.MapFrom(src => src.Stock));
        }
    }
}
