using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Biblioteca.Entites.Dtos;
using Biblioteca.Entites.Models;

namespace Biblioteca.BL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Autor, AutorDto>()
                .ForMember(destination => destination.Codigo, opts => opts.MapFrom(source => source.Id))
                .ForMember(destination => destination.Nombre, opts => opts.MapFrom(source => source.Nombre))
                .ForMember(destination => destination.Apellido, opts => opts.MapFrom(source => source.Apellido))
                .ReverseMap();

            CreateMap<Editorial, EditorialDto>().ReverseMap();
            CreateMap<Libro, LibroDto>().ReverseMap();
        }
    }
}
