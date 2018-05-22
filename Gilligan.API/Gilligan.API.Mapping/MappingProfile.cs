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

            CreateMap<AddRatingViewModel, Rating>()
                .ForMember(d => d.Id, o => o.Ignore())
                .AfterMap((s, d) => d.Id = Guid.NewGuid())
                .ForMember(d => d.RatingId, o => o.Ignore())
                .AfterMap((s, d) => d.RatingId = Guid.NewGuid())
                .ForMember(d => d.User, o => o.MapFrom(s => s.UserId))
                .ForMember(d => d.Song, o => o.MapFrom(s => s.SongId));

            CreateMap<Guid, Song>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.SongId, o => o.MapFrom(s => s))
                .ForMember(d => d.Name, o => o.Ignore())
                .ForMember(d => d.AverageRating, o => o.Ignore())
                .ForMember(d => d.IsAttached, o => o.Ignore())
                .ForMember(d => d.Album, o => o.Ignore())
                .ForMember(d => d.Ratings, o => o.Ignore())
                .ForMember(d => d.Artists, o => o.Ignore());

            CreateMap<Genre, GenreViewModel>()
                .ForMember(d => d.ArtistViewModels, o => o.MapFrom(s => s.Artists));

            CreateMap<Artist, ArtistViewModel>()
                .ForMember(d => d.SongViewModels, o => o.MapFrom(s => s.Songs))
                .ForMember(d => d.GenreViewModels, o => o.MapFrom(s => s.Genres));

            CreateMap<Album, AlbumViewModel>()
                .ForMember(d => d.SongViewModels, o => o.MapFrom(s => s.Songs));

            CreateMap<Song, SongViewModel>()
                .ForMember(d => d.ArtistViewModel, o => o.MapFrom(s => s.Artists))
                .ForMember(d => d.AlbumViewModel, o => o.MapFrom(s => s.Album));

            CreateMap<SongRatings, SongRatingsViewModel>()
                .ForMember(d => d.TopDailyRatedSongViewModels, o => o.MapFrom(s => s.TopDailyRatedSongs))
                .ForMember(d => d.TopWeeklyRatedSongViewModels, o => o.MapFrom(s => s.TopWeeklyRatedSongs))
                .ForMember(d => d.TopMonthlyRatedSongViewModels, o => o.MapFrom(s => s.TopMonthlyRatedSongs))
                .ForMember(d => d.TopAllTimeRatedSongViewModels, o => o.MapFrom(s => s.TopAllTimeRatedSongs));

            CreateMap<ArtistRatings, ArtistRatingsViewModel>()
                .ForMember(d => d.TopDailyArtistViewModels, o => o.MapFrom(s => s.TopDailyRatedArtists))
                .ForMember(d => d.TopWeeklyRatedArtistViewModels, o => o.MapFrom(s => s.TopWeeklyRatedArtists))
                .ForMember(d => d.TopMonthlyRatedArtistViewModels, o => o.MapFrom(s => s.TopMonthlyRatedArtists))
                .ForMember(d => d.TopAllTimeRatedArtistViewModels, o => o.MapFrom(s => s.TopAllTimedRatedArtists));

            CreateMap<AlbumRatings, AlbumRatingsViewModel>()
                .ForMember(d => d.TopDailyAlbumViewModels, o => o.MapFrom(s => s.TopDailyRatedAlbums))
                .ForMember(d => d.TopWeeklyRatedAlbumViewModels, o => o.MapFrom(s => s.TopWeeklyRatedAlbums))
                .ForMember(d => d.TopMonthlyRatedAlbumViewModels, o => o.MapFrom(s => s.TopMonthlyRatedAlbums))
                .ForMember(d => d.TopAllTimeRatedAlbumViewModels, o => o.MapFrom(s => s.TopAllTimeRatedAlbums));

            CreateMap<GenreRatings, GenreRatingsViewModel>()
                .ForMember(d => d.TopDailyRatedGenreViewModels, o => o.MapFrom(s => s.TopDailyRatedGenres))
                .ForMember(d => d.TopWeeklyRatedGenreViewModels, o => o.MapFrom(s => s.TopWeeklyRatedGenres))
                .ForMember(d => d.TopMonthlyRatedGenreViewModels, o => o.MapFrom(s => s.TopMonthlyRatedGenres))
                .ForMember(d => d.TopAllTimeRatedGenreViewModels, o => o.MapFrom(s => s.TopAllTimeRatedGenres));
        }
    }
}
