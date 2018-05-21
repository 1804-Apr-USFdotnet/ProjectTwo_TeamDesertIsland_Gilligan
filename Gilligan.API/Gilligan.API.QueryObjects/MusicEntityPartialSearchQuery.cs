using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gilligan.API.Models;

namespace Gilligan.API.QueryObjects
{
    public class MusicEntityPartialSearchQuery
    {
        public List<Song> AsExpression(IEnumerable<Song> songs, string value)
        {
            return (from x in songs
                where Regex.IsMatch(x.Name.ToLower(), value.ToLower())
                select x).ToList();
        }

        public List<Artist> AsExpression(IEnumerable<Artist> artists, string value)
        {
            return (from x in artists
                where Regex.IsMatch(x.Name.ToLower(), value.ToLower())
                select x).ToList();
        }

        public List<Album> AsExpression(IEnumerable<Album> albums, string value)
        {
            return (from x in albums
                where Regex.IsMatch(x.Name.ToLower(), value.ToLower())
                select x).ToList();
        }

        public List<Genre> AsExpression(IEnumerable<Genre> genres, string value)
        {
            return (from x in genres
                where Regex.IsMatch(x.Name.ToLower(), value.ToLower())
                select x).ToList();
        }
    }
}
