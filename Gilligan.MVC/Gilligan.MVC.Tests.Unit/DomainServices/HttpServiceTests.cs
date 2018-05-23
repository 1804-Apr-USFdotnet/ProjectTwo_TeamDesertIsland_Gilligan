using Gilligan.MVC.DomainServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.MVC.Tests.Unit.DomainServices
{
    [TestClass]
    public class HttpServiceTests
    {
        private readonly HttpService _httpService;

        public HttpServiceTests()
        {
            _httpService = new HttpService();
        }

        [TestMethod]
        public void GetEntityAsync_OnCall_FormatsCallCorrectly()
        {
           
        }
    }
}
