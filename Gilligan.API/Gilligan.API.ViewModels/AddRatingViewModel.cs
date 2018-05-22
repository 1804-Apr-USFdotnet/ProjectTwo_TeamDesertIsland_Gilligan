using System;

namespace Gilligan.API.ViewModels
{
    public class AddRatingViewModel
    {
        public DateTime? RatedOn { get; set; }
        public int Value { get; set; }
        public Guid UserId { get; set; }
        public Guid SongId { get; set; }
    }
}
