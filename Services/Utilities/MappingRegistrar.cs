using AutoMapper;
using Services.Client.Models;
using ORMLibrary;

namespace Services.Utilities
{
    public static class MappingRegistrar
    {
        public static MapperConfiguration CreateMapperConfiguration()
        {
            var config = new MapperConfiguration(e =>
            {
                e.CreateMap<Place, PlaceModel>();
                e.CreateMap<Disability, DisabilityModel>();
                e.CreateMap<MartialStatus, MaritalStatusModel>();
                e.CreateMap<Citizenship, CitizenshipModel>();
                e.CreateMap<ORMLibrary.Client, ClientModel>();
                e.CreateMap<ClientModel, ORMLibrary.Client>()
                    .ForMember(t => t.Citizenship, r => r.Ignore())
                    .ForMember(t => t.Disability, r => r.Ignore())
                    .ForMember(t => t.MartialStatus, r => r.Ignore())
                    .ForMember(t => t.Place, r => r.Ignore());
            });
            return config;
        }
    }
}
