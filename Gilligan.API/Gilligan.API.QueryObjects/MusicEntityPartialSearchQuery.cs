using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.QueryObjects
{
    public class MusicEntityPartialSearchQuery
    {
        public List<Song> AsExpression(IEnumerable<Song> songs, string value)
        {

        }

        public List<Artist> AsExpression(IEnumerable<Artist> artists, string value)
        {

        }

        public List<Album> AsExpression(IEnumerable<Album> albums, string value)
        {

        }

        public List<Genre> AsExpression(IEnumerable<Genre> genres, string value)
        {

        }
    }
}
