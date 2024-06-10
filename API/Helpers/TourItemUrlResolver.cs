using API.Dtos;
using AutoMapper;
using Core.Entities.TourAggregate;

namespace API.Helpers
{
    public class TourItemUrlResolver : IValueResolver<TourItem, TourItemDto, string>
    {
        private readonly IConfiguration _config;

        public TourItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(TourItem source, TourItemDto destination, string destMember, ResolutionContext context)
        {
            if (source != null && source.ExhibitItemToured != null && !string.IsNullOrEmpty(source.ExhibitItemToured.PictureUrl))
            {
                return _config["ApiUrl"] + source.ExhibitItemToured.PictureUrl;
            }

            return null;
        }
    }
}
