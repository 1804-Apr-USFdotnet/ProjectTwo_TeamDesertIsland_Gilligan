using AutoMapper;
using Gilligan.API.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.Mapping
{
    [TestClass]
    public class MappingProfileTests
    {
        [TestMethod]
        public void MappingProfile_Empty_ConfigurationIsValid()
        {
            var config = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));

            config.AssertConfigurationIsValid();
        }
    }
}
