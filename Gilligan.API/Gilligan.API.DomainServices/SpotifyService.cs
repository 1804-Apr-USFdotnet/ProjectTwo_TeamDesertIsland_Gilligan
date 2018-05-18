using System.Collections.Generic;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;

namespace Gilligan.API.DomainServices
{
    public class SpotifyService : ISpotifyService
    {
        private readonly SpotifyWebAPI _spotifyApi;
        private readonly IMapper _mapper;

        public SpotifyService(IMapper mapper)
        {
            _mapper = mapper;
            var credentialsAuth = new ClientCredentialsAuth
            {
                ClientId = "315fa2a87e634761a3e1a1a1538b3053",
                ClientSecret = "b0e3f58a9b1c41f98e76561579cf85e6",
                Scope = Scope.UserReadPrivate
            };

            var token = credentialsAuth.DoAuth();

            _spotifyApi = new SpotifyWebAPI
            {
                TokenType = token.TokenType,
                AccessToken = token.AccessToken,
                UseAuth = true
            };
        }

        public IEnumerable<Album> SearchAlbums(string album)
        {
            var results = _spotifyApi.SearchItems(album, SearchType.Album, 25, 0, "US");

            return _mapper.Map<IEnumerable<Album>>(results);
        }

        public IEnumerable<Song> SearchSongs(string song)
        {
            var results = _spotifyApi.SearchItems(song, SearchType.Track, 25, 0, "US");

            return _mapper.Map<IEnumerable<Song>>(results);
        }

        public IEnumerable<Artist> SearchArtists(string artist)
        {
            var results = _spotifyApi.SearchItems(artist, SearchType.Artist, 25, 0, "US");

            return _mapper.Map<IEnumerable<Artist>>(results);
        }
    }
}
