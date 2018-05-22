using System;
using AutoMapper;
using Gilligan.API.Models;
using Gilligan.API.ViewModels;

namespace Gilligan.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddRemoveUserSongViewModel, UserSong>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserSongId, o => o.Ignore())
                .ForMember(d => d.User, o => o.MapFrom(s => s.UserId));

            CreateMap<Guid, User>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.MapFrom(s => s))
                .ForMember(d => d.FirstName, o => o.Ignore())
                .ForMember(d => d.LastName, o => o.Ignore())
                .ForMember(d => d.DateOfBirth, o => o.Ignore())
                .ForMember(d => d.ZipCode, o => o.Ignore())
                .ForMember(d => d.Email, o => o.Ignore())
                .ForMember(d => d.Ratings, o => o.Ignore())
                .ForMember(d => d.UserSongs, o => o.Ignore());

            CreateMap<AddSongViewModel, Song>()
                .ForMember(d => d.Id, o => o.Ignore())
                .AfterMap((s, d) => d.Id = Guid.NewGuid())
                .ForMember(d => d.SongId, o => o.Ignore())
                .AfterMap((s, d) => d.SongId = Guid.NewGuid())
                .ForMember(d => d.AverageRating, o => o.UseValue(0.0))
                .ForMember(d => d.IsAttached, o => o.UseValue(false))
                .ForMember(d => d.Album, o => o.MapFrom(s => s.AlbumId))
                .ForMember(d => d.Ratings, o => o.Ignore())
                .ForMember(d => d.Artists, o => o.MapFrom(s => s.ArtistIds));

            CreateMap<Guid, Album>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.AlbumId, o => o.MapFrom(s => s))
                .ForMember(d => d.Name, o => o.Ignore())
                .ForMember(d => d.ReleaseDate, o => o.Ignore())
                .ForMember(d => d.Songs, o => o.Ignore());

            CreateMap<Guid, Artist>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.ArtistId, o => o.MapFrom(s => s))
                .ForMember(d => d.Name, o => o.Ignore())
                .ForMember(d => d.Songs, o => o.Ignore())
                .ForMember(d => d.Genres, o => o.Ignore());

            CreateMap<AddAlbumViewModel, Album>()
                .ForMember(d => d.Id, o => o.Ignore())
                .AfterMap((s, d) => d.Id = Guid.NewGuid())
                .ForMember(d => d.AlbumId, o => o.Ignore())
                .AfterMap((s, d) => d.AlbumId = Guid.NewGuid())
                .ForMember(d => d.Songs, o => o.Ignore());

            CreateMap<AddArtistViewModel, Artist>()
                .ForMember(d => d.Id, o => o.Ignore())
                .AfterMap((s, d) => d.Id = Guid.NewGuid())
                .ForMember(d => d.ArtistId, o => o.Ignore())
                .AfterMap((s, d) => d.ArtistId = Guid.NewGuid())
                .ForMember(d => d.Songs, o => o.Ignore())
                .ForMember(d => d.Genres, o => o.MapFrom(s => s.GenreIds));

            CreateMap<Guid, Genre>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Artists, o => o.Ignore())
                .ForMember(d => d.GenreId, o => o.MapFrom(s => s))
                .ForMember(d => d.Name, o => o.Ignore());

            CreateMap<AddGenreViewModel, Genre>()
                .ForMember(d => d.Id, o => o.Ignore())
                .AfterMap((s, d) => d.Id = Guid.NewGuid())
                .ForMember(d => d.Artists, o => o.Ignore());
        }
    }
}
