using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ExhibitUrlResolver : IValueResolver<Exhibits, ExhibitToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ExhibitUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Exhibits source, ExhibitToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;

        }
    }
}
