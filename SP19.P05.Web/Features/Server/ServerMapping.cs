using AutoMapper;

namespace SP19.P05.Web.Features.Server
{
    public class ServerMapping : Profile
    {
        public ServerMapping()
        {
            CreateMap<Server, ServerDto>()
                .ForMember(x => x.Email, o => o.MapFrom(x => x.User.Email))
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore());

            CreateMap<CreateServerDto, ServerDto>();
            CreateMap<CreateServerDto, Server>();
        }
        
    }
}
