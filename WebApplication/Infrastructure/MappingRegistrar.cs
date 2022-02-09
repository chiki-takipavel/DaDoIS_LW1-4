using System.Linq;
using AutoMapper;
using Services.Client;
using Services.Client.Models;
using WebApplication.Models.ViewModels;

namespace WebApplication.Infrastructure
{
    public static class MappingRegistrar
    {
        public static IMapper CreareMapper()
        {
            MapperConfiguration config = new MapperConfiguration(e =>
            {
            });
            return config.CreateMapper();
        }

        public static Client ToClient(this Client client, IClientService clientService)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, Client>().ForMember(r => r.DisabilityStatuses,
                    r => r.MapFrom(t => clientService.GetDisabilities().Select(y => y.Status)))
                .ForMember(r => r.Citizenships,
                    r => r.MapFrom(t => clientService.GetCitizenships().Select(y => y.Country)))
                .ForMember(r => r.Places,
                    r => r.MapFrom(t => clientService.GetPlaces().Select(y => y.Name)))
                .ForMember(r => r.MartialStatuses,
                    r => r.MapFrom(t => clientService.GetMaritalStatuses().Select(y => y.Status))));
            return Mapper.Map<Client, Client>(client);
        }

        public static Client ToClient(this ClientModel client, IClientService clientService)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientModel, Client>()
                .ForMember(r => r.Disability, r => r.MapFrom(t => t.Disability.Status))
                .ForMember(r => r.Citizenship, r => r.MapFrom(t => t.Citizenship.Country))
                .ForMember(r => r.MaritalStatus, r => r.MapFrom(t => t.MartialStatus.Status))
                .ForMember(r => r.ResidenceActualPlace, r => r.MapFrom(t => t.Place.Name))
                .ForMember(r => r.DisabilityStatuses,
                    r => r.MapFrom(t => clientService.GetDisabilities().Select(y => y.Status)))
                .ForMember(r => r.Gender,
                    r => r.MapFrom(t => t.Male))
                .ForMember(r => r.Citizenships,
                    r => r.MapFrom(t => clientService.GetCitizenships().Select(y => y.Country)))
                .ForMember(r => r.Places,
                    r => r.MapFrom(t => clientService.GetPlaces().Select(y => y.Name)))
                .ForMember(r => r.MartialStatuses,
                    r => r.MapFrom(t => clientService.GetMaritalStatuses().Select(y => y.Status))));
            return Mapper.Map<ClientModel, Client>(client);
        }

        public static ClientModel ToClientModel(this Client client, IClientService clientService)
        {
            Mapper.Initialize(e =>
            {
                e.CreateMap<Client, ClientModel>()
                    .ForMember(r => r.Disability,
                        r =>
                            r.MapFrom(
                                t => clientService.GetDisabilities().FirstOrDefault(y => y.Status == t.Disability)))
                    .ForMember(r => r.Place,
                        r =>
                            r.MapFrom(
                                t => clientService.GetPlaces().FirstOrDefault(y => y.Name == t.ResidenceActualPlace)))
                    .ForMember(r => r.Male,
                        r =>
                            r.MapFrom(
                                t => t.Gender))
                    .ForMember(r => r.Citizenship,
                        r =>
                            r.MapFrom(
                                t => clientService.GetCitizenships().FirstOrDefault(y => y.Country == t.Citizenship)))
                    .ForMember(r => r.MartialStatus,
                        r =>
                            r.MapFrom(
                                t => clientService.GetMaritalStatuses().FirstOrDefault(y => y.Status == t.MaritalStatus)));
            });
            return Mapper.Map<Client, ClientModel>(client);
        }
    }
}