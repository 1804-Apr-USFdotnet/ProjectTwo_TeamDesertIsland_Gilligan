using AutoMapper;
using Gilligan.API.Models;
using Gilligan.API.ViewModels;

namespace Gilligan.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, User>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Ratings, o => o.Ignore())
                .ForMember(d => d.UserSongs, o => o.Ignore());

            CreateMap<SongViewModel, Song>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Album, o => o.Ignore())
                .ForMember(d => d.Ratings, o => o.Ignore())
                .ForMember(d => d.Artists, o => o.Ignore());
        }
    }
}
