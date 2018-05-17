namespace Gilligan.MVC.ViewModels.Search
{
    public class SearchViewModel
    {
        private enum SearchType { Song, Artist, Genre}
        public string SearchString { get; set; }
    }
}
