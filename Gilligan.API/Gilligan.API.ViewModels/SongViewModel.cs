using System;

namespace Gilligan.API.ViewModels
{
    public class SongViewModel
    {
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public bool IsAttached { get; set; }
    }
}
