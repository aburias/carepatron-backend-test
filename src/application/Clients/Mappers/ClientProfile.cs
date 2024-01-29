using application.Clients.Commands.CreateClient;
using application.Clients.Commands.UpdateClient;
using AutoMapper;
using domain.Clients.Entities;
using domain.Clients.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(d => d.Id, s => s.MapFrom(src => src.Id.Value))
                .ForMember(d => d.FirstName, s => s.MapFrom(src => src.Name.FirstName))
                .ForMember(d => d.LastName, s => s.MapFrom(src => src.Name.LastName))
                .ForMember(d => d.Email, s => s.MapFrom(src => src.Email.Value))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(src => src.PhoneNumber.Value));

            //CreateMap<ClientDto, Client>();
            //CreateMap<List<Client>, List<ClientDto>>();
            CreateMap<CreateClientCommand, Client>()
                .ForMember(d => d.Id, s => s.MapFrom(src => new ClientId(src.Id)))
                .ForMember(d => d.Name, s => s.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(d => d.Email, s => s.MapFrom(src => new Email(src.Email)))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(src => new PhoneNumber(src.PhoneNumber)));

            CreateMap<UpdateClientCommand, Client>()
                .ForMember(d => d.Id, s => s.MapFrom(src => new ClientId(src.Id)))
                .ForMember(d => d.Name, s => s.MapFrom(src => new Name(src.FirstName, src.LastName)))
                .ForMember(d => d.Email, s => s.MapFrom(src => new Email(src.Email)))
                .ForMember(d => d.PhoneNumber, s => s.MapFrom(src => new PhoneNumber(src.PhoneNumber)));

        }
    }
}
