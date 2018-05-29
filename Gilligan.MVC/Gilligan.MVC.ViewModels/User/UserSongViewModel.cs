using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gilligan.MVC.ViewModels.Music;

namespace Gilligan.MVC.ViewModels.User
{
    public class UserSongViewModel
    {
        public List<SelectListItem> UserItems { get; set; }
        public List<SelectListItem> SongItems { get; set; }
        public Guid UserId { get; set; }
        public Guid SongId { get; set; }
        public DateTime? RatedOn { get; set; }
        public int Value { get; set; }

        public UserSongViewModel(IEnumerable<UserViewModel> users, IEnumerable<SongViewModel> songs)
        {
            UserItems = new List<SelectListItem>();
            SongItems = new List<SelectListItem>();

            foreach (var user in users)
            {
                UserItems.Add(new SelectListItem{Text = user.UserName, Value = user.UserId.ToString()});
            }

            foreach (var song in songs)
            {
                SongItems.Add(new SelectListItem{Text = song.Name, Value = song.SongId.ToString()});
            }
        }
    }
}
