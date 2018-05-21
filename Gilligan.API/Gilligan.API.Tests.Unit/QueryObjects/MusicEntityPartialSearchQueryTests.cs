using System.Collections.Generic;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.QueryObjects
{
    [TestClass]
    public class MusicEntityPartialSearchQueryTests
    {
        private readonly MusicEntityPartialSearchQuery _query;

        public MusicEntityPartialSearchQueryTests()
        {
            _query = new MusicEntityPartialSearchQuery();
        }

        [TestMethod]
        public void AsExpression_SongList_ReturnsPartialMatchingSongs()
        {
            var songs = new List<Song>
            {
                new Song {Name = "Bobs Revenge"},
                new Song {Name = "John's Dud"}
            };

            var result = _query.AsExpression(songs, "Bob");

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AsExpression_ArtistList_ReturnsPartialMatchingArtists()
        {
            var artists = new List<Artist>
            {
                new Artist{Name = "Bobbert"},
                new Artist{Name = "Not There"}
            };

            var result = _query.AsExpression(artists, "Bob");

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AsExpression_AlbumList_ReturnsPartialMatchingAlbums()
        {
            var albums = new List<Album>
            {
                new Album{Name = "Bob's Revenge"},
                new Album{Name = "Probably Not Going To Match"}
            };

            var result = _query.AsExpression(albums, "Bob");

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AsExpression_GenreList_ReturnsPartialMatchingGenres()
        {
            var genres = new List<Genre>
            {
                new Genre{Name = "Soft Bob"},
                new Genre{Name = "Mikes"}
            };

            var result = _query.AsExpression(genres, "BOB");

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
