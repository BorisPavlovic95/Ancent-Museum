using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.TourAggregate;
using StackExchange.Redis;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {

        private readonly IMapper _mapper;

        public MappingProfiles(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            // Your mapping configurations here...
        }
        public MappingProfiles()
        {
            CreateMap<Exhibits, ExhibitToReturnDto>()
                .ForMember(d => d.ExhibitCulture, o => o.MapFrom(s => s.ExhibitCulture.Name))
                .ForMember(d => d.ExhibitType, o => o.MapFrom(s => s.ExhibitType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ExhibitUrlResolver>())
                .ForMember(d => d.RatingsComments, o => o.MapFrom(s => s.RatingsComments.Select(rc => _mapper.Map<ExhibitRatingCommentDto>(rc))));



            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<AppUser, UserWithAddressDto>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address)); 

            CreateMap<PlannerDto, Planner>();
            CreateMap<PlannerItemDto, PlannerItem>();
            CreateMap<AddressDto, Core.Entities.TourAggregate.Address>();
            CreateMap<Tour, TourToReturnDto>();
            CreateMap<TourToUpdateDto, Tour>();

            CreateMap<TourItem, TourItemDto>()
                .ForMember(d => d.ExhibitId, o => o.MapFrom(s => s.ExhibitItemToured.ExhibitItemId))
                .ForMember(d => d.ExhibitName, o => o.MapFrom(s => s.ExhibitItemToured.ExhibitName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ExhibitItemToured.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<TourItemUrlResolver>());

            CreateMap<ExhibitRatingCommentDto, ExhibitRatingComment>();
            CreateMap<ExhibitRatingComment, ExhibitRatingCommentDto>();

            CreateMap<CommentsDto, ExhibitRatingComment>();
            CreateMap<ExhibitRatingComment, CommentsDto>();

            CreateMap<TourToUpdateDto, Tour>()
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.UserEmail))
                .ForMember(dest => dest.TourDate, opt => opt.MapFrom(src => src.TourDate))
                .ForMember(dest => dest.UserData, opt => opt.MapFrom(src => src.UserData))
                .ForMember(dest => dest.TourItems, opt => opt.MapFrom(src => src.TourItems))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
