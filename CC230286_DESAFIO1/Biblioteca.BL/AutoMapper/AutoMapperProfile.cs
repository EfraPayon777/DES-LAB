using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CC230396_Desafio01.Entities.Dtos;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.BL.AutoMapper
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

            CreateMap<Categoria, CategoriaDto>()
            .ForMember(d => d.Codigo, o => o.MapFrom(s => s.Id))
            .ReverseMap();

            CreateMap<Libro, LibroDto>()
                .ForMember(d => d.Codigo, o => o.MapFrom(s => s.Id))
                .ReverseMap();
        }
    }
}
