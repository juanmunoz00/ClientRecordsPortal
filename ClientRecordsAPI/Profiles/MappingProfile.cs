using AutoMapper;
using ClientRecordsAPI.Models;
using ClientRecordsAPI.DTOs;

namespace ClientRecordsAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientDto, Client>();
        }
    }
}
