using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class SongRatingsViewModel
    {
        public IEnumerable<SongViewModel> TopDailyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopWeeklyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopMonthlyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopAllTimeRatedSongViewModels { get; set; }
    }
}
