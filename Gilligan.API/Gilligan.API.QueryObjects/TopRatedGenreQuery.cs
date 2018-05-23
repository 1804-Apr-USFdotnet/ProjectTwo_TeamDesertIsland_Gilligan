using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;

namespace Gilligan.API.QueryObjects
{
    public class TopRatedGenreQuery
    {
        private readonly IEnumerable<Genre> _list;
        private readonly int _takeAmount;
        private readonly DateTime _oneMonthAgo;
        private readonly DateTime _oneWeekAgo;

        public TopRatedGenreQuery(IEnumerable<Genre> list, int takeAmount)
        {
            _list = list;
            _takeAmount = takeAmount;
            _oneMonthAgo = DateTime.Today - TimeSpan.FromDays(31);
            _oneWeekAgo = DateTime.Today - TimeSpan.FromDays(7);
        }

        public List<Genre> Monthly()
        {
            return _list.Where(w => w.Artists.Any(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn >= _oneMonthAgo))))
                        .OrderByDescending(x => x.Artists.SelectMany(y => y.Songs.Select(z => z.AverageRating)).Average())
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Genre> Weekly()
        {
            return _list.Where(w => w.Artists.Any(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn >= _oneWeekAgo))))
                        .OrderByDescending(x => x.Artists.SelectMany(y => y.Songs.Select(z => z.AverageRating)).Average())
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Genre> Daily()
        {
            return _list.Where(w => w.Artists.Any(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn == DateTime.Today))))
                        .OrderByDescending(x => x.Artists.SelectMany(y => y.Songs.Select(z => z.AverageRating)).Average())
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Genre> AllTime()
        {
            return _list.Where(w => w.Artists.Any(x => x.Songs.Any(y => y.Ratings.Any())))
                        .OrderByDescending(x => x.Artists.SelectMany(y => y.Songs.Select(z => z.AverageRating)).Average())
                        .Take(_takeAmount)
                        .ToList();
        }
    }
}
