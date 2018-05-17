using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gilligan.MVC.ViewModels
{
    public class ReviewViewModel
    {
        public Guid RatingId { get; set; }
        public string SongName { get; set; }
        public double Rating { get; set; }
        public DateTime RatedOn { get; set; }
    }
}