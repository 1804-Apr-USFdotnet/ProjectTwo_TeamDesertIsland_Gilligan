﻿using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;

namespace Gilligan.API.QueryObjects
{
    public class TopRatedAlbumsQuery
    {
        private readonly IEnumerable<Album> _list;
        private readonly int _takeAmount;
        private readonly DateTime _oneMonthAgo;
        private readonly DateTime _oneWeekAgo;

        public TopRatedAlbumsQuery(IEnumerable<Album> list, int takeAmount)
        {
            _list = list;
            _takeAmount = takeAmount;
            _oneMonthAgo = DateTime.Today - TimeSpan.FromDays(31);
            _oneWeekAgo = DateTime.Today - TimeSpan.FromDays(7);
        }

        public List<Album> Monthly()
        {
            return _list.Where(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn >= _oneMonthAgo)))
                .OrderByDescending(x => x.Songs.Average(y => y.AverageRating))
                .Take(_takeAmount)
                .ToList();
        }

        public List<Album> Weekly()
        {
            return _list.Where(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn >= _oneWeekAgo)))
                .OrderByDescending(x => x.Songs.Average(y => y.AverageRating))
                .Take(_takeAmount)
                .ToList();
        }

        public List<Album> Daily()
        {
            return _list.Where(x => x.Songs.Any(y => y.Ratings.Any(z => z.RatedOn == DateTime.Today)))
                .OrderByDescending(x => x.Songs.Average(y => y.AverageRating))
                .Take(_takeAmount)
                .ToList();
        }

        public List<Album> AllTime()
        {
            return _list.Where(x => x.Songs.Any(y => y.Ratings.Any()))
                .OrderByDescending(x => x.Songs.Average(y => y.AverageRating))
                .Take(_takeAmount)
                .ToList();
        }
    }
}
