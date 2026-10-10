using AutoMapper;
using CC230286_DESAFIO_03.Entities.Dtos;
using CC230286_DESAFIO_03.Entities.Models;

namespace CC230286_DESAFIO_03.BL.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();

        CreateMap<Producto, ProductoDto>().ReverseMap();

        CreateMap<Pedido, PedidoDto>()
            .ForMember(d => d.ClienteNombre, opt => opt.MapFrom(s => s.Cliente != null ? $"{s.Cliente.Nombre} {s.Cliente.Apellido}" : null))
            .ForMember(d => d.ProductoNombre, opt => opt.MapFrom(s => s.Producto != null ? s.Producto.Nombre : null))
            .ForMember(d => d.PrecioUnitario, opt => opt.MapFrom(s => s.Producto != null ? s.Producto.Precio : 0))
            .ForMember(d => d.Total, opt => opt.MapFrom(s => s.Producto != null ? s.Producto.Precio * s.Cantidad : 0))
            .ReverseMap()
            .ForMember(d => d.Cliente, opt => opt.Ignore())
            .ForMember(d => d.Producto, opt => opt.Ignore());
    }
}
