using AutoMapper;
using PetStore.VeterinarioAPI.Data.DTOs;
using PetStore.VeterinarioAPI.Models.Entities;

namespace PetStore.VeterinarioAPI.Mapper;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<VeterinarioDTO, Veterinario>();
            config.CreateMap<Veterinario, VeterinarioDTO>();
        });
        return mappingConfig;
    }
}