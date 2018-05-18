using System;

namespace Gilligan.API.DomainContracts
{
    public interface ILoggingService
    {
        void Log(Exception e);
    }
}
