namespace Gilligan.MVC.ViewModels
{
    public class SearchViewModel
    {
        private enum SearchType { Song, Artist, Genre}
        public string SearchString { get; set; }
    }
}
