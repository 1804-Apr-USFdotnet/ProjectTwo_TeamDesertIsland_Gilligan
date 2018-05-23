using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.Logging;

namespace Gilligan.MVC.MVC.Filters
{
    public class ExceptionFilter : HandleErrorAttribute
    {
        private readonly ILoggingService _loggingService;

        public ExceptionFilter()
        {
            _loggingService = new LoggingService();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            var ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            _loggingService.Log(ex);
        }
    }
}