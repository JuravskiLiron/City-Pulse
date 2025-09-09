using AutoMapper;
using CityPulse.Domain.Models;
using CityPulse.Persistence.Entities;


namespace CityPulse.Persistence;

public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<UserEntity, User>();
    }
}