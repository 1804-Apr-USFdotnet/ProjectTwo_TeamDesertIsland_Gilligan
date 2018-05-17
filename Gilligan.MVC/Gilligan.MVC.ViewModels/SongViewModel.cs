using System;

namespace Gilligan.MVC.ViewModels
{
    public class SongViewModel
    {
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }
}
