using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    public class GenreRatingViewModel
    {
        public IEnumerable<GenreViewModel> TopDailyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopWeeklyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopMonthlyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopAllTimeRatedGenreViewModels { get; set; }
    }
}
