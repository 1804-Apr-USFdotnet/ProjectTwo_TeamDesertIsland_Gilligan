using System;
using System.ComponentModel.DataAnnotations;

namespace Gilligan.MVC.ViewModels.Music
{
    public class AddAlbumViewModel
    {
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
