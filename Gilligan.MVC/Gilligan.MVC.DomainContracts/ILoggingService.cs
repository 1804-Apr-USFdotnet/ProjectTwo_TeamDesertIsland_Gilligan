using System;

namespace Gilligan.MVC.DomainContracts
{
    public interface ILoggingService
    {
        void Log(Exception e);
    }
}
