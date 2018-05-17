using System;

namespace Gilligan.MVC.ViewModels.User
{
    public class RatingViewModel
    {
        public Guid RatingId { get; set; }
        public string SongName { get; set; }
        public double Rating { get; set; }
        public DateTime RatedOn { get; set; }
    }
}