using AutoMapper;

namespace SP19.P05.Web.Features.Cook
{
    public class CookMapping : Profile
    {
        public CookMapping()
        {
            CreateMap<Cook, CookDto>()
                .ReverseMap()
                .ForMember(x => x.Id, o => o.Ignore()); //don't allow Id to be assigned by DTOs

            CreateMap<CreateCookDto, CookDto>();
            CreateMap<CreateCookDto, Cook>();
        }
    }
}
