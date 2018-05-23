using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;

namespace Gilligan.API.QueryObjects
{
    public class TopRatedSongsQuery
    {
        private readonly IEnumerable<Song> _list;
        private readonly int _takeAmount;
        private readonly DateTime _oneMonthAgo;
        private readonly DateTime _oneWeekAgo;

        public TopRatedSongsQuery(IEnumerable<Song> list, int takeAmount)
        {
            _list = list;
            _takeAmount = takeAmount;
            _oneMonthAgo = DateTime.Today - TimeSpan.FromDays(31);
            _oneWeekAgo = DateTime.Today - TimeSpan.FromDays(7);
        }

        public List<Song> Monthly()
        {
            return _list.Where(x => x.Ratings.Any(z => z.RatedOn >= _oneMonthAgo))
                        .OrderByDescending(x => x.AverageRating)
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Song> Weekly()
        {
            return _list.Where(x => x.Ratings.Any(z => z.RatedOn >= _oneWeekAgo))
                        .OrderByDescending(x => x.AverageRating)
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Song> AllTime()
        {
            return _list.Where(x => x.Ratings.Any())
                        .OrderByDescending(x => x.AverageRating)
                        .Take(_takeAmount)
                        .ToList();
        }

        public List<Song> Daily()
        {
            return _list.Where(x => x.Ratings.Any(y => y.RatedOn >= DateTime.Today))
                        .OrderByDescending(x => x.AverageRating)
                        .Take(_takeAmount)
                        .ToList();
        }
    }
}
