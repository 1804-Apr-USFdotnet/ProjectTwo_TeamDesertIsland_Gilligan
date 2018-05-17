namespace Gilligan.MVC.DomainContracts
{
    public interface IUserService
    {
        void LogInAsync();
        void LogOutAsync();
        void UpdateInformationAsync();
    }
}
