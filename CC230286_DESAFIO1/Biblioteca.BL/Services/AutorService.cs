using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CC230396_Desafio01.BL.Interfaces;
using CC230396_Desafio01.DAL.Interfaces;
using CC230396_Desafio01.Entities.Dtos;
using CC230396_Desafio01.Entities.Models;

namespace CC230396_Desafio01.BL.Services
{
    public class AutorService(
        IAutorRepository repository,
        IMapper mapper
    ) : IAutorService
    {
        public async Task<List<AutorDto>> GetAllAutoresAsync()
        {
            try
            {
                var result = await repository.GetAutoresAsync();
                return mapper.Map<List<Autor>, List<AutorDto>>(result);
            }
            catch (Exception e)
            {
                return new List<AutorDto>();
            }
        }

        public async Task<AutorDto?> GetAutorByIdAsync(int id)
        {
            try
            {
                var result = await repository.GetAutorByIdAsync(id);
                if (result == null) return null;
                return mapper.Map<Autor, AutorDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> InsertAutorAsync(AutorDto autorDto)
        {
            try
            {
                var entity = mapper.Map<AutorDto, Autor>(autorDto);
                return await repository.InsertAutorAsync(entity);
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<AutorDto?> UpdateAutorAsync(AutorDto autorDto)
        {
            try
            {
                var entity = mapper.Map<AutorDto, Autor>(autorDto);
                var result = await repository.UpdateAutorAsync(entity);
                if (result == null) return null;
                return mapper.Map<Autor, AutorDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAutorAsync(int id)
        {
            try
            {
                return await repository.DeleteAutorAsync(id);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}