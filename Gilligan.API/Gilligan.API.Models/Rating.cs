using System;
using System.ComponentModel.DataAnnotations;

namespace Gilligan.API.Models
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid RatingId { get; set; }
        public DateTime RatedOn { get; set; }
        public int Value { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Song Song { get; set; }
    }
}
